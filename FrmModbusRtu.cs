using Microsoft.VisualBasic;
using ModbusRTU;
using System.Data;
using System.IO.Ports;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using thinger.DataConvertLib;

namespace FrmModbusRTU
{
    public enum StoreArea
    {
        输出线圈0x,
        输入线圈1x,
        输出寄存器4x,
        输入寄存器3x,

    }

    public partial class FrmModbusRtu : Form
    {
        public FrmModbusRtu()
        {
            InitializeComponent();
            InParam();
        }

        /// <summary>
        /// 通讯对象
        /// </summary>
        private ModbusRtu modbus = new ModbusRtu();

        private DataFormat dataFormat = DataFormat.ABCD;

        /// <summary>
        /// 表示当前连接状态
        /// </summary>
        private bool lsConnected = false;

        #region 初始化参数
        private void InParam()
        {   //获取本机端口号列表
            string[] portList = SerialPort.GetPortNames();

            if (portList.Length > 0)
            {
                this.cmb_Port.Items.AddRange(portList);
                this.cmb_Port.SelectedIndex = 0;
            }

            //波特率
            this.cmb_BaudRate.Items.AddRange(new string[] { "2400", "4800", "9600", "19200", "38400" });
            this.cmb_BaudRate.SelectedIndex = 2;

            //校验位
            this.cmb_Parity.DataSource = Enum.GetNames(typeof(Parity));
            this.cmb_Parity.SelectedIndex = 0;

            //停止位
            this.cmb_StopBits.DataSource = Enum.GetNames(typeof(StopBits));
            this.cmb_StopBits.SelectedIndex = 1;

            //数据位
            this.cmb_DataBits.Items.AddRange(new string[] { "7", "8" });
            this.cmb_DataBits.SelectedIndex = 1;

            //大小端
            this.cmb_DataFormat.DataSource = Enum.GetNames(typeof(DataFormat));
            this.cmb_DataFormat.SelectedIndex = 0;

            //存储区
            this.cmb_StoreArea.DataSource = Enum.GetNames(typeof(StoreArea));
            this.cmb_StoreArea.SelectedIndex = 0;

            //数据类型
            this.cmb_DataTypc.DataSource = Enum.GetNames(typeof(DataType));
            this.cmb_DataTypc.SelectedIndex = 0;

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

            Parity parity = (Parity)Enum.Parse(typeof(Parity), this.cmb_Parity.Text, true);
            StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), this.cmb_StopBits.Text, true);
            lsConnected = modbus.Connect(this.cmb_Port.Text, Convert.ToInt32(this.cmb_BaudRate.Text), parity, Convert.ToInt32(this.cmb_DataBits.Text), stopBits);

            if (lsConnected)
            {
                AddLog(0, "连接成功");
            }
            else
            {
                AddLog(1, "链接失败");
            }
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            modbus.DisConnect();
            lsConnected = false;
            AddLog(0, "断开链接");
        }
        #endregion

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

        #region 读取
        private void btn_Read_Click(object sender, EventArgs e)
        {
            if (CommonVerify())
            {
                byte devid = byte.Parse(this.txt_Slaveld.Text.Trim());
                ushort start = ushort.Parse(this.txt_Start.Text.Trim());
                ushort length = ushort.Parse(this.txt_Length.Text.Trim());

                DataType dataType = (DataType)Enum.Parse(typeof(DataType), this.cmb_DataTypc.Text, true);
                StoreArea storeArea = (StoreArea)Enum.Parse(typeof(StoreArea), this.cmb_StoreArea.Text, true);
                dataFormat = (DataFormat)Enum.Parse(typeof(DataFormat), this.cmb_DataFormat.Text, true);

                switch (dataType)
                {
                    case DataType.Bool:
                        ReadBool(storeArea, devid, start, length);
                        break;
                    case DataType.Byte:
                        ReadByte(storeArea, devid, start, length);
                        break;
                    case DataType.Short:
                        ReadShort(storeArea, devid, start, length);
                        break;
                    case DataType.UShort:
                        ReadUShort(storeArea, devid, start, length);
                        break;
                    case DataType.Int:
                        ReadInt(storeArea, devid, start, length);
                        break;
                    case DataType.UInt:
                        ReadUInt(storeArea, devid, start, length);
                        break;
                    case DataType.Float:
                        ReadFloat(storeArea, devid, start, length);
                        break;
                    case DataType.Double:
                    case DataType.Long:
                    case DataType.ULong:
                    case DataType.String:
                    case DataType.ByteArray:
                    case DataType.HexString:
                        AddLog(1, "读取失败，不支持该类型");
                        return;

                }
            }
        }
        #endregion 

        #region 读取bool
        private void ReadBool(StoreArea storeArea, byte devld, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                    result = modbus.ReadOutpuCoils(devld, start, length);
                    break;
                case StoreArea.输入线圈1x:
                    result = modbus.ReadInpuCoils(devld, start, length);
                    break;
                case StoreArea.输出寄存器4x:
                case StoreArea.输入寄存器3x:
                    AddLog(1, "不支持改存储区");
                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(BitLib.GetBitArrayFromByteArray(result, 0, length)));
            }
            else
            {
                AddLog(1, "读取失败");
            }
        }
        #endregion

        #region 读取字节
        private void ReadByte(StoreArea storeArea, byte devld, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                    result = modbus.ReadOutpuCoils(devld, start, length);
                    break;
                case StoreArea.输入线圈1x:
                    result = modbus.ReadInpuCoils(devld, start, length);
                    break;
                case StoreArea.输出寄存器4x:
                    result = modbus.ReadOutputReglsters(devld, start, length);
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbus.ReadInputReglsters(devld, start, length);

                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(result));
            }
            else
            {
                AddLog(1, "读取失败");
            }
        }
        #endregion

        #region 读取Short
        private void ReadShort(StoreArea storeArea, byte devld, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog(1, "不支持改存储区");
                    return;
                case StoreArea.输出寄存器4x:
                    result = modbus.ReadOutputReglsters(devld, start, length);
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbus.ReadInputReglsters(devld, start, length);

                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(ShortLib.GetShortArrayFromByteArray(result)));
            }
            else
            {
                AddLog(1, "读取失败");
            }
        }
        #endregion

        #region 读取UShort
        private void ReadUShort(StoreArea storeArea, byte devld, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog(1, "不支持改存储区");
                    return;
                case StoreArea.输出寄存器4x:
                    result = modbus.ReadOutputReglsters(devld, start, length);
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbus.ReadInputReglsters(devld, start, length);

                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(UShortLib.GetUShortArrayFromByteArray(result)));
            }
            else
            {
                AddLog(1, "读取失败");
            }
        }
        #endregion

        #region 读取Int
        private void ReadInt(StoreArea storeArea, byte devld, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog(1, "不支持改存储区");
                    return;
                case StoreArea.输出寄存器4x:
                    result = modbus.ReadOutputReglsters(devld, start, (ushort)(length * 2));
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbus.ReadInputReglsters(devld, start, (ushort)(length * 2));

                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(IntLib.GetIntArrayFromByteArray(result, this.dataFormat)));
            }
            else
            {
                AddLog(1, "读取失败");
            }
        }
        #endregion

        #region 读取UInt
        private void ReadUInt(StoreArea storeArea, byte devld, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog(1, "不支持改存储区");
                    return;
                case StoreArea.输出寄存器4x:
                    result = modbus.ReadOutputReglsters(devld, start, (ushort)(length * 2));
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbus.ReadInputReglsters(devld, start, (ushort)(length * 2));

                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(UIntLib.GetUIntArrayFromByteArray(result, this.dataFormat)));
            }
            else
            {
                AddLog(1, "读取失败");
            }
        }
        #endregion

        #region 读取Float
        private void ReadFloat(StoreArea storeArea, byte devld, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog(1, "不支持改存储区");
                    return;
                case StoreArea.输出寄存器4x:
                    result = modbus.ReadOutputReglsters(devld, start, (ushort)(length * 2));
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbus.ReadInputReglsters(devld, start, (ushort)(length * 2));

                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(FloatLib.GetFloatArrayFromByteArray(result, this.dataFormat)));
            }
            else
            {
                AddLog(1, "读取失败");
            }
        }
        #endregion

        #region 通用验证方法
        private bool CommonVerify()
        {
            if (lsConnected == false)
            {
                AddLog(1, "未连接");
                return false;
            }

            if (byte.TryParse(this.txt_Slaveld.Text, out _) == false)
            {
                AddLog(1, "站地址格式错误");
                return false;
            }

            if (ushort.TryParse(this.txt_Start.Text, out _) == false)
            {
                AddLog(1, "起始地址格式错误");
                return false;

            }

            if (ushort.TryParse(this.txt_Length.Text, out _) == false)
            {
                AddLog(1, "长度格式错误");
                return false;
            }
            return true;
        }
        #endregion

        #region 写入
        private void btn_Write_Click(object sender, EventArgs e)
        {
            if (CommonVerify())
            {
                byte devid = byte.Parse(this.txt_Slaveld.Text.Trim());
                ushort start = ushort.Parse(this.txt_Start.Text.Trim());
                string setValue = this.txt_WriteValue.Text.Trim();

                DataType dataType = (DataType)Enum.Parse(typeof(DataType), this.cmb_DataTypc.Text, true);
                StoreArea storeArea = (StoreArea)Enum.Parse(typeof(StoreArea), this.cmb_StoreArea.Text, true);
                dataFormat = (DataFormat)Enum.Parse(typeof(DataFormat), this.cmb_DataFormat.Text, true);

                switch (dataType)
                {
                    case DataType.Bool:
                        WriteBool(storeArea, devid, start, setValue);
                        break;
                    case DataType.Byte:
                        WriteByte(storeArea, devid, start, setValue);
                        break;
                    case DataType.Short:
                        WriteShort(storeArea, devid, start, setValue);
                        break;
                    case DataType.UShort:
                        WriteUShort(storeArea, devid, start, setValue);
                        break;
                    case DataType.Int:
                        WriteInt(storeArea, devid, start, setValue);
                        break;
                    case DataType.UInt:
                        WriteUInt(storeArea, devid, start, setValue);
                        break;
                    case DataType.Float:
                        WriteFloat(storeArea, devid, start, setValue);
                        break;
                    case DataType.Double:
                    case DataType.Long:
                    case DataType.ULong:
                    case DataType.String:
                    case DataType.ByteArray:
                    case DataType.HexString:
                        AddLog(1, "写入失败，不支持该类型");
                        return;

                }
            }
        }
        #endregion

        #region 写入bool
        private void WriteBool(StoreArea storeArea, byte devid, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出线圈0x:

                    bool[] values = BitLib.GetBitArrayFromBitArrayString(setValue);
                    if (values.Length == 1)
                    {
                        result = modbus.PreSetSingleCoil(devid, start, values[0]);
                    }
                    else
                    {
                        result = modbus.PreSetMultiCoils(devid, start, values);
                    }

                    break;
                case StoreArea.输入线圈1x:
                case StoreArea.输出寄存器4x:
                case StoreArea.输入寄存器3x:
                    AddLog(1, "写入失败，不支持改存储区");
                    return;

            }
            if (result)
            {
                AddLog(0, "写入成功");
            }
            else
            {
                AddLog(1, "写入失败");
            }
        }
        #endregion

        #region 写入byte
        private void WriteByte(StoreArea storeArea, byte devid, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:
                    result = modbus.PreSetMultiRegisters(devid, start, ByteArrayLib.GetByteArrayFromHexString(setValue));
                    break;
                case StoreArea.输出线圈0x:

                case StoreArea.输入线圈1x:

                case StoreArea.输入寄存器3x:
                    AddLog(1, "写入失败，不支持改存储区");
                    return;

            }
            if (result)
            {
                AddLog(0, "写入成功");
            }
            else
            {
                AddLog(1, "写入失败");
            }
        }
        #endregion

        #region 写入short
        private void WriteShort(StoreArea storeArea, byte devid, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:

                    short[] values = ShortLib.GetShortArrayFromString(setValue);

                    if (values.Length == 1)
                    {
                        result = modbus.PreSetSingleRegister(devid, start, values[0]);
                    }
                    else
                    {
                        result = modbus.PreSetMultiRegisters(devid, start, ByteArrayLib.GetByteArrayFromShortArray(values));
                    }
                    break;
                case StoreArea.输出线圈0x:

                case StoreArea.输入线圈1x:

                case StoreArea.输入寄存器3x:
                    AddLog(1, "写入失败，不支持改存储区");
                    return;

            }
            if (result)
            {
                AddLog(0, "写入成功");
            }
            else
            {
                AddLog(1, "写入失败");
            }
        }
        #endregion

        #region 写入UShort
        private void WriteUShort(StoreArea storeArea, byte devid, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:

                    ushort[] values = UShortLib.GetUShortArrayFromString(setValue);

                    if (values.Length == 1)
                    {
                        result = modbus.PreSetSingleRegister(devid, start, values[0]);
                    }
                    else
                    {
                        result = modbus.PreSetMultiRegisters(devid, start, ByteArrayLib.GetByteArrayFromUShortArray(values));
                    }
                    break;
                case StoreArea.输出线圈0x:

                case StoreArea.输入线圈1x:

                case StoreArea.输入寄存器3x:
                    AddLog(1, "写入失败，不支持改存储区");
                    return;

            }
            if (result)
            {
                AddLog(0, "写入成功");
            }
            else
            {
                AddLog(1, "写入失败");
            }
        }
        #endregion

        #region 写入Int
        private void WriteInt(StoreArea storeArea, byte devid, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:

                    int[] values = IntLib.GetIntArrayFromString(setValue);

                    result = modbus.PreSetMultiRegisters(devid, start, ByteArrayLib.GetByteArrayFromIntArray(values));

                    break;
                case StoreArea.输出线圈0x:

                case StoreArea.输入线圈1x:

                case StoreArea.输入寄存器3x:
                    AddLog(1, "写入失败，不支持改存储区");
                    return;

            }
            if (result)
            {
                AddLog(0, "写入成功");
            }
            else
            {
                AddLog(1, "写入失败");
            }
        }
        #endregion

        #region 写入UInt
        private void WriteUInt(StoreArea storeArea, byte devid, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:

                    uint[] values = UIntLib.GetUIntArrayFromString(setValue);

                    result = modbus.PreSetMultiRegisters(devid, start, ByteArrayLib.GetByteArrayFromUIntArray(values));

                    break;
                case StoreArea.输出线圈0x:

                case StoreArea.输入线圈1x:

                case StoreArea.输入寄存器3x:
                    AddLog(1, "写入失败，不支持改存储区");
                    return;

            }
            if (result)
            {
                AddLog(0, "写入成功");
            }
            else
            {
                AddLog(1, "写入失败");
            }
        }
        #endregion

        #region 写入Float
        private void WriteFloat(StoreArea storeArea, byte devid, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:

                    float[] values = FloatLib.GetFloatArrayFromString(setValue);

                    result = modbus.PreSetMultiRegisters(devid, start, ByteArrayLib.GetByteArrayFromFloatArray(values));

                    break;
                case StoreArea.输出线圈0x:

                case StoreArea.输入线圈1x:

                case StoreArea.输入寄存器3x:
                    AddLog(1, "写入失败，不支持改存储区");
                    return;

            }
            if (result)
            {
                AddLog(0, "写入成功");
            }
            else
            {
                AddLog(1, "写入失败");
            }
        }
        #endregion

    }
}
