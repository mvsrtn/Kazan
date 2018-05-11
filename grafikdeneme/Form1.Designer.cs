using System;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace grafikdeneme
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.randomData = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cb_max_1 = new System.Windows.Forms.CheckBox();
            this.cb_min_1 = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label_testsuresi = new System.Windows.Forms.Label();
            this.cb_zamanayarlandı = new System.Windows.Forms.CheckBox();
            this.b_setzaman = new System.Windows.Forms.Button();
            this.tb_ZamanYukle = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.DirencliAyirici = new System.Windows.Forms.Button();
            this.TopraklıAyirici = new System.Windows.Forms.Button();
            this.DirencliOn = new System.Windows.Forms.Button();
            this.ToprakliOn = new System.Windows.Forms.Button();
            this.DirencliOff = new System.Windows.Forms.Button();
            this.ToprakliOff = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Kesici_3 = new System.Windows.Forms.Button();
            this.Kesici_2 = new System.Windows.Forms.Button();
            this.Kesici_3_On = new System.Windows.Forms.Button();
            this.Kesici_2_On = new System.Windows.Forms.Button();
            this.Kesici_1_On = new System.Windows.Forms.Button();
            this.Kesici_3_Off = new System.Windows.Forms.Button();
            this.Kesici_2_Off = new System.Windows.Forms.Button();
            this.Kesici_1_Off = new System.Windows.Forms.Button();
            this.Kesici_1 = new System.Windows.Forms.Button();
            this.TesteBasla = new System.Windows.Forms.Button();
            this.TestiDurdur = new System.Windows.Forms.Button();
            this.Zeroize_1 = new System.Windows.Forms.Button();
            this.tb_max_1 = new System.Windows.Forms.TextBox();
            this.label_max_1 = new System.Windows.Forms.Label();
            this.tb_min_1 = new System.Windows.Forms.TextBox();
            this.UpdataLimits_1 = new System.Windows.Forms.Button();
            this.label_min_1 = new System.Windows.Forms.Label();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_I3_peak = new System.Windows.Forms.TextBox();
            this.tb_I3_rms = new System.Windows.Forms.TextBox();
            this.tb_I2_peak = new System.Windows.Forms.TextBox();
            this.tb_I2_rms = new System.Windows.Forms.TextBox();
            this.Tb_ch3_I2t = new System.Windows.Forms.TextBox();
            this.Tb_ch2_I2t = new System.Windows.Forms.TextBox();
            this.Tb_ch1_I2t = new System.Windows.Forms.TextBox();
            this.tb_I1_peak = new System.Windows.Forms.TextBox();
            this.tb_I1_rms = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Tb_olcum_araligi = new System.Windows.Forms.TextBox();
            this.Tb_son_ms = new System.Windows.Forms.TextBox();
            this.Tb_ilk_ms = new System.Windows.Forms.TextBox();
            this.GraphStart = new System.Windows.Forms.TextBox();
            this.Tb_A_div = new System.Windows.Forms.TextBox();
            this.Tb_v_div = new System.Windows.Forms.TextBox();
            this.Tb_ms_div = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Rb_100A = new System.Windows.Forms.RadioButton();
            this.Rb_500A = new System.Windows.Forms.RadioButton();
            this.Rb_2kA = new System.Windows.Forms.RadioButton();
            this.Rb_5kA = new System.Windows.Forms.RadioButton();
            this.Rb_10kA = new System.Windows.Forms.RadioButton();
            this.Rb_50kA = new System.Windows.Forms.RadioButton();
            this.Rb_120kA = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sp = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // randomData
            // 
            this.randomData.Location = new System.Drawing.Point(3, 365);
            this.randomData.Name = "randomData";
            this.randomData.Size = new System.Drawing.Size(150, 34);
            this.randomData.TabIndex = 1;
            this.randomData.Text = "randomData";
            this.randomData.UseVisualStyleBackColor = true;
            this.randomData.Click += new System.EventHandler(this.RandomData_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(1, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 570);
            this.panel1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartMain, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(791, 570);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cb_max_1);
            this.panel2.Controls.Add(this.cb_min_1);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.Zeroize_1);
            this.panel2.Controls.Add(this.tb_max_1);
            this.panel2.Controls.Add(this.label_max_1);
            this.panel2.Controls.Add(this.tb_min_1);
            this.panel2.Controls.Add(this.UpdataLimits_1);
            this.panel2.Controls.Add(this.label_min_1);
            this.panel2.Location = new System.Drawing.Point(609, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 564);
            this.panel2.TabIndex = 8;
            this.panel2.Visible = false;
            // 
            // cb_max_1
            // 
            this.cb_max_1.AutoSize = true;
            this.cb_max_1.Location = new System.Drawing.Point(10, 52);
            this.cb_max_1.Name = "cb_max_1";
            this.cb_max_1.Size = new System.Drawing.Size(15, 14);
            this.cb_max_1.TabIndex = 4;
            this.cb_max_1.UseVisualStyleBackColor = true;
            this.cb_max_1.CheckedChanged += new System.EventHandler(this.Cb_max_1_CheckedChanged);
            // 
            // cb_min_1
            // 
            this.cb_min_1.AutoSize = true;
            this.cb_min_1.Location = new System.Drawing.Point(10, 16);
            this.cb_min_1.Name = "cb_min_1";
            this.cb_min_1.Size = new System.Drawing.Size(15, 14);
            this.cb_min_1.TabIndex = 4;
            this.cb_min_1.UseVisualStyleBackColor = true;
            this.cb_min_1.CheckedChanged += new System.EventHandler(this.Cb_min_1_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label_testsuresi);
            this.panel5.Controls.Add(this.cb_zamanayarlandı);
            this.panel5.Controls.Add(this.b_setzaman);
            this.panel5.Controls.Add(this.tb_ZamanYukle);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.TesteBasla);
            this.panel5.Controls.Add(this.TestiDurdur);
            this.panel5.Controls.Add(this.randomData);
            this.panel5.Location = new System.Drawing.Point(7, 163);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(166, 431);
            this.panel5.TabIndex = 5;
            // 
            // label_testsuresi
            // 
            this.label_testsuresi.AutoSize = true;
            this.label_testsuresi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_testsuresi.Location = new System.Drawing.Point(29, 7);
            this.label_testsuresi.Name = "label_testsuresi";
            this.label_testsuresi.Size = new System.Drawing.Size(89, 20);
            this.label_testsuresi.TabIndex = 6;
            this.label_testsuresi.Text = "Test Süresi";
            // 
            // cb_zamanayarlandı
            // 
            this.cb_zamanayarlandı.AutoSize = true;
            this.cb_zamanayarlandı.Enabled = false;
            this.cb_zamanayarlandı.Location = new System.Drawing.Point(132, 32);
            this.cb_zamanayarlandı.Name = "cb_zamanayarlandı";
            this.cb_zamanayarlandı.Size = new System.Drawing.Size(15, 14);
            this.cb_zamanayarlandı.TabIndex = 5;
            this.cb_zamanayarlandı.UseVisualStyleBackColor = true;
            // 
            // b_setzaman
            // 
            this.b_setzaman.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.b_setzaman.Location = new System.Drawing.Point(62, 29);
            this.b_setzaman.Name = "b_setzaman";
            this.b_setzaman.Size = new System.Drawing.Size(65, 20);
            this.b_setzaman.TabIndex = 4;
            this.b_setzaman.Text = "Gönder";
            this.b_setzaman.UseVisualStyleBackColor = true;
            this.b_setzaman.Click += new System.EventHandler(this.B_setzaman_Click);
            // 
            // tb_ZamanYukle
            // 
            this.tb_ZamanYukle.Location = new System.Drawing.Point(5, 30);
            this.tb_ZamanYukle.Name = "tb_ZamanYukle";
            this.tb_ZamanYukle.Size = new System.Drawing.Size(51, 20);
            this.tb_ZamanYukle.TabIndex = 3;
            this.tb_ZamanYukle.TextChanged += new System.EventHandler(this.Tb_ZamanYukle_TextChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.DirencliAyirici);
            this.panel7.Controls.Add(this.TopraklıAyirici);
            this.panel7.Controls.Add(this.DirencliOn);
            this.panel7.Controls.Add(this.ToprakliOn);
            this.panel7.Controls.Add(this.DirencliOff);
            this.panel7.Controls.Add(this.ToprakliOff);
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel7.Location = new System.Drawing.Point(5, 191);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(150, 88);
            this.panel7.TabIndex = 2;
            // 
            // DirencliAyirici
            // 
            this.DirencliAyirici.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DirencliAyirici.Location = new System.Drawing.Point(50, 45);
            this.DirencliAyirici.Name = "DirencliAyirici";
            this.DirencliAyirici.Size = new System.Drawing.Size(50, 34);
            this.DirencliAyirici.TabIndex = 0;
            this.DirencliAyirici.Text = "Dirençli Ayırıcı";
            this.DirencliAyirici.UseVisualStyleBackColor = true;
            this.DirencliAyirici.Click += new System.EventHandler(this.Kesici_2_B_Click);
            // 
            // TopraklıAyirici
            // 
            this.TopraklıAyirici.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TopraklıAyirici.Location = new System.Drawing.Point(50, 5);
            this.TopraklıAyirici.Name = "TopraklıAyirici";
            this.TopraklıAyirici.Size = new System.Drawing.Size(50, 34);
            this.TopraklıAyirici.TabIndex = 0;
            this.TopraklıAyirici.Text = "Topraklı Ayırıcı";
            this.TopraklıAyirici.UseVisualStyleBackColor = true;
            this.TopraklıAyirici.Click += new System.EventHandler(this.Kesici_2_A_Click);
            // 
            // DirencliOn
            // 
            this.DirencliOn.BackColor = System.Drawing.SystemColors.Control;
            this.DirencliOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DirencliOn.Location = new System.Drawing.Point(0, 45);
            this.DirencliOn.Name = "DirencliOn";
            this.DirencliOn.Size = new System.Drawing.Size(50, 34);
            this.DirencliOn.TabIndex = 0;
            this.DirencliOn.Text = "ON";
            this.DirencliOn.UseVisualStyleBackColor = false;
            this.DirencliOn.Click += new System.EventHandler(this.DirencliOn_Click);
            // 
            // ToprakliOn
            // 
            this.ToprakliOn.BackColor = System.Drawing.SystemColors.Control;
            this.ToprakliOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ToprakliOn.Location = new System.Drawing.Point(0, 5);
            this.ToprakliOn.Name = "ToprakliOn";
            this.ToprakliOn.Size = new System.Drawing.Size(50, 34);
            this.ToprakliOn.TabIndex = 0;
            this.ToprakliOn.Text = "ON";
            this.ToprakliOn.UseVisualStyleBackColor = false;
            this.ToprakliOn.Click += new System.EventHandler(this.ToprakliOn_Click);
            // 
            // DirencliOff
            // 
            this.DirencliOff.BackColor = System.Drawing.SystemColors.Control;
            this.DirencliOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DirencliOff.Location = new System.Drawing.Point(100, 45);
            this.DirencliOff.Name = "DirencliOff";
            this.DirencliOff.Size = new System.Drawing.Size(50, 34);
            this.DirencliOff.TabIndex = 0;
            this.DirencliOff.Text = "OFF";
            this.DirencliOff.UseVisualStyleBackColor = false;
            this.DirencliOff.Click += new System.EventHandler(this.DirencliOff_Click);
            // 
            // ToprakliOff
            // 
            this.ToprakliOff.BackColor = System.Drawing.SystemColors.Control;
            this.ToprakliOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ToprakliOff.Location = new System.Drawing.Point(100, 5);
            this.ToprakliOff.Name = "ToprakliOff";
            this.ToprakliOff.Size = new System.Drawing.Size(50, 34);
            this.ToprakliOff.TabIndex = 0;
            this.ToprakliOff.Text = "OFF";
            this.ToprakliOff.UseVisualStyleBackColor = false;
            this.ToprakliOff.Click += new System.EventHandler(this.ToprakliOff_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.Kesici_3);
            this.panel6.Controls.Add(this.Kesici_2);
            this.panel6.Controls.Add(this.Kesici_3_On);
            this.panel6.Controls.Add(this.Kesici_2_On);
            this.panel6.Controls.Add(this.Kesici_1_On);
            this.panel6.Controls.Add(this.Kesici_3_Off);
            this.panel6.Controls.Add(this.Kesici_2_Off);
            this.panel6.Controls.Add(this.Kesici_1_Off);
            this.panel6.Controls.Add(this.Kesici_1);
            this.panel6.Location = new System.Drawing.Point(5, 56);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(150, 132);
            this.panel6.TabIndex = 2;
            // 
            // Kesici_3
            // 
            this.Kesici_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesici_3.Location = new System.Drawing.Point(50, 85);
            this.Kesici_3.Name = "Kesici_3";
            this.Kesici_3.Size = new System.Drawing.Size(50, 34);
            this.Kesici_3.TabIndex = 0;
            this.Kesici_3.Text = "Kesici 3";
            this.Kesici_3.UseVisualStyleBackColor = true;
            // 
            // Kesici_2
            // 
            this.Kesici_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesici_2.Location = new System.Drawing.Point(50, 45);
            this.Kesici_2.Name = "Kesici_2";
            this.Kesici_2.Size = new System.Drawing.Size(50, 34);
            this.Kesici_2.TabIndex = 0;
            this.Kesici_2.Text = "Kesici 2";
            this.Kesici_2.UseVisualStyleBackColor = true;
            // 
            // Kesici_3_On
            // 
            this.Kesici_3_On.BackColor = System.Drawing.SystemColors.Control;
            this.Kesici_3_On.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesici_3_On.Location = new System.Drawing.Point(0, 85);
            this.Kesici_3_On.Name = "Kesici_3_On";
            this.Kesici_3_On.Size = new System.Drawing.Size(50, 34);
            this.Kesici_3_On.TabIndex = 0;
            this.Kesici_3_On.Text = "ON";
            this.Kesici_3_On.UseVisualStyleBackColor = false;
            this.Kesici_3_On.Click += new System.EventHandler(this.Kesici_3_On_Click);
            // 
            // Kesici_2_On
            // 
            this.Kesici_2_On.BackColor = System.Drawing.SystemColors.Control;
            this.Kesici_2_On.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesici_2_On.Location = new System.Drawing.Point(0, 45);
            this.Kesici_2_On.Name = "Kesici_2_On";
            this.Kesici_2_On.Size = new System.Drawing.Size(50, 34);
            this.Kesici_2_On.TabIndex = 0;
            this.Kesici_2_On.Text = "ON";
            this.Kesici_2_On.UseVisualStyleBackColor = false;
            this.Kesici_2_On.Click += new System.EventHandler(this.Kesici_2_On_Click);
            // 
            // Kesici_1_On
            // 
            this.Kesici_1_On.BackColor = System.Drawing.SystemColors.Control;
            this.Kesici_1_On.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesici_1_On.Location = new System.Drawing.Point(0, 5);
            this.Kesici_1_On.Name = "Kesici_1_On";
            this.Kesici_1_On.Size = new System.Drawing.Size(50, 34);
            this.Kesici_1_On.TabIndex = 0;
            this.Kesici_1_On.Text = "ON";
            this.Kesici_1_On.UseVisualStyleBackColor = false;
            this.Kesici_1_On.Click += new System.EventHandler(this.Kesici_1_On_Click);
            // 
            // Kesici_3_Off
            // 
            this.Kesici_3_Off.BackColor = System.Drawing.SystemColors.Control;
            this.Kesici_3_Off.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesici_3_Off.Location = new System.Drawing.Point(100, 85);
            this.Kesici_3_Off.Name = "Kesici_3_Off";
            this.Kesici_3_Off.Size = new System.Drawing.Size(50, 34);
            this.Kesici_3_Off.TabIndex = 0;
            this.Kesici_3_Off.Text = "OFF";
            this.Kesici_3_Off.UseVisualStyleBackColor = false;
            this.Kesici_3_Off.Click += new System.EventHandler(this.Kesici_3_Off_Click);
            // 
            // Kesici_2_Off
            // 
            this.Kesici_2_Off.BackColor = System.Drawing.SystemColors.Control;
            this.Kesici_2_Off.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesici_2_Off.Location = new System.Drawing.Point(100, 45);
            this.Kesici_2_Off.Name = "Kesici_2_Off";
            this.Kesici_2_Off.Size = new System.Drawing.Size(50, 34);
            this.Kesici_2_Off.TabIndex = 0;
            this.Kesici_2_Off.Text = "OFF";
            this.Kesici_2_Off.UseVisualStyleBackColor = false;
            this.Kesici_2_Off.Click += new System.EventHandler(this.Kesici_2_Off_Click);
            // 
            // Kesici_1_Off
            // 
            this.Kesici_1_Off.BackColor = System.Drawing.SystemColors.Control;
            this.Kesici_1_Off.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesici_1_Off.Location = new System.Drawing.Point(100, 5);
            this.Kesici_1_Off.Name = "Kesici_1_Off";
            this.Kesici_1_Off.Size = new System.Drawing.Size(50, 34);
            this.Kesici_1_Off.TabIndex = 0;
            this.Kesici_1_Off.Text = "OFF";
            this.Kesici_1_Off.UseVisualStyleBackColor = false;
            this.Kesici_1_Off.Click += new System.EventHandler(this.Kesici_1_Off_Click);
            // 
            // Kesici_1
            // 
            this.Kesici_1.BackColor = System.Drawing.SystemColors.Control;
            this.Kesici_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesici_1.Location = new System.Drawing.Point(50, 5);
            this.Kesici_1.Name = "Kesici_1";
            this.Kesici_1.Size = new System.Drawing.Size(50, 34);
            this.Kesici_1.TabIndex = 0;
            this.Kesici_1.Text = "Kesici 1";
            this.Kesici_1.UseVisualStyleBackColor = false;
            // 
            // TesteBasla
            // 
            this.TesteBasla.Location = new System.Drawing.Point(5, 285);
            this.TesteBasla.Name = "TesteBasla";
            this.TesteBasla.Size = new System.Drawing.Size(150, 34);
            this.TesteBasla.TabIndex = 1;
            this.TesteBasla.Text = "Teste Başla";
            this.TesteBasla.UseVisualStyleBackColor = true;
            this.TesteBasla.Click += new System.EventHandler(this.TesteBasla_Click);
            // 
            // TestiDurdur
            // 
            this.TestiDurdur.Location = new System.Drawing.Point(3, 325);
            this.TestiDurdur.Name = "TestiDurdur";
            this.TestiDurdur.Size = new System.Drawing.Size(150, 34);
            this.TestiDurdur.TabIndex = 1;
            this.TestiDurdur.Text = "Testi Durdur";
            this.TestiDurdur.UseVisualStyleBackColor = true;
            this.TestiDurdur.Click += new System.EventHandler(this.TestiDurdur_Click);
            // 
            // Zeroize_1
            // 
            this.Zeroize_1.Location = new System.Drawing.Point(7, 123);
            this.Zeroize_1.Name = "Zeroize_1";
            this.Zeroize_1.Size = new System.Drawing.Size(166, 34);
            this.Zeroize_1.TabIndex = 1;
            this.Zeroize_1.Text = "Zeroize";
            this.Zeroize_1.UseVisualStyleBackColor = true;
            this.Zeroize_1.Click += new System.EventHandler(this.Zeroize_1_Click);
            // 
            // tb_max_1
            // 
            this.tb_max_1.Location = new System.Drawing.Point(72, 49);
            this.tb_max_1.Name = "tb_max_1";
            this.tb_max_1.Size = new System.Drawing.Size(98, 20);
            this.tb_max_1.TabIndex = 2;
            // 
            // label_max_1
            // 
            this.label_max_1.AutoSize = true;
            this.label_max_1.Location = new System.Drawing.Point(42, 52);
            this.label_max_1.Name = "label_max_1";
            this.label_max_1.Size = new System.Drawing.Size(27, 13);
            this.label_max_1.TabIndex = 3;
            this.label_max_1.Text = "Max";
            // 
            // tb_min_1
            // 
            this.tb_min_1.Location = new System.Drawing.Point(72, 13);
            this.tb_min_1.Name = "tb_min_1";
            this.tb_min_1.Size = new System.Drawing.Size(98, 20);
            this.tb_min_1.TabIndex = 2;
            // 
            // UpdataLimits_1
            // 
            this.UpdataLimits_1.Location = new System.Drawing.Point(7, 83);
            this.UpdataLimits_1.Name = "UpdataLimits_1";
            this.UpdataLimits_1.Size = new System.Drawing.Size(166, 34);
            this.UpdataLimits_1.TabIndex = 1;
            this.UpdataLimits_1.Text = "Update Limits";
            this.UpdataLimits_1.UseVisualStyleBackColor = true;
            this.UpdataLimits_1.Click += new System.EventHandler(this.UpdateLimits_1_Click);
            // 
            // label_min_1
            // 
            this.label_min_1.AutoSize = true;
            this.label_min_1.Location = new System.Drawing.Point(42, 16);
            this.label_min_1.Name = "label_min_1";
            this.label_min_1.Size = new System.Drawing.Size(24, 13);
            this.label_min_1.TabIndex = 3;
            this.label_min_1.Text = "Min";
            // 
            // chartMain
            // 
            this.chartMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea1);
            this.chartMain.Location = new System.Drawing.Point(136, 3);
            this.chartMain.Name = "chartMain";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Name = "#CHANNEL:CH1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Name = "#CHANNEL:CH2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Name = "#CHANNEL:CH3";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Name = "#CHANNEL:CH4";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.Name = "#CHANNEL:CH5";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series6.Name = "#CHANNEL:CH6";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series7.Name = "#CHANNEL:CH7";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series8.Name = "#CHANNEL:CH8";
            this.chartMain.Series.Add(series1);
            this.chartMain.Series.Add(series2);
            this.chartMain.Series.Add(series3);
            this.chartMain.Series.Add(series4);
            this.chartMain.Series.Add(series5);
            this.chartMain.Series.Add(series6);
            this.chartMain.Series.Add(series7);
            this.chartMain.Series.Add(series8);
            this.chartMain.Size = new System.Drawing.Size(261, 564);
            this.chartMain.TabIndex = 0;
            this.chartMain.Text = "chartMain";
            this.chartMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartMain_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.tb_I3_peak);
            this.panel3.Controls.Add(this.tb_I3_rms);
            this.panel3.Controls.Add(this.tb_I2_peak);
            this.panel3.Controls.Add(this.tb_I2_rms);
            this.panel3.Controls.Add(this.Tb_ch3_I2t);
            this.panel3.Controls.Add(this.Tb_ch2_I2t);
            this.panel3.Controls.Add(this.Tb_ch1_I2t);
            this.panel3.Controls.Add(this.tb_I1_peak);
            this.panel3.Controls.Add(this.tb_I1_rms);
            this.panel3.Location = new System.Drawing.Point(403, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 562);
            this.panel3.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ip";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ip";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 432);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "I² t";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 275);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "I² t";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(23, 130);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "I² t";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ip";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "I3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "I2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "I1";
            // 
            // tb_I3_peak
            // 
            this.tb_I3_peak.Enabled = false;
            this.tb_I3_peak.Location = new System.Drawing.Point(45, 399);
            this.tb_I3_peak.Name = "tb_I3_peak";
            this.tb_I3_peak.Size = new System.Drawing.Size(100, 20);
            this.tb_I3_peak.TabIndex = 0;
            // 
            // tb_I3_rms
            // 
            this.tb_I3_rms.Enabled = false;
            this.tb_I3_rms.Location = new System.Drawing.Point(45, 371);
            this.tb_I3_rms.Name = "tb_I3_rms";
            this.tb_I3_rms.Size = new System.Drawing.Size(100, 20);
            this.tb_I3_rms.TabIndex = 0;
            // 
            // tb_I2_peak
            // 
            this.tb_I2_peak.Enabled = false;
            this.tb_I2_peak.Location = new System.Drawing.Point(45, 238);
            this.tb_I2_peak.Name = "tb_I2_peak";
            this.tb_I2_peak.Size = new System.Drawing.Size(100, 20);
            this.tb_I2_peak.TabIndex = 0;
            // 
            // tb_I2_rms
            // 
            this.tb_I2_rms.Enabled = false;
            this.tb_I2_rms.Location = new System.Drawing.Point(45, 210);
            this.tb_I2_rms.Name = "tb_I2_rms";
            this.tb_I2_rms.Size = new System.Drawing.Size(100, 20);
            this.tb_I2_rms.TabIndex = 0;
            // 
            // Tb_ch3_I2t
            // 
            this.Tb_ch3_I2t.Enabled = false;
            this.Tb_ch3_I2t.Location = new System.Drawing.Point(45, 429);
            this.Tb_ch3_I2t.Name = "Tb_ch3_I2t";
            this.Tb_ch3_I2t.Size = new System.Drawing.Size(100, 20);
            this.Tb_ch3_I2t.TabIndex = 0;
            // 
            // Tb_ch2_I2t
            // 
            this.Tb_ch2_I2t.Enabled = false;
            this.Tb_ch2_I2t.Location = new System.Drawing.Point(45, 270);
            this.Tb_ch2_I2t.Name = "Tb_ch2_I2t";
            this.Tb_ch2_I2t.Size = new System.Drawing.Size(100, 20);
            this.Tb_ch2_I2t.TabIndex = 0;
            // 
            // Tb_ch1_I2t
            // 
            this.Tb_ch1_I2t.Enabled = false;
            this.Tb_ch1_I2t.Location = new System.Drawing.Point(45, 123);
            this.Tb_ch1_I2t.Name = "Tb_ch1_I2t";
            this.Tb_ch1_I2t.Size = new System.Drawing.Size(100, 20);
            this.Tb_ch1_I2t.TabIndex = 0;
            // 
            // tb_I1_peak
            // 
            this.tb_I1_peak.Enabled = false;
            this.tb_I1_peak.Location = new System.Drawing.Point(45, 97);
            this.tb_I1_peak.Name = "tb_I1_peak";
            this.tb_I1_peak.Size = new System.Drawing.Size(100, 20);
            this.tb_I1_peak.TabIndex = 0;
            // 
            // tb_I1_rms
            // 
            this.tb_I1_rms.Enabled = false;
            this.tb_I1_rms.Location = new System.Drawing.Point(45, 69);
            this.tb_I1_rms.Name = "tb_I1_rms";
            this.tb_I1_rms.Size = new System.Drawing.Size(100, 20);
            this.tb_I1_rms.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.Tb_olcum_araligi);
            this.panel4.Controls.Add(this.Tb_son_ms);
            this.panel4.Controls.Add(this.Tb_ilk_ms);
            this.panel4.Controls.Add(this.GraphStart);
            this.panel4.Controls.Add(this.Tb_A_div);
            this.panel4.Controls.Add(this.Tb_v_div);
            this.panel4.Controls.Add(this.Tb_ms_div);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(127, 564);
            this.panel4.TabIndex = 11;
            // 
            // Tb_olcum_araligi
            // 
            this.Tb_olcum_araligi.Enabled = false;
            this.Tb_olcum_araligi.Location = new System.Drawing.Point(28, 448);
            this.Tb_olcum_araligi.Name = "Tb_olcum_araligi";
            this.Tb_olcum_araligi.Size = new System.Drawing.Size(67, 20);
            this.Tb_olcum_araligi.TabIndex = 1;
            this.Tb_olcum_araligi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Tb_son_ms
            // 
            this.Tb_son_ms.Location = new System.Drawing.Point(28, 405);
            this.Tb_son_ms.Name = "Tb_son_ms";
            this.Tb_son_ms.Size = new System.Drawing.Size(67, 20);
            this.Tb_son_ms.TabIndex = 1;
            this.Tb_son_ms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Tb_son_ms.TextChanged += new System.EventHandler(this.Tb_son_ms_TextChanged);
            // 
            // Tb_ilk_ms
            // 
            this.Tb_ilk_ms.Location = new System.Drawing.Point(28, 359);
            this.Tb_ilk_ms.Name = "Tb_ilk_ms";
            this.Tb_ilk_ms.Size = new System.Drawing.Size(67, 20);
            this.Tb_ilk_ms.TabIndex = 1;
            this.Tb_ilk_ms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Tb_ilk_ms.TextChanged += new System.EventHandler(this.Tb_ilk_ms_TextChanged);
            // 
            // GraphStart
            // 
            this.GraphStart.Location = new System.Drawing.Point(28, 318);
            this.GraphStart.Name = "GraphStart";
            this.GraphStart.Size = new System.Drawing.Size(67, 20);
            this.GraphStart.TabIndex = 1;
            this.GraphStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GraphStart.TextChanged += new System.EventHandler(this.GraphStart_TextChanged);
            // 
            // Tb_A_div
            // 
            this.Tb_A_div.Location = new System.Drawing.Point(8, 73);
            this.Tb_A_div.Name = "Tb_A_div";
            this.Tb_A_div.Size = new System.Drawing.Size(67, 20);
            this.Tb_A_div.TabIndex = 1;
            this.Tb_A_div.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Tb_A_div.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tb_A_div_MouseClick);
            this.Tb_A_div.TextChanged += new System.EventHandler(this.Tb_A_div_TextChanged);
            // 
            // Tb_v_div
            // 
            this.Tb_v_div.Location = new System.Drawing.Point(8, 42);
            this.Tb_v_div.Name = "Tb_v_div";
            this.Tb_v_div.Size = new System.Drawing.Size(67, 20);
            this.Tb_v_div.TabIndex = 1;
            this.Tb_v_div.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Tb_v_div.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tb_v_div_MouseClick);
            this.Tb_v_div.TextChanged += new System.EventHandler(this.Tb_v_div_TextChanged);
            // 
            // Tb_ms_div
            // 
            this.Tb_ms_div.Location = new System.Drawing.Point(8, 16);
            this.Tb_ms_div.Name = "Tb_ms_div";
            this.Tb_ms_div.Size = new System.Drawing.Size(67, 20);
            this.Tb_ms_div.TabIndex = 1;
            this.Tb_ms_div.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Tb_ms_div.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tb_ms_div_MouseClick);
            this.Tb_ms_div.TextChanged += new System.EventHandler(this.Tb_ms_div_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Rb_100A);
            this.groupBox1.Controls.Add(this.Rb_500A);
            this.groupBox1.Controls.Add(this.Rb_2kA);
            this.groupBox1.Controls.Add(this.Rb_5kA);
            this.groupBox1.Controls.Add(this.Rb_10kA);
            this.groupBox1.Controls.Add(this.Rb_50kA);
            this.groupBox1.Controls.Add(this.Rb_120kA);
            this.groupBox1.Location = new System.Drawing.Point(23, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(77, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Akım Skala";
            // 
            // Rb_100A
            // 
            this.Rb_100A.AutoSize = true;
            this.Rb_100A.Location = new System.Drawing.Point(6, 169);
            this.Rb_100A.Name = "Rb_100A";
            this.Rb_100A.Size = new System.Drawing.Size(56, 17);
            this.Rb_100A.TabIndex = 0;
            this.Rb_100A.TabStop = true;
            this.Rb_100A.Text = "0.1 kA";
            this.Rb_100A.UseVisualStyleBackColor = true;
            this.Rb_100A.CheckedChanged += new System.EventHandler(this.Rb_100A_CheckedChanged);
            // 
            // Rb_500A
            // 
            this.Rb_500A.AutoSize = true;
            this.Rb_500A.Location = new System.Drawing.Point(6, 144);
            this.Rb_500A.Name = "Rb_500A";
            this.Rb_500A.Size = new System.Drawing.Size(56, 17);
            this.Rb_500A.TabIndex = 0;
            this.Rb_500A.TabStop = true;
            this.Rb_500A.Text = "0.5 kA";
            this.Rb_500A.UseVisualStyleBackColor = true;
            this.Rb_500A.CheckedChanged += new System.EventHandler(this.Rb_500A_CheckedChanged);
            // 
            // Rb_2kA
            // 
            this.Rb_2kA.AutoSize = true;
            this.Rb_2kA.Location = new System.Drawing.Point(6, 119);
            this.Rb_2kA.Name = "Rb_2kA";
            this.Rb_2kA.Size = new System.Drawing.Size(47, 17);
            this.Rb_2kA.TabIndex = 0;
            this.Rb_2kA.TabStop = true;
            this.Rb_2kA.Text = "2 kA";
            this.Rb_2kA.UseVisualStyleBackColor = true;
            this.Rb_2kA.CheckedChanged += new System.EventHandler(this.Rb_2kA_CheckedChanged);
            // 
            // Rb_5kA
            // 
            this.Rb_5kA.AutoSize = true;
            this.Rb_5kA.Location = new System.Drawing.Point(6, 94);
            this.Rb_5kA.Name = "Rb_5kA";
            this.Rb_5kA.Size = new System.Drawing.Size(47, 17);
            this.Rb_5kA.TabIndex = 0;
            this.Rb_5kA.TabStop = true;
            this.Rb_5kA.Text = "5 kA";
            this.Rb_5kA.UseVisualStyleBackColor = true;
            this.Rb_5kA.CheckedChanged += new System.EventHandler(this.Rb_5kA_CheckedChanged);
            // 
            // Rb_10kA
            // 
            this.Rb_10kA.AutoSize = true;
            this.Rb_10kA.Location = new System.Drawing.Point(6, 69);
            this.Rb_10kA.Name = "Rb_10kA";
            this.Rb_10kA.Size = new System.Drawing.Size(53, 17);
            this.Rb_10kA.TabIndex = 0;
            this.Rb_10kA.TabStop = true;
            this.Rb_10kA.Text = "10 kA";
            this.Rb_10kA.UseVisualStyleBackColor = true;
            this.Rb_10kA.CheckedChanged += new System.EventHandler(this.Rb_10kA_CheckedChanged);
            // 
            // Rb_50kA
            // 
            this.Rb_50kA.AutoSize = true;
            this.Rb_50kA.Location = new System.Drawing.Point(6, 44);
            this.Rb_50kA.Name = "Rb_50kA";
            this.Rb_50kA.Size = new System.Drawing.Size(53, 17);
            this.Rb_50kA.TabIndex = 0;
            this.Rb_50kA.TabStop = true;
            this.Rb_50kA.Text = "50 kA";
            this.Rb_50kA.UseVisualStyleBackColor = true;
            this.Rb_50kA.CheckedChanged += new System.EventHandler(this.Rb_50kA_CheckedChanged);
            // 
            // Rb_120kA
            // 
            this.Rb_120kA.AutoSize = true;
            this.Rb_120kA.Location = new System.Drawing.Point(6, 19);
            this.Rb_120kA.Name = "Rb_120kA";
            this.Rb_120kA.Size = new System.Drawing.Size(59, 17);
            this.Rb_120kA.TabIndex = 0;
            this.Rb_120kA.TabStop = true;
            this.Rb_120kA.Text = "120 kA";
            this.Rb_120kA.UseVisualStyleBackColor = true;
            this.Rb_120kA.CheckedChanged += new System.EventHandler(this.Rb_120kA_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 432);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Ölçüm Aralığı (ms)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 389);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "son nokta (ms)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 343);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "ilk nokta (ms)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Grafik Başlangıç (ms)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "A/div";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "V/div";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "ms/div";
            // 
            // sp
            // 
            this.sp.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.DataReceivedHandler);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.ayarlarToolStripMenuItem,
            this.hakkındaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acToolStripMenuItem,
            this.kaydetToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // acToolStripMenuItem
            // 
            this.acToolStripMenuItem.Name = "acToolStripMenuItem";
            this.acToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.acToolStripMenuItem.Text = "Aç";
            this.acToolStripMenuItem.Click += new System.EventHandler(this.AcToolStripMenuItem_Click);
            // 
            // kaydetToolStripMenuItem
            // 
            this.kaydetToolStripMenuItem.Name = "kaydetToolStripMenuItem";
            this.kaydetToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.kaydetToolStripMenuItem.Text = "Kaydet";
            this.kaydetToolStripMenuItem.Click += new System.EventHandler(this.KaydetToolStripMenuItem_Click);
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portAyarlarıToolStripMenuItem});
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            // 
            // portAyarlarıToolStripMenuItem
            // 
            this.portAyarlarıToolStripMenuItem.Name = "portAyarlarıToolStripMenuItem";
            this.portAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.portAyarlarıToolStripMenuItem.Text = "Port Ayarları";
            this.portAyarlarıToolStripMenuItem.Click += new System.EventHandler(this.PortAyarlarıToolStripMenuItem_Click);
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(804, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "Form1";
            this.Text = "LVT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Button randomData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cb_max_1;
        private System.Windows.Forms.CheckBox cb_min_1;
        private System.Windows.Forms.Button Zeroize_1;
        private System.Windows.Forms.TextBox tb_max_1;
        private System.Windows.Forms.Label label_max_1;
        private System.Windows.Forms.TextBox tb_min_1;
        private System.Windows.Forms.Button UpdataLimits_1;
        private System.Windows.Forms.Label label_min_1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button DirencliAyirici;
        private System.Windows.Forms.Button TopraklıAyirici;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button Kesici_3;
        private System.Windows.Forms.Button Kesici_2;
        private System.Windows.Forms.Button Kesici_1;
        private System.Windows.Forms.TextBox tb_ZamanYukle;
        private SerialPort sp;
        private System.Windows.Forms.CheckBox cb_zamanayarlandı;
        private System.Windows.Forms.Button b_setzaman;
        private System.Windows.Forms.Label label_testsuresi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portAyarlarıToolStripMenuItem;
        private System.Windows.Forms.Button Kesici_1_Off;
        private System.Windows.Forms.Button Kesici_1_On;
        private System.Windows.Forms.Button Kesici_3_On;
        private System.Windows.Forms.Button Kesici_2_On;
        private System.Windows.Forms.Button Kesici_3_Off;
        private System.Windows.Forms.Button Kesici_2_Off;
        private System.Windows.Forms.Button DirencliOn;
        private System.Windows.Forms.Button ToprakliOn;
        private System.Windows.Forms.Button DirencliOff;
        private System.Windows.Forms.Button ToprakliOff;
        private System.Windows.Forms.Button TesteBasla;
        private System.Windows.Forms.Button TestiDurdur;
        private Chart chartMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Rb_100A;
        private System.Windows.Forms.RadioButton Rb_500A;
        private System.Windows.Forms.RadioButton Rb_2kA;
        private System.Windows.Forms.RadioButton Rb_5kA;
        private System.Windows.Forms.RadioButton Rb_10kA;
        private System.Windows.Forms.RadioButton Rb_50kA;
        private System.Windows.Forms.RadioButton Rb_120kA;
        private int ScaleFactor;
        private double L1_RMS;
        private double L2_RMS;
        private double L3_RMS;
        private double L1_PEAK;
        private double L2_PEAK;
        private double L3_PEAK;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tb_I1_rms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_I1_peak;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_I3_peak;
        private System.Windows.Forms.TextBox tb_I3_rms;
        private System.Windows.Forms.TextBox tb_I2_peak;
        private System.Windows.Forms.TextBox tb_I2_rms;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox Tb_ms_div;
        private System.Windows.Forms.Label label7;
        private double tb_ms_div_old;
        private System.Windows.Forms.TextBox Tb_v_div;
        private System.Windows.Forms.Label label8;
        private double tb_v_div_old;
        private double[][] cizilecekData = new double[6][];
        private double[][] hesaplanacakData = new double[6][];
        private System.Windows.Forms.TextBox Tb_A_div;
        private System.Windows.Forms.Label label9;
        private double tb_A_div_old;
        private System.Windows.Forms.TextBox GraphStart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Tb_ilk_ms;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Tb_son_ms;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Tb_olcum_araligi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Tb_ch1_I2t;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox Tb_ch3_I2t;
        private System.Windows.Forms.TextBox Tb_ch2_I2t;
    }
}

