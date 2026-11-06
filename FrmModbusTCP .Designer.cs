namespace FrmModbusRTU
{
    partial class FrmModbusTCP
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModbusTCP));
            groupBox1 = new GroupBox();
            Port_txt = new TextBox();
            label1 = new Label();
            IP_txt = new TextBox();
            btn_Disconnect = new Button();
            btn_Connect = new Button();
            cmb_DataFormat = new ComboBox();
            label6 = new Label();
            label4 = new Label();
            groupBox2 = new GroupBox();
            txt_Slaveld = new TextBox();
            lts_unfo = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            imageList1 = new ImageList(components);
            label13 = new Label();
            btn_Write = new Button();
            btn_Read = new Button();
            txt_WriteValue = new TextBox();
            txt_Length = new TextBox();
            txt_Start = new TextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            cmb_DataTypc = new ComboBox();
            label9 = new Label();
            cmb_StoreArea = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txt_Slaveld);
            groupBox1.Controls.Add(Port_txt);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(IP_txt);
            groupBox1.Controls.Add(btn_Disconnect);
            groupBox1.Controls.Add(btn_Connect);
            groupBox1.Controls.Add(cmb_DataFormat);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label7);
            groupBox1.Location = new Point(12, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1134, 234);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "通讯参数";
            // 
            // Port_txt
            // 
            Port_txt.Location = new Point(506, 53);
            Port_txt.Name = "Port_txt";
            Port_txt.Size = new Size(188, 39);
            Port_txt.TabIndex = 21;
            Port_txt.Text = "502";
            Port_txt.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(392, 56);
            label1.Name = "label1";
            label1.Size = new Size(110, 31);
            label1.TabIndex = 20;
            label1.Text = "端口号：";
            // 
            // IP_txt
            // 
            IP_txt.Location = new Point(144, 53);
            IP_txt.Name = "IP_txt";
            IP_txt.Size = new Size(188, 39);
            IP_txt.TabIndex = 19;
            IP_txt.Text = "127.0.0.1";
            IP_txt.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_Disconnect
            // 
            btn_Disconnect.Location = new Point(886, 127);
            btn_Disconnect.Name = "btn_Disconnect";
            btn_Disconnect.Size = new Size(200, 72);
            btn_Disconnect.TabIndex = 13;
            btn_Disconnect.Text = "断开连接";
            btn_Disconnect.UseVisualStyleBackColor = true;
            btn_Disconnect.Click += btn_Disconnect_Click;
            // 
            // btn_Connect
            // 
            btn_Connect.Location = new Point(627, 127);
            btn_Connect.Name = "btn_Connect";
            btn_Connect.Size = new Size(186, 72);
            btn_Connect.TabIndex = 12;
            btn_Connect.Text = "建立连接";
            btn_Connect.UseVisualStyleBackColor = true;
            btn_Connect.Click += btn_Connect_Click;
            // 
            // cmb_DataFormat
            // 
            cmb_DataFormat.FormattingEnabled = true;
            cmb_DataFormat.Location = new Point(138, 124);
            cmb_DataFormat.Name = "cmb_DataFormat";
            cmb_DataFormat.Size = new Size(132, 39);
            cmb_DataFormat.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 127);
            label6.Name = "label6";
            label6.Size = new Size(110, 31);
            label6.TabIndex = 10;
            label6.Text = "大小端：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 56);
            label4.Name = "label4";
            label4.Size = new Size(108, 31);
            label4.TabIndex = 6;
            label4.Text = "IP地址：";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lts_unfo);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(btn_Write);
            groupBox2.Controls.Add(btn_Read);
            groupBox2.Controls.Add(txt_WriteValue);
            groupBox2.Controls.Add(txt_Length);
            groupBox2.Controls.Add(txt_Start);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(cmb_DataTypc);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(cmb_StoreArea);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(12, 271);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1134, 870);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "读写测试";
            // 
            // txt_Slaveld
            // 
            txt_Slaveld.Location = new Point(444, 124);
            txt_Slaveld.Name = "txt_Slaveld";
            txt_Slaveld.Size = new Size(150, 39);
            txt_Slaveld.TabIndex = 18;
            txt_Slaveld.Text = "1";
            txt_Slaveld.TextAlign = HorizontalAlignment.Center;
            // 
            // lts_unfo
            // 
            lts_unfo.BackColor = SystemColors.Control;
            lts_unfo.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lts_unfo.HeaderStyle = ColumnHeaderStyle.None;
            lts_unfo.Location = new Point(30, 349);
            lts_unfo.MultiSelect = false;
            lts_unfo.Name = "lts_unfo";
            lts_unfo.ShowItemToolTips = true;
            lts_unfo.Size = new Size(1056, 500);
            lts_unfo.SmallImageList = imageList1;
            lts_unfo.TabIndex = 17;
            lts_unfo.UseCompatibleStateImageBehavior = false;
            lts_unfo.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "日期时间";
            columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "信息类容";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "info.ico");
            imageList1.Images.SetKeyName(1, "warring.ico");
            imageList1.Images.SetKeyName(2, "error.ico");
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(30, 290);
            label13.Name = "label13";
            label13.Size = new Size(110, 31);
            label13.TabIndex = 16;
            label13.Text = "读取信息";
            // 
            // btn_Write
            // 
            btn_Write.Location = new Point(900, 206);
            btn_Write.Name = "btn_Write";
            btn_Write.Size = new Size(186, 72);
            btn_Write.TabIndex = 15;
            btn_Write.Text = "写入";
            btn_Write.UseVisualStyleBackColor = true;
            btn_Write.Click += btn_Write_Click;
            // 
            // btn_Read
            // 
            btn_Read.Location = new Point(900, 110);
            btn_Read.Name = "btn_Read";
            btn_Read.Size = new Size(186, 72);
            btn_Read.TabIndex = 14;
            btn_Read.Text = "读取";
            btn_Read.UseVisualStyleBackColor = true;
            btn_Read.Click += btn_Read_Click;
            // 
            // txt_WriteValue
            // 
            txt_WriteValue.Location = new Point(314, 194);
            txt_WriteValue.Name = "txt_WriteValue";
            txt_WriteValue.Size = new Size(478, 39);
            txt_WriteValue.TabIndex = 14;
            txt_WriteValue.Text = "1 1 1 1";
            // 
            // txt_Length
            // 
            txt_Length.Location = new Point(531, 120);
            txt_Length.Name = "txt_Length";
            txt_Length.Size = new Size(182, 39);
            txt_Length.TabIndex = 13;
            txt_Length.Text = "10";
            txt_Length.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_Start
            // 
            txt_Start.Location = new Point(164, 120);
            txt_Start.Name = "txt_Start";
            txt_Start.Size = new Size(150, 39);
            txt_Start.TabIndex = 12;
            txt_Start.Text = "0";
            txt_Start.TextAlign = HorizontalAlignment.Center;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(30, 197);
            label12.Name = "label12";
            label12.Size = new Size(278, 31);
            label12.TabIndex = 10;
            label12.Text = "写入数据（空格分隔）：";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(384, 125);
            label11.Name = "label11";
            label11.Size = new Size(134, 31);
            label11.TabIndex = 8;
            label11.Text = "读取长度：";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(24, 125);
            label10.Name = "label10";
            label10.Size = new Size(134, 31);
            label10.TabIndex = 6;
            label10.Text = "起始地址：";
            // 
            // cmb_DataTypc
            // 
            cmb_DataTypc.FormattingEnabled = true;
            cmb_DataTypc.Location = new Point(900, 51);
            cmb_DataTypc.Name = "cmb_DataTypc";
            cmb_DataTypc.Size = new Size(182, 39);
            cmb_DataTypc.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(760, 54);
            label9.Name = "label9";
            label9.Size = new Size(134, 31);
            label9.TabIndex = 4;
            label9.Text = "数据类型：";
            // 
            // cmb_StoreArea
            // 
            cmb_StoreArea.FormattingEnabled = true;
            cmb_StoreArea.Location = new Point(531, 51);
            cmb_StoreArea.Name = "cmb_StoreArea";
            cmb_StoreArea.Size = new Size(182, 39);
            cmb_StoreArea.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(384, 54);
            label8.Name = "label8";
            label8.Size = new Size(110, 31);
            label8.TabIndex = 2;
            label8.Text = "存储区：";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(304, 127);
            label7.Name = "label7";
            label7.Size = new Size(134, 31);
            label7.TabIndex = 0;
            label7.Text = "从站地址：";
            // 
            // FrmModbusTCP
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 1193);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "FrmModbusTCP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ModbusRtu通讯测试";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_Disconnect;
        private Button btn_Connect;
        private ComboBox cmb_DataFormat;
        private Label label6;
        private ComboBox cmb_StopBits;
        private Label label5;
        private ComboBox cmb_BaudRate;
        private Label label4;
        private ComboBox cmb_Parity;
        private Label label3;
        private ComboBox cmb_Port;
        private Label label2;
        private ComboBox cmb_DataBits;
        private Label label1;
        private GroupBox groupBox2;
        private Label label8;
        private Label label7;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox txt_WriteValue;
        private TextBox txt_Length;
        private TextBox txt_Start;
        private ListView lts_unfo;
        private Label label13;
        private Button btn_Write;
        private Button btn_Read;
        private ImageList imageList1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private TextBox txt_Slaveld;
        private ComboBox cmb_DataTypc;
        private ComboBox cmb_StoreArea;
        private TextBox Port_txt;
        private TextBox IP_txt;
    }
}
