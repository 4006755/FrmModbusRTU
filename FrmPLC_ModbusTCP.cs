using modbustcp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace FrmModbusRTU
{
    public partial class FrmPLC_ModbusTCP : Form
    {
        public FrmPLC_ModbusTCP()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 通讯对象
        /// </summary>
        private modbusTcp PLCmodbus = new modbusTcp();

        /// <summary>
        /// 表示当前连接状态
        /// </summary>
        private bool lsConnected = false;

        /// <summary>
        /// 线程停止令牌
        /// </summary>
        private CancellationTokenSource ctsDict;

        /// <summary>
        /// 循环开关
        /// </summary>
        private volatile bool _isShuttingDwn = false;

        /// <summary>
        /// 建立连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (lsConnected && PLCmodbus.IsConnected)
            {
                MessageBox.Show("已连接");
            }

            lsConnected = PLCmodbus.Connect(this.IP_txt.Text, Convert.ToInt32(this.Port_txt.Text));

            if (lsConnected || !PLCmodbus.IsConnected)
            {
                StartAcquisition();
                MessageBox.Show("连接成功");
            }
            else
            {
                lsConnected = false;
                MessageBox.Show("连接失败" + PLCmodbus.LastError);
            }
        }



        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            StopAcquisition();
            if (lsConnected)
            {
                PLCmodbus.CloseSocket();
                lsConnected = false;
                MessageBox.Show("断开连接");
            }
        }

        /// <summary>
        /// 开始多线程采集
        /// </summary>
        private void StartAcquisition()
        {
            StopAcquisition();
            _isShuttingDwn = false;

            ctsDict = new CancellationTokenSource();

            Task.Run(() =>
            {
                Communication();
            }, ctsDict.Token);
        }

        /// <summary>
        /// 循环采集数据
        /// </summary>
        private void Communication()
        {
            while (!ctsDict.IsCancellationRequested && !_isShuttingDwn)
            {
                byte[] data = null;
                data = PLCmodbus.ReadInputReglsters(0, 100);
            }
        }

        /// <summary>
        /// 停止多线程采集
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void StopAcquisition()
        {
            throw new NotImplementedException();
        }

    }
}
