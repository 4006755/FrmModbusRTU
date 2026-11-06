using Microsoft.VisualBasic;
using ModbusRTU;
using System.Data;
using System.IO.Ports;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using thinger.DataConvertLib;
using System.Threading;
using System.Collections.Concurrent;

namespace FrmModbusRTU
{


    public partial class FrmCollector : Form
    {
        public FrmCollector()
        {
            InitializeComponent();
            InParam();

        }

        /// <summary>
        /// 通讯对象
        /// </summary>
        private ModbusRtu modbus = new ModbusRtu();


        /// <summary>
        /// 表示当前连接状态
        /// </summary>
        private bool lsConnected = false;
        /// <summary>
        /// 多线程令牌
        /// </summary>
        private ConcurrentDictionary<byte, CancellationTokenSource> ctsDict;
        /// <summary>
        /// 站地址，寄存器地址，数据队列
        /// </summary>
        private ConcurrentDictionary<(byte SlaveId, ushort Address), ConcurrentQueue<double>> dataQueue;
        /// <summary>
        /// UI刷新时间
        /// </summary>
        private System.Windows.Forms.Timer uiTimer;
        /// <summary>
        /// 需要采集的数据
        /// </summary>
        private List<(byte SlaveId, ushort Address, string Name)> pointList = new List<(byte, ushort, string)>
        {
            (0x01, 0x0000, "数据1"),
            (0x01, 0x0001, "数据2"),
            (0x02, 0x0000, "数据3"),
            (0x02, 0x0001, "数据4"),
        };
        private static readonly object _serialLock = new object();

        private List<Task> _runningTasks = new List<Task>();

        /// <summary>
        /// 循环开关
        /// </summary>
        private volatile bool _isShuttingDwn = false;

        #region 初始化参数
        private void InParam()
        {   //获取本机端口号列表
            string[] portList = SerialPort.GetPortNames();

            //dataQueue = new ConcurrentQueue<double>();
            if (portList.Length > 0)
            {
                this.cmb_Port.Items.AddRange(portList);
                this.cmb_Port.SelectedIndex = 0;
            }

            //波特率
            this.cmb_BaudRate.Items.AddRange(new string[] { "2400", "4800", "9600", "19200", "38400" });
            this.cmb_BaudRate.SelectedIndex = 2;


            //动态修改listView第二列宽度
            this.lts_unfo.Columns[1].Width = this.lts_unfo.Width - this.lts_unfo.Columns[0].Width - 25;
        }
        #endregion

        #region 建立链接与断开链接
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (lsConnected)
            {
                AddLog(1, "已连接");
                return;
            }

            //Parity parity = (Parity)Enum.Parse(typeof(Parity), this.cmb_Parity.Text, true);
            //StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), this.cmb_StopBits.Text, true);
            lsConnected = modbus.Connect(this.cmb_Port.Text, Convert.ToInt32(this.cmb_BaudRate.Text), Parity.None, 8, StopBits.One);

            if (lsConnected)
            {
                AddLog(0, "连接成功");
                StartAcquisition();
            }
            else
            {
                AddLog(1, "链接失败");
            }
        }



        private void btn_Disconnect_Click(object sender, EventArgs e)
        {

            //关闭多线程
            StopAcquisition();
            modbus.DisConnect();
            lsConnected = false;
            AddLog(0, "断开链接");
        }
        #endregion

        #region 启用多线程采集
        /// <summary>
        ///  启用采集的方法
        /// </summary>
        public void StartAcquisition()
        {
            StopAcquisition();

            _isShuttingDwn = false;

            dataQueue = new ConcurrentDictionary<(byte, ushort), ConcurrentQueue<double>>();
            ctsDict = new ConcurrentDictionary<byte, CancellationTokenSource>();

            //按照站地址分组
            var groups = pointList.GroupBy(p => p.SlaveId);

            foreach (var group in groups)
            {
                byte slaveId = group.Key;
                var addresses = group.Select(p => p.Address).ToList();

                //为每个点建立一个空队列
                foreach (var addr in addresses)
                {
                    dataQueue.TryAdd((slaveId, addr), new ConcurrentQueue<double>());
                }

                //新建取消令牌
                var _cts = new CancellationTokenSource();
                ctsDict.TryAdd(slaveId, _cts);

                Task.Run(() => Communication(slaveId, addresses, _cts.Token), _cts.Token);
            }

            uiTimer = new System.Windows.Forms.Timer();
            uiTimer.Interval = 100;
            uiTimer.Tick += OnRefreshUITimer;
            uiTimer.Start();

        }
        /// <summary>
        /// 循环采集数据
        /// </summary>
        /// <param name="token"></param>
        private void Communication(byte slaveid, List<ushort> addresses, CancellationToken token)
        {
            if (addresses == null || addresses.Count == 0) return;

            ushort startAddr = addresses.Min();
            ushort count = (ushort)addresses.Count;

            while (!token.IsCancellationRequested && !_isShuttingDwn)
            {
                try
                {
                    //收发报文
                    byte[] data = null;
                    lock (_serialLock)
                    {
                        data = modbus.ReadOutputReglsters(slaveid, startAddr, count);
                    }

                    if (data == null || data.Length < count * 2)
                    {
                        Thread.Sleep(500);
                        continue;
                    }

                    for (int i = 0; i < count; i++)
                    {
                        if (token.IsCancellationRequested) return;

                        ushort rawValue = (ushort)((data[i * 2] << 8) | data[i * 2 + 1]);
                        double physicalvalue = rawValue * 0.1;

                        ushort actualAddr = (ushort)(startAddr + i);

                        if (dataQueue != null &&
                            dataQueue.TryGetValue((slaveid, actualAddr), out var queue) &&
                            queue != null)
                        {
                            while (queue.Count > 1)
                            {
                                queue.TryDequeue(out _);
                            }
                            queue.Enqueue(physicalvalue);
                        }
                    }

                    //采集间隔
                    if (token.WaitHandle.WaitOne(100)) // 返回 true 表示被取消
                    {
                        return; // 立即退出循环
                    }
                }
                catch (Exception ex)
                {
                    if (dataQueue != null)
                    {
                        foreach (var addr in addresses)
                        {
                            if (dataQueue.TryGetValue((slaveid, addr), out var queue) &&
                                queue != null)
                            {
                                queue.Enqueue(-999);
                            }
                        }
                    }
                    if (token.WaitHandle.WaitOne(1000)) // 返回 true 表示被取消
                    {
                        return; // 立即退出循环
                    } // 异常后等1秒
                }
            }
        }
        /// <summary>
        /// 停止采集的方法
        /// </summary>
        public void StopAcquisition()
        {
            _isShuttingDwn = true;

            if (ctsDict == null) return;

            foreach (var cts in ctsDict.Values)
            {
                try { cts?.Cancel(); } catch { }
            }

            try
            {
                Task.WaitAll(_runningTasks.ToArray(), 3000);
            }
            catch { }
            _runningTasks.Clear();

            foreach (var cts in ctsDict.Values)
            {
                try { cts?.Dispose(); } catch { }
            }
            ctsDict.Clear();


            if (dataQueue != null)
            {
                foreach (var queue in dataQueue.Values)
                {
                    while (queue.TryDequeue(out _)) { }
                }
                dataQueue.Clear();
            }

            if (uiTimer != null)
            {
                uiTimer.Stop();
                uiTimer.Tick -= OnRefreshUITimer;
                uiTimer.Dispose();
                uiTimer = null;
            }

        }
        #endregion

        #region 写入ui
        /// <summary>
        /// 更新界面数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRefreshUITimer(object? sender, EventArgs e)
        {
            if (this.IsDisposed || this.Disposing)
            {
                uiTimer?.Stop();
                return;
            }

            if (dataQueue.TryGetValue((0x01, 0x0000), out var queue1) && queue1.TryPeek(out double Display1))
            {
                txtDisplay1.Text = Display1.ToString("F2");
            }

            if (dataQueue.TryGetValue((0x01, 0x0001), out var queue2) && queue2.TryPeek(out double Display2))
            {
                txtDisplay2.Text = Display2.ToString("F2");
            }

            if (dataQueue.TryGetValue((0x02, 0x0000), out var queue3) && queue3.TryPeek(out double Display3))
            {
                txtDisplay3.Text = Display3.ToString("F2");
            }

            if (dataQueue.TryGetValue((0x02, 0x0001), out var queue4) && queue4.TryPeek(out double Display4))
            {
                txtDisplay4.Text = Display4.ToString("F2");
            }
        }
        #endregion
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // 防止重复触发
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // 1. 先停采集（等线程真正退出）
                StopAcquisition();

                // 2. 确认线程真的退出了
                if (_runningTasks != null && _runningTasks.Any(t => !t.IsCompleted))
                {
                    var result = MessageBox.Show("后台任务还在运行，是否强制关闭？",
                        "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        e.Cancel = true; // 取消关闭
                        return;
                    }

                }
            }

            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // 不再做任何 UI 操作，只做资源释放
            base.OnFormClosed(e);
        }

        #region 写入日志
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="level">日志等级（分为3级）</param>
        /// <param name="info">日志内容</param>
        private void AddLog(int level, string info)
        {
            ListViewItem lst = new ListViewItem("  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), level);
            lst.SubItems.Add(info);
            this.lts_unfo.Items.Insert(0, lst);
        }
        #endregion

    }
}
