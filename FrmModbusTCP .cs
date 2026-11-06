using Microsoft.VisualBasic;
using ModbusRTU;
using modbustcp;
using System.Collections.Concurrent;
using System.Data;
using System.IO.Ports;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using thinger.DataConvertLib;

namespace FrmModbusRTU
{


    public partial class FrmModbusTCP : Form
    {
        public FrmModbusTCP()
        {
            InitializeComponent();
            InParam();
        }

        /// <summary>
        /// 通讯对象
        /// </summary>
        private modbusTcp modbus = new modbusTcp();

        private DataFormat dataFormat = DataFormat.ABCD;

        /// <summary>
        /// 表示当前连接状态
        /// </summary>
        private bool lsConnected = false;

        #region 初始化参数
        private void InParam()
        {
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
            if (lsConnected && modbus.IsConnected)
            {
                AddLog(1, "已连接");
                return;
            }

            lsConnected = modbus.Connect(this.IP_txt.Text, Convert.ToInt32(this.Port_txt.Text));

            if (lsConnected)
            {
                AddLog(0, "连接成功");
            }
            else
            {
                AddLog(1, "链接失败" + modbus.LastError);
            }
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            modbus.CloseSocket();
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
                ushort start = ushort.Parse(this.txt_Start.Text.Trim());
                ushort length = ushort.Parse(this.txt_Length.Text.Trim());

                DataType dataType = (DataType)Enum.Parse(typeof(DataType), this.cmb_DataTypc.Text, true);
                StoreArea storeArea = (StoreArea)Enum.Parse(typeof(StoreArea), this.cmb_StoreArea.Text, true);
                dataFormat = (DataFormat)Enum.Parse(typeof(DataFormat), this.cmb_DataFormat.Text, true);

                switch (dataType)
                {
                    case DataType.Bool:
                        ReadBool(storeArea, start, length);
                        break;
                    case DataType.Byte:
                        ReadByte(storeArea, start, length);
                        break;
                    case DataType.Short:
                        ReadShort(storeArea, start, length);
                        break;
                    case DataType.UShort:
                        ReadUShort(storeArea, start, length);
                        break;
                    case DataType.Int:
                        ReadInt(storeArea, start, length);
                        break;
                    case DataType.UInt:
                        ReadUInt(storeArea, start, length);
                        break;
                    case DataType.Float:
                        ReadFloat(storeArea, start, length);
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
        private void ReadBool(StoreArea storeArea, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                    result = modbus.ReadOutpuCoils(start, length);
                    break;
                case StoreArea.输入线圈1x:
                    result = modbus.ReadInpuCoils(start, length);
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
                AddLog(1, "读取失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 读取字节
        private void ReadByte(StoreArea storeArea, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                    result = modbus.ReadOutpuCoils(start, length);
                    break;
                case StoreArea.输入线圈1x:
                    result = modbus.ReadInpuCoils(start, length);
                    break;
                case StoreArea.输出寄存器4x:
                    result = modbus.ReadOutputReglsters(start, length);
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbus.ReadInputReglsters( start, length);

                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(result));
            }
            else
            {
                AddLog(1, "读取失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 读取Short
        private void ReadShort(StoreArea storeArea, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog(1, "不支持改存储区");
                    return;
                case StoreArea.输出寄存器4x:
                    result = modbus.ReadOutputReglsters(start, length);
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbus.ReadInputReglsters(start, length);

                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(ShortLib.GetShortArrayFromByteArray(result)));
            }
            else
            {
                AddLog(1, "读取失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 读取UShort
        private void ReadUShort(StoreArea storeArea, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog(1, "不支持改存储区");
                    return;
                case StoreArea.输出寄存器4x:
                    result = modbus.ReadOutputReglsters(start, length);
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbus.ReadInputReglsters(start, length);

                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(UShortLib.GetUShortArrayFromByteArray(result)));
            }
            else
            {
                AddLog(1, "读取失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 读取Int
        private void ReadInt(StoreArea storeArea, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog(1, "不支持改存储区");
                    return;
                case StoreArea.输出寄存器4x:
                    result = modbus.ReadOutputReglsters(start, (ushort)(length * 2));
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbus.ReadInputReglsters(start, (ushort)(length * 2));

                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(IntLib.GetIntArrayFromByteArray(result, this.dataFormat)));
            }
            else
            {
                AddLog(1, "读取失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 读取UInt
        private void ReadUInt(StoreArea storeArea, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog(1, "不支持改存储区");
                    return;
                case StoreArea.输出寄存器4x:
                    result = modbus.ReadOutputReglsters(start, (ushort)(length * 2));
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbus.ReadInputReglsters(start, (ushort)(length * 2));

                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(UIntLib.GetUIntArrayFromByteArray(result, this.dataFormat)));
            }
            else
            {
                AddLog(1, "读取失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 读取Float
        private void ReadFloat(StoreArea storeArea, ushort start, ushort length)
        {
            byte[] result = null;
            switch (storeArea)
            {
                case StoreArea.输出线圈0x:
                case StoreArea.输入线圈1x:
                    AddLog(1, "不支持改存储区");
                    return;
                case StoreArea.输出寄存器4x:
                    result = modbus.ReadOutputReglsters(start, (ushort)(length * 2));
                    break;
                case StoreArea.输入寄存器3x:
                    result = modbus.ReadInputReglsters(start, (ushort)(length * 2));

                    return;
            }

            if (result != null)
            {
                AddLog(1, "读取成功：" + StringLib.GetStringFromValueArray(FloatLib.GetFloatArrayFromByteArray(result, this.dataFormat)));
            }
            else
            {
                AddLog(1, "读取失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 通用验证方法
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        private bool CommonVerify()
        {
            if (lsConnected == false || !modbus.IsConnected)
            {
                lsConnected = false;
                AddLog(1, "未连接");
                return false;
            }

            if (byte.TryParse(this.txt_Slaveld.Text, out byte slaveId) == false)
            {
                AddLog(1, "站地址格式错误");
                return false;
            }

            //把界面上的站地址同步到通讯对象（原来一直用的是默认值 1）
            modbus.Slaveid = slaveId;

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
                ushort start = ushort.Parse(this.txt_Start.Text.Trim());
                string setValue = this.txt_WriteValue.Text.Trim();

                DataType dataType = (DataType)Enum.Parse(typeof(DataType), this.cmb_DataTypc.Text, true);
                StoreArea storeArea = (StoreArea)Enum.Parse(typeof(StoreArea), this.cmb_StoreArea.Text, true);
                dataFormat = (DataFormat)Enum.Parse(typeof(DataFormat), this.cmb_DataFormat.Text, true);

                switch (dataType)
                {
                    case DataType.Bool:
                        WriteBool(storeArea, start, setValue);
                        break;
                    case DataType.Byte:
                        WriteByte(storeArea, start, setValue);
                        break;
                    case DataType.Short:
                        WriteShort(storeArea, start, setValue);
                        break;
                    case DataType.UShort:
                        WriteUShort(storeArea, start, setValue);
                        break;
                    case DataType.Int:
                        WriteInt(storeArea, start, setValue);
                        break;
                    case DataType.UInt:
                        WriteUInt(storeArea, start, setValue);
                        break;
                    case DataType.Float:
                        WriteFloat(storeArea, start, setValue);
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
        private void WriteBool(StoreArea storeArea, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出线圈0x:

                    bool[] values = BitLib.GetBitArrayFromBitArrayString(setValue);
                    if (values.Length == 1)
                    {
                        result = modbus.PreSetSingleCoil(start, values[0]);
                    }
                    else
                    {
                        result = modbus.PreSetMultiCoils(start, values);
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
                AddLog(1, "写入失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 写入byte
        private void WriteByte(StoreArea storeArea, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:
                    result = modbus.PreSetMultiRegisters(start, ByteArrayLib.GetByteArrayFromHexString(setValue));
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
                AddLog(1, "写入失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 写入short
        private void WriteShort(StoreArea storeArea, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:

                    short[] values = ShortLib.GetShortArrayFromString(setValue);

                    if (values.Length == 1)
                    {
                        result = modbus.PreSetSingleRegister(start, values[0]);
                    }
                    else
                    {
                        result = modbus.PreSetMultiRegisters(start, ByteArrayLib.GetByteArrayFromShortArray(values));
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
                AddLog(1, "写入失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 写入UShort
        private void WriteUShort(StoreArea storeArea, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:

                    ushort[] values = UShortLib.GetUShortArrayFromString(setValue);

                    if (values.Length == 1)
                    {
                        result = modbus.PreSetSingleRegister(start, values[0]);
                    }
                    else
                    {
                        result = modbus.PreSetMultiRegisters(start, ByteArrayLib.GetByteArrayFromUShortArray(values));
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
                AddLog(1, "写入失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 写入Int
        private void WriteInt(StoreArea storeArea, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:

                    int[] values = IntLib.GetIntArrayFromString(setValue);

                    result = modbus.PreSetMultiRegisters(start, ByteArrayLib.GetByteArrayFromIntArray(values));

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
                AddLog(1, "写入失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 写入UInt
        private void WriteUInt(StoreArea storeArea, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:

                    uint[] values = UIntLib.GetUIntArrayFromString(setValue);

                    result = modbus.PreSetMultiRegisters(start, ByteArrayLib.GetByteArrayFromUIntArray(values));

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
                AddLog(1, "写入失败：" + modbus.LastError);
            }
        }
        #endregion

        #region 写入Float
        private void WriteFloat(StoreArea storeArea, ushort start, string setValue)
        {
            bool result = false;

            switch (storeArea)
            {
                case StoreArea.输出寄存器4x:

                    float[] values = FloatLib.GetFloatArrayFromString(setValue);

                    result = modbus.PreSetMultiRegisters(start, ByteArrayLib.GetByteArrayFromFloatArray(values));

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
                AddLog(1, "写入失败：" + modbus.LastError);
            }
        }
        #endregion

    }
}
