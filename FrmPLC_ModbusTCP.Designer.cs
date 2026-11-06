namespace FrmModbusRTU
{
    partial class FrmPLC_ModbusTCP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            Port_txt = new TextBox();
            label1 = new Label();
            IP_txt = new TextBox();
            btn_Disconnect = new Button();
            btn_Connect = new Button();
            label4 = new Label();
            groupBox2 = new GroupBox();
            label23 = new Label();
            label22 = new Label();
            label21 = new Label();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBox3 = new GroupBox();
            label24 = new Label();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            label32 = new Label();
            label33 = new Label();
            label34 = new Label();
            label35 = new Label();
            label41 = new Label();
            label42 = new Label();
            label43 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Port_txt);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(IP_txt);
            groupBox1.Controls.Add(btn_Disconnect);
            groupBox1.Controls.Add(btn_Connect);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(12, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1033, 133);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "通讯参数";
            // 
            // Port_txt
            // 
            Port_txt.Location = new Point(407, 53);
            Port_txt.Name = "Port_txt";
            Port_txt.Size = new Size(114, 39);
            Port_txt.TabIndex = 21;
            Port_txt.Text = "502";
            Port_txt.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(293, 56);
            label1.Name = "label1";
            label1.Size = new Size(110, 31);
            label1.TabIndex = 20;
            label1.Text = "端口号：";
            // 
            // IP_txt
            // 
            IP_txt.Location = new Point(128, 53);
            IP_txt.Name = "IP_txt";
            IP_txt.Size = new Size(147, 39);
            IP_txt.TabIndex = 19;
            IP_txt.Text = "127.0.0.1";
            IP_txt.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_Disconnect
            // 
            btn_Disconnect.Location = new Point(741, 35);
            btn_Disconnect.Name = "btn_Disconnect";
            btn_Disconnect.Size = new Size(200, 72);
            btn_Disconnect.TabIndex = 13;
            btn_Disconnect.Text = "断开连接";
            btn_Disconnect.UseVisualStyleBackColor = true;
            btn_Disconnect.Click += btn_Disconnect_Click;
            // 
            // btn_Connect
            // 
            btn_Connect.Location = new Point(540, 35);
            btn_Connect.Name = "btn_Connect";
            btn_Connect.Size = new Size(186, 72);
            btn_Connect.TabIndex = 12;
            btn_Connect.Text = "建立连接";
            btn_Connect.UseVisualStyleBackColor = true;
            btn_Connect.Click += btn_Connect_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 56);
            label4.Name = "label4";
            label4.Size = new Size(108, 31);
            label4.TabIndex = 6;
            label4.Text = "IP地址：";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label23);
            groupBox2.Controls.Add(label22);
            groupBox2.Controls.Add(label21);
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 186);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1033, 271);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "读取的数据";
            // 
            // label23
            // 
            label23.BackColor = SystemColors.ButtonHighlight;
            label23.BorderStyle = BorderStyle.FixedSingle;
            label23.Location = new Point(617, 215);
            label23.Name = "label23";
            label23.Size = new Size(366, 31);
            label23.TabIndex = 25;
            label23.Text = "a";
            label23.TextAlign = ContentAlignment.TopCenter;
            // 
            // label22
            // 
            label22.BackColor = SystemColors.ButtonHighlight;
            label22.BorderStyle = BorderStyle.FixedSingle;
            label22.Location = new Point(203, 215);
            label22.Name = "label22";
            label22.Size = new Size(366, 31);
            label22.TabIndex = 24;
            label22.Text = "a";
            label22.TextAlign = ContentAlignment.TopCenter;
            // 
            // label21
            // 
            label21.BackColor = SystemColors.ButtonHighlight;
            label21.BorderStyle = BorderStyle.FixedSingle;
            label21.Location = new Point(849, 164);
            label21.Name = "label21";
            label21.Size = new Size(134, 31);
            label21.TabIndex = 23;
            label21.Text = "0.0";
            label21.TextAlign = ContentAlignment.TopCenter;
            // 
            // label20
            // 
            label20.BackColor = SystemColors.ButtonHighlight;
            label20.BorderStyle = BorderStyle.FixedSingle;
            label20.Location = new Point(688, 164);
            label20.Name = "label20";
            label20.Size = new Size(134, 31);
            label20.TabIndex = 22;
            label20.Text = "0.0";
            label20.TextAlign = ContentAlignment.TopCenter;
            // 
            // label19
            // 
            label19.BackColor = SystemColors.ButtonHighlight;
            label19.BorderStyle = BorderStyle.FixedSingle;
            label19.Location = new Point(524, 164);
            label19.Name = "label19";
            label19.Size = new Size(134, 31);
            label19.TabIndex = 21;
            label19.Text = "0.0";
            label19.TextAlign = ContentAlignment.TopCenter;
            // 
            // label18
            // 
            label18.BackColor = SystemColors.ButtonHighlight;
            label18.BorderStyle = BorderStyle.FixedSingle;
            label18.Location = new Point(358, 164);
            label18.Name = "label18";
            label18.Size = new Size(134, 31);
            label18.TabIndex = 20;
            label18.Text = "0.0";
            label18.TextAlign = ContentAlignment.TopCenter;
            // 
            // label17
            // 
            label17.BackColor = SystemColors.ButtonHighlight;
            label17.BorderStyle = BorderStyle.FixedSingle;
            label17.Location = new Point(203, 164);
            label17.Name = "label17";
            label17.Size = new Size(134, 31);
            label17.TabIndex = 19;
            label17.Text = "0.0";
            label17.TextAlign = ContentAlignment.TopCenter;
            // 
            // label16
            // 
            label16.BackColor = SystemColors.ButtonHighlight;
            label16.BorderStyle = BorderStyle.FixedSingle;
            label16.Location = new Point(849, 114);
            label16.Name = "label16";
            label16.Size = new Size(134, 31);
            label16.TabIndex = 18;
            label16.Text = "0";
            label16.TextAlign = ContentAlignment.TopCenter;
            // 
            // label15
            // 
            label15.BackColor = SystemColors.ButtonHighlight;
            label15.BorderStyle = BorderStyle.FixedSingle;
            label15.Location = new Point(688, 114);
            label15.Name = "label15";
            label15.Size = new Size(134, 31);
            label15.TabIndex = 17;
            label15.Text = "0";
            label15.TextAlign = ContentAlignment.TopCenter;
            // 
            // label14
            // 
            label14.BackColor = SystemColors.ButtonHighlight;
            label14.BorderStyle = BorderStyle.FixedSingle;
            label14.Location = new Point(524, 114);
            label14.Name = "label14";
            label14.Size = new Size(134, 31);
            label14.TabIndex = 16;
            label14.Text = "0";
            label14.TextAlign = ContentAlignment.TopCenter;
            // 
            // label13
            // 
            label13.BackColor = SystemColors.ButtonHighlight;
            label13.BorderStyle = BorderStyle.FixedSingle;
            label13.Location = new Point(358, 113);
            label13.Name = "label13";
            label13.Size = new Size(134, 31);
            label13.TabIndex = 15;
            label13.Text = "0";
            label13.TextAlign = ContentAlignment.TopCenter;
            // 
            // label12
            // 
            label12.BackColor = SystemColors.ButtonHighlight;
            label12.BorderStyle = BorderStyle.FixedSingle;
            label12.Location = new Point(203, 114);
            label12.Name = "label12";
            label12.Size = new Size(134, 31);
            label12.TabIndex = 14;
            label12.Text = "0";
            label12.TextAlign = ContentAlignment.TopCenter;
            // 
            // label11
            // 
            label11.BackColor = Color.Red;
            label11.BorderStyle = BorderStyle.FixedSingle;
            label11.Location = new Point(849, 58);
            label11.Name = "label11";
            label11.Size = new Size(134, 31);
            label11.TabIndex = 13;
            // 
            // label10
            // 
            label10.BackColor = Color.Red;
            label10.BorderStyle = BorderStyle.FixedSingle;
            label10.Location = new Point(524, 58);
            label10.Name = "label10";
            label10.Size = new Size(134, 31);
            label10.TabIndex = 12;
            // 
            // label9
            // 
            label9.BackColor = Color.Red;
            label9.BorderStyle = BorderStyle.FixedSingle;
            label9.Location = new Point(688, 58);
            label9.Name = "label9";
            label9.Size = new Size(134, 31);
            label9.TabIndex = 12;
            // 
            // label8
            // 
            label8.BackColor = Color.Red;
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Location = new Point(358, 58);
            label8.Name = "label8";
            label8.Size = new Size(134, 31);
            label8.TabIndex = 11;
            // 
            // label7
            // 
            label7.BackColor = Color.Red;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Location = new Point(203, 58);
            label7.Name = "label7";
            label7.Size = new Size(134, 31);
            label7.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 215);
            label6.Name = "label6";
            label6.Size = new Size(158, 31);
            label6.TabIndex = 9;
            label6.Text = "字符串数据：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 164);
            label5.Name = "label5";
            label5.Size = new Size(134, 31);
            label5.TabIndex = 8;
            label5.Text = "浮点数据：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 114);
            label2.Name = "label2";
            label2.Size = new Size(134, 31);
            label2.TabIndex = 7;
            label2.Text = "整形数据：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 58);
            label3.Name = "label3";
            label3.Size = new Size(134, 31);
            label3.TabIndex = 6;
            label3.Text = "布尔数据：";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label24);
            groupBox3.Controls.Add(label25);
            groupBox3.Controls.Add(label26);
            groupBox3.Controls.Add(label27);
            groupBox3.Controls.Add(label28);
            groupBox3.Controls.Add(label29);
            groupBox3.Controls.Add(label30);
            groupBox3.Controls.Add(label31);
            groupBox3.Controls.Add(label32);
            groupBox3.Controls.Add(label33);
            groupBox3.Controls.Add(label34);
            groupBox3.Controls.Add(label35);
            groupBox3.Controls.Add(label41);
            groupBox3.Controls.Add(label42);
            groupBox3.Controls.Add(label43);
            groupBox3.Location = new Point(12, 492);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1033, 206);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            groupBox3.Text = "写入数据";
            // 
            // label24
            // 
            label24.BackColor = SystemColors.ButtonHighlight;
            label24.BorderStyle = BorderStyle.FixedSingle;
            label24.Location = new Point(617, 150);
            label24.Name = "label24";
            label24.Size = new Size(366, 31);
            label24.TabIndex = 25;
            label24.Text = "a";
            label24.TextAlign = ContentAlignment.TopCenter;
            // 
            // label25
            // 
            label25.BackColor = SystemColors.ButtonHighlight;
            label25.BorderStyle = BorderStyle.FixedSingle;
            label25.Location = new Point(203, 150);
            label25.Name = "label25";
            label25.Size = new Size(366, 31);
            label25.TabIndex = 24;
            label25.Text = "a";
            label25.TextAlign = ContentAlignment.TopCenter;
            // 
            // label26
            // 
            label26.BackColor = SystemColors.ButtonHighlight;
            label26.BorderStyle = BorderStyle.FixedSingle;
            label26.Location = new Point(849, 99);
            label26.Name = "label26";
            label26.Size = new Size(134, 31);
            label26.TabIndex = 23;
            label26.Text = "0.0";
            label26.TextAlign = ContentAlignment.TopCenter;
            // 
            // label27
            // 
            label27.BackColor = SystemColors.ButtonHighlight;
            label27.BorderStyle = BorderStyle.FixedSingle;
            label27.Location = new Point(688, 99);
            label27.Name = "label27";
            label27.Size = new Size(134, 31);
            label27.TabIndex = 22;
            label27.Text = "0.0";
            label27.TextAlign = ContentAlignment.TopCenter;
            // 
            // label28
            // 
            label28.BackColor = SystemColors.ButtonHighlight;
            label28.BorderStyle = BorderStyle.FixedSingle;
            label28.Location = new Point(524, 99);
            label28.Name = "label28";
            label28.Size = new Size(134, 31);
            label28.TabIndex = 21;
            label28.Text = "0.0";
            label28.TextAlign = ContentAlignment.TopCenter;
            // 
            // label29
            // 
            label29.BackColor = SystemColors.ButtonHighlight;
            label29.BorderStyle = BorderStyle.FixedSingle;
            label29.Location = new Point(358, 99);
            label29.Name = "label29";
            label29.Size = new Size(134, 31);
            label29.TabIndex = 20;
            label29.Text = "0.0";
            label29.TextAlign = ContentAlignment.TopCenter;
            // 
            // label30
            // 
            label30.BackColor = SystemColors.ButtonHighlight;
            label30.BorderStyle = BorderStyle.FixedSingle;
            label30.Location = new Point(203, 99);
            label30.Name = "label30";
            label30.Size = new Size(134, 31);
            label30.TabIndex = 19;
            label30.Text = "0.0";
            label30.TextAlign = ContentAlignment.TopCenter;
            // 
            // label31
            // 
            label31.BackColor = SystemColors.ButtonHighlight;
            label31.BorderStyle = BorderStyle.FixedSingle;
            label31.Location = new Point(849, 49);
            label31.Name = "label31";
            label31.Size = new Size(134, 31);
            label31.TabIndex = 18;
            label31.Text = "0";
            label31.TextAlign = ContentAlignment.TopCenter;
            // 
            // label32
            // 
            label32.BackColor = SystemColors.ButtonHighlight;
            label32.BorderStyle = BorderStyle.FixedSingle;
            label32.Location = new Point(688, 49);
            label32.Name = "label32";
            label32.Size = new Size(134, 31);
            label32.TabIndex = 17;
            label32.Text = "0";
            label32.TextAlign = ContentAlignment.TopCenter;
            // 
            // label33
            // 
            label33.BackColor = SystemColors.ButtonHighlight;
            label33.BorderStyle = BorderStyle.FixedSingle;
            label33.Location = new Point(524, 49);
            label33.Name = "label33";
            label33.Size = new Size(134, 31);
            label33.TabIndex = 16;
            label33.Text = "0";
            label33.TextAlign = ContentAlignment.TopCenter;
            // 
            // label34
            // 
            label34.BackColor = SystemColors.ButtonHighlight;
            label34.BorderStyle = BorderStyle.FixedSingle;
            label34.Location = new Point(358, 48);
            label34.Name = "label34";
            label34.Size = new Size(134, 31);
            label34.TabIndex = 15;
            label34.Text = "0";
            label34.TextAlign = ContentAlignment.TopCenter;
            // 
            // label35
            // 
            label35.BackColor = SystemColors.ButtonHighlight;
            label35.BorderStyle = BorderStyle.FixedSingle;
            label35.Location = new Point(203, 49);
            label35.Name = "label35";
            label35.Size = new Size(134, 31);
            label35.TabIndex = 14;
            label35.Text = "0";
            label35.TextAlign = ContentAlignment.TopCenter;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new Point(14, 150);
            label41.Name = "label41";
            label41.Size = new Size(158, 31);
            label41.TabIndex = 9;
            label41.Text = "字符串数据：";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new Point(38, 99);
            label42.Name = "label42";
            label42.Size = new Size(134, 31);
            label42.TabIndex = 8;
            label42.Text = "浮点数据：";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Location = new Point(38, 49);
            label43.Name = "label43";
            label43.Size = new Size(134, 31);
            label43.TabIndex = 7;
            label43.Text = "整形数据：";
            // 
            // FrmPLC_ModbusTCP
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 1132);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Margin = new Padding(4);
            Name = "FrmPLC_ModbusTCP";
            Text = "FrmPLC_ModbusTCP";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox Port_txt;
        private Label label1;
        private TextBox IP_txt;
        private Button btn_Disconnect;
        private Button btn_Connect;
        private Label label4;
        private GroupBox groupBox2;
        private Label label3;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label2;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label23;
        private Label label22;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private GroupBox groupBox3;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label41;
        private Label label42;
        private Label label43;
    }
}