namespace FrmModbusRTU
{
    partial class FrmCollector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCollector));
            groupBox1 = new GroupBox();
            btn_Disconnect = new Button();
            btn_Connect = new Button();
            cmb_BaudRate = new ComboBox();
            cmb_Port = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            imageList1 = new ImageList(components);
            label13 = new Label();
            lts_unfo = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            groupBox2 = new GroupBox();
            txtDisplay2 = new TextBox();
            txtDisplay1 = new TextBox();
            label6 = new Label();
            label1 = new Label();
            groupBox3 = new GroupBox();
            txtDisplay4 = new TextBox();
            txtDisplay3 = new TextBox();
            label2 = new Label();
            label5 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_Disconnect);
            groupBox1.Controls.Add(btn_Connect);
            groupBox1.Controls.Add(cmb_BaudRate);
            groupBox1.Controls.Add(cmb_Port);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1134, 140);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "通讯参数";
            // 
            // btn_Disconnect
            // 
            btn_Disconnect.Location = new Point(866, 35);
            btn_Disconnect.Name = "btn_Disconnect";
            btn_Disconnect.Size = new Size(200, 72);
            btn_Disconnect.TabIndex = 13;
            btn_Disconnect.Text = "断开连接";
            btn_Disconnect.UseVisualStyleBackColor = true;
            btn_Disconnect.Click += btn_Disconnect_Click;
            // 
            // btn_Connect
            // 
            btn_Connect.Location = new Point(607, 35);
            btn_Connect.Name = "btn_Connect";
            btn_Connect.Size = new Size(186, 72);
            btn_Connect.TabIndex = 12;
            btn_Connect.Text = "建立连接";
            btn_Connect.UseVisualStyleBackColor = true;
            btn_Connect.Click += btn_Connect_Click;
            // 
            // cmb_BaudRate
            // 
            cmb_BaudRate.FormattingEnabled = true;
            cmb_BaudRate.Location = new Point(408, 53);
            cmb_BaudRate.Name = "cmb_BaudRate";
            cmb_BaudRate.Size = new Size(132, 39);
            cmb_BaudRate.TabIndex = 7;
            // 
            // cmb_Port
            // 
            cmb_Port.FormattingEnabled = true;
            cmb_Port.Location = new Point(135, 53);
            cmb_Port.Name = "cmb_Port";
            cmb_Port.Size = new Size(132, 39);
            cmb_Port.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 56);
            label4.Name = "label4";
            label4.Size = new Size(110, 31);
            label4.TabIndex = 6;
            label4.Text = "端口号：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(300, 56);
            label3.Name = "label3";
            label3.Size = new Size(110, 31);
            label3.TabIndex = 4;
            label3.Text = "波特率：";
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
            label13.Location = new Point(42, 420);
            label13.Name = "label13";
            label13.Size = new Size(110, 31);
            label13.TabIndex = 17;
            label13.Text = "读取信息";
            // 
            // lts_unfo
            // 
            lts_unfo.BackColor = SystemColors.Control;
            lts_unfo.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lts_unfo.HeaderStyle = ColumnHeaderStyle.None;
            lts_unfo.Location = new Point(42, 454);
            lts_unfo.MultiSelect = false;
            lts_unfo.Name = "lts_unfo";
            lts_unfo.ShowItemToolTips = true;
            lts_unfo.Size = new Size(1056, 500);
            lts_unfo.SmallImageList = imageList1;
            lts_unfo.TabIndex = 19;
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
            // groupBox2
            // 
            groupBox2.Controls.Add(txtDisplay2);
            groupBox2.Controls.Add(txtDisplay1);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(42, 176);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(311, 241);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "模块1";
            // 
            // txtDisplay2
            // 
            txtDisplay2.Location = new Point(94, 107);
            txtDisplay2.Multiline = true;
            txtDisplay2.Name = "txtDisplay2";
            txtDisplay2.Size = new Size(187, 37);
            txtDisplay2.TabIndex = 22;
            txtDisplay2.Text = "0.0";
            txtDisplay2.TextAlign = HorizontalAlignment.Center;
            // 
            // txtDisplay1
            // 
            txtDisplay1.Location = new Point(94, 29);
            txtDisplay1.Multiline = true;
            txtDisplay1.Name = "txtDisplay1";
            txtDisplay1.Size = new Size(187, 37);
            txtDisplay1.TabIndex = 21;
            txtDisplay1.Text = "0.0";
            txtDisplay1.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 110);
            label6.Name = "label6";
            label6.Size = new Size(100, 31);
            label6.TabIndex = 16;
            label6.Text = "数据2：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 35);
            label1.Name = "label1";
            label1.Size = new Size(100, 31);
            label1.TabIndex = 14;
            label1.Text = "数据1：";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtDisplay4);
            groupBox3.Controls.Add(txtDisplay3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label5);
            groupBox3.Location = new Point(392, 176);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(311, 241);
            groupBox3.TabIndex = 23;
            groupBox3.TabStop = false;
            groupBox3.Text = "模块1";
            // 
            // txtDisplay4
            // 
            txtDisplay4.Location = new Point(94, 107);
            txtDisplay4.Multiline = true;
            txtDisplay4.Name = "txtDisplay4";
            txtDisplay4.Size = new Size(187, 37);
            txtDisplay4.TabIndex = 22;
            txtDisplay4.Text = "0.0";
            txtDisplay4.TextAlign = HorizontalAlignment.Center;
            // 
            // txtDisplay3
            // 
            txtDisplay3.Location = new Point(94, 29);
            txtDisplay3.Multiline = true;
            txtDisplay3.Name = "txtDisplay3";
            txtDisplay3.Size = new Size(187, 37);
            txtDisplay3.TabIndex = 21;
            txtDisplay3.Text = "0.0";
            txtDisplay3.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 110);
            label2.Name = "label2";
            label2.Size = new Size(100, 31);
            label2.TabIndex = 16;
            label2.Text = "数据2：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 35);
            label5.Name = "label5";
            label5.Size = new Size(100, 31);
            label5.TabIndex = 14;
            label5.Text = "数据1：";
            // 
            // FrmCollector
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 980);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(lts_unfo);
            Controls.Add(label13);
            Controls.Add(groupBox1);
            Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "FrmCollector";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ModbusRtu数据采集测试";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_Disconnect;
        private Button btn_Connect;
        private ComboBox cmb_BaudRate;
        private Label label4;
        private Label label3;
        private ComboBox cmb_Port;
        private ImageList imageList1;
        private Label label13;
        private ListView lts_unfo;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private GroupBox groupBox2;
        private Label label1;
        private Label label6;
        private TextBox txtDisplay1;
        private TextBox txtDisplay2;
        private GroupBox groupBox3;
        private TextBox txtDisplay4;
        private TextBox txtDisplay3;
        private Label label2;
        private Label label5;
    }
}
