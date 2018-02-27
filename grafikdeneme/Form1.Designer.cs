using System;
using System.IO.Ports;
using System.IO;


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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartV1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.randomData = new System.Windows.Forms.Button();
            this.chartA1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartA2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartV2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cb_max_3 = new System.Windows.Forms.CheckBox();
            this.cb_min_3 = new System.Windows.Forms.CheckBox();
            this.label_max_3 = new System.Windows.Forms.Label();
            this.label_min_3 = new System.Windows.Forms.Label();
            this.tb_max_3 = new System.Windows.Forms.TextBox();
            this.tb_min_3 = new System.Windows.Forms.TextBox();
            this.Zeroize_3 = new System.Windows.Forms.Button();
            this.UpdataLimits_3 = new System.Windows.Forms.Button();
            this.chartA3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartV3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cb_max_1 = new System.Windows.Forms.CheckBox();
            this.cb_min_1 = new System.Windows.Forms.CheckBox();
            this.Zeroize_1 = new System.Windows.Forms.Button();
            this.tb_max_1 = new System.Windows.Forms.TextBox();
            this.label_max_1 = new System.Windows.Forms.Label();
            this.tb_min_1 = new System.Windows.Forms.TextBox();
            this.UpdataLimits_1 = new System.Windows.Forms.Button();
            this.label_min_1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Zeroize_2 = new System.Windows.Forms.Button();
            this.cb_max_2 = new System.Windows.Forms.CheckBox();
            this.UpdataLimits_2 = new System.Windows.Forms.Button();
            this.cb_min_2 = new System.Windows.Forms.CheckBox();
            this.label_max_2 = new System.Windows.Forms.Label();
            this.label_min_2 = new System.Windows.Forms.Label();
            this.tb_max_2 = new System.Windows.Forms.TextBox();
            this.tb_min_2 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label_testsuresi = new System.Windows.Forms.Label();
            this.cb_zamanayarlandı = new System.Windows.Forms.CheckBox();
            this.b_setzaman = new System.Windows.Forms.Button();
            this.tb_ZamanYukle = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.Kesici_2_C = new System.Windows.Forms.Button();
            this.Kesici_2_B = new System.Windows.Forms.Button();
            this.Kesici_2_A = new System.Windows.Forms.Button();
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
            this.sp = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chartV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartA3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartV3)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartV1
            // 
            this.chartV1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea7.Name = "ChartArea1";
            this.chartV1.ChartAreas.Add(chartArea7);
            this.chartV1.Location = new System.Drawing.Point(3, 3);
            this.chartV1.Name = "chartV1";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "V1";
            this.chartV1.Series.Add(series7);
            this.chartV1.Size = new System.Drawing.Size(417, 85);
            this.chartV1.TabIndex = 0;
            this.chartV1.Text = "V1";
            this.chartV1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartV1_Click);
            // 
            // randomData
            // 
            this.randomData.Location = new System.Drawing.Point(5, 339);
            this.randomData.Name = "randomData";
            this.randomData.Size = new System.Drawing.Size(141, 34);
            this.randomData.TabIndex = 1;
            this.randomData.Text = "randomData";
            this.randomData.UseVisualStyleBackColor = true;
            this.randomData.Click += new System.EventHandler(this.RandomData_Click);
            // 
            // chartA1
            // 
            this.chartA1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea8.Name = "ChartArea2";
            this.chartA1.ChartAreas.Add(chartArea8);
            this.chartA1.Location = new System.Drawing.Point(3, 94);
            this.chartA1.Name = "chartA1";
            series8.ChartArea = "ChartArea2";
            series8.Legend = "Legend1";
            series8.Name = "A1";
            this.chartA1.Series.Add(series8);
            this.chartA1.Size = new System.Drawing.Size(417, 85);
            this.chartA1.TabIndex = 0;
            this.chartA1.Text = "A1";
            this.chartA1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartA1_Click);
            // 
            // chartA2
            // 
            this.chartA2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea9.Name = "ChartArea2";
            this.chartA2.ChartAreas.Add(chartArea9);
            this.chartA2.Location = new System.Drawing.Point(3, 94);
            this.chartA2.Name = "chartA2";
            series9.ChartArea = "ChartArea2";
            series9.Legend = "Legend1";
            series9.Name = "A2";
            this.chartA2.Series.Add(series9);
            this.chartA2.Size = new System.Drawing.Size(417, 85);
            this.chartA2.TabIndex = 0;
            this.chartA2.Text = "A2";
            this.chartA2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartA2_Click);
            // 
            // chartV2
            // 
            this.chartV2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea10.Name = "ChartArea1";
            this.chartV2.ChartAreas.Add(chartArea10);
            this.chartV2.Location = new System.Drawing.Point(3, 3);
            this.chartV2.Name = "chartV2";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "V2";
            this.chartV2.Series.Add(series10);
            this.chartV2.Size = new System.Drawing.Size(417, 85);
            this.chartV2.TabIndex = 0;
            this.chartV2.Text = "V2";
            this.chartV2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartV2_Click);
            // 
            // cb_max_3
            // 
            this.cb_max_3.AutoSize = true;
            this.cb_max_3.Location = new System.Drawing.Point(10, 52);
            this.cb_max_3.Name = "cb_max_3";
            this.cb_max_3.Size = new System.Drawing.Size(15, 14);
            this.cb_max_3.TabIndex = 4;
            this.cb_max_3.UseVisualStyleBackColor = true;
            this.cb_max_3.CheckedChanged += new System.EventHandler(this.Cb_max_3_CheckedChanged);
            // 
            // cb_min_3
            // 
            this.cb_min_3.AutoSize = true;
            this.cb_min_3.Location = new System.Drawing.Point(10, 16);
            this.cb_min_3.Name = "cb_min_3";
            this.cb_min_3.Size = new System.Drawing.Size(15, 14);
            this.cb_min_3.TabIndex = 4;
            this.cb_min_3.UseVisualStyleBackColor = true;
            this.cb_min_3.CheckedChanged += new System.EventHandler(this.Cb_min_3_CheckedChanged);
            // 
            // label_max_3
            // 
            this.label_max_3.AutoSize = true;
            this.label_max_3.Location = new System.Drawing.Point(42, 52);
            this.label_max_3.Name = "label_max_3";
            this.label_max_3.Size = new System.Drawing.Size(27, 13);
            this.label_max_3.TabIndex = 3;
            this.label_max_3.Text = "Max";
            // 
            // label_min_3
            // 
            this.label_min_3.AutoSize = true;
            this.label_min_3.Location = new System.Drawing.Point(42, 16);
            this.label_min_3.Name = "label_min_3";
            this.label_min_3.Size = new System.Drawing.Size(24, 13);
            this.label_min_3.TabIndex = 3;
            this.label_min_3.Text = "Min";
            // 
            // tb_max_3
            // 
            this.tb_max_3.Location = new System.Drawing.Point(72, 49);
            this.tb_max_3.Name = "tb_max_3";
            this.tb_max_3.Size = new System.Drawing.Size(97, 20);
            this.tb_max_3.TabIndex = 2;
            // 
            // tb_min_3
            // 
            this.tb_min_3.Location = new System.Drawing.Point(72, 13);
            this.tb_min_3.Name = "tb_min_3";
            this.tb_min_3.Size = new System.Drawing.Size(97, 20);
            this.tb_min_3.TabIndex = 2;
            // 
            // Zeroize_3
            // 
            this.Zeroize_3.Location = new System.Drawing.Point(7, 123);
            this.Zeroize_3.Name = "Zeroize_3";
            this.Zeroize_3.Size = new System.Drawing.Size(166, 34);
            this.Zeroize_3.TabIndex = 1;
            this.Zeroize_3.Text = "Zeroize";
            this.Zeroize_3.UseVisualStyleBackColor = true;
            this.Zeroize_3.Click += new System.EventHandler(this.Zeroize_3_Click);
            // 
            // UpdataLimits_3
            // 
            this.UpdataLimits_3.Location = new System.Drawing.Point(7, 83);
            this.UpdataLimits_3.Name = "UpdataLimits_3";
            this.UpdataLimits_3.Size = new System.Drawing.Size(166, 34);
            this.UpdataLimits_3.TabIndex = 1;
            this.UpdataLimits_3.Text = "Update Limits";
            this.UpdataLimits_3.UseVisualStyleBackColor = true;
            this.UpdataLimits_3.Click += new System.EventHandler(this.UpdateLimits_3_Click);
            // 
            // chartA3
            // 
            this.chartA3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea11.Name = "ChartArea2";
            this.chartA3.ChartAreas.Add(chartArea11);
            this.chartA3.Location = new System.Drawing.Point(3, 94);
            this.chartA3.Name = "chartA3";
            series11.ChartArea = "ChartArea2";
            series11.Legend = "Legend1";
            series11.Name = "A3";
            this.chartA3.Series.Add(series11);
            this.chartA3.Size = new System.Drawing.Size(417, 85);
            this.chartA3.TabIndex = 0;
            this.chartA3.Text = "A3";
            this.chartA3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartA3_Click);
            // 
            // chartV3
            // 
            this.chartV3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea12.Name = "ChartArea1";
            this.chartV3.ChartAreas.Add(chartArea12);
            this.chartV3.Location = new System.Drawing.Point(3, 3);
            this.chartV3.Name = "chartV3";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "V3";
            this.chartV3.Series.Add(series12);
            this.chartV3.Size = new System.Drawing.Size(417, 85);
            this.chartV3.TabIndex = 0;
            this.chartV3.Text = "V3";
            this.chartV3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartV3_Click);
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
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.50822F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.49178F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(791, 570);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(614, 564);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.cb_max_1);
            this.panel2.Controls.Add(this.cb_min_1);
            this.panel2.Controls.Add(this.Zeroize_1);
            this.panel2.Controls.Add(this.tb_max_1);
            this.panel2.Controls.Add(this.label_max_1);
            this.panel2.Controls.Add(this.tb_min_1);
            this.panel2.Controls.Add(this.UpdataLimits_1);
            this.panel2.Controls.Add(this.label_min_1);
            this.panel2.Location = new System.Drawing.Point(432, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 182);
            this.panel2.TabIndex = 8;
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
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.chartA1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.chartV1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(423, 182);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.chartV2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.chartA2, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 191);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(423, 182);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.chartV3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.chartA3, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 379);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(423, 182);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.Zeroize_2);
            this.panel3.Controls.Add(this.cb_max_2);
            this.panel3.Controls.Add(this.UpdataLimits_2);
            this.panel3.Controls.Add(this.cb_min_2);
            this.panel3.Controls.Add(this.label_max_2);
            this.panel3.Controls.Add(this.label_min_2);
            this.panel3.Controls.Add(this.tb_max_2);
            this.panel3.Controls.Add(this.tb_min_2);
            this.panel3.Location = new System.Drawing.Point(432, 191);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(179, 182);
            this.panel3.TabIndex = 9;
            // 
            // Zeroize_2
            // 
            this.Zeroize_2.Location = new System.Drawing.Point(7, 123);
            this.Zeroize_2.Name = "Zeroize_2";
            this.Zeroize_2.Size = new System.Drawing.Size(166, 34);
            this.Zeroize_2.TabIndex = 1;
            this.Zeroize_2.Text = "Zeroize";
            this.Zeroize_2.UseVisualStyleBackColor = true;
            this.Zeroize_2.Click += new System.EventHandler(this.Zeroize_2_Click);
            // 
            // cb_max_2
            // 
            this.cb_max_2.AutoSize = true;
            this.cb_max_2.Location = new System.Drawing.Point(10, 52);
            this.cb_max_2.Name = "cb_max_2";
            this.cb_max_2.Size = new System.Drawing.Size(15, 14);
            this.cb_max_2.TabIndex = 4;
            this.cb_max_2.UseVisualStyleBackColor = true;
            this.cb_max_2.CheckedChanged += new System.EventHandler(this.Cb_max_2_CheckedChanged);
            // 
            // UpdataLimits_2
            // 
            this.UpdataLimits_2.Location = new System.Drawing.Point(7, 83);
            this.UpdataLimits_2.Name = "UpdataLimits_2";
            this.UpdataLimits_2.Size = new System.Drawing.Size(166, 34);
            this.UpdataLimits_2.TabIndex = 1;
            this.UpdataLimits_2.Text = "Update Limits";
            this.UpdataLimits_2.UseVisualStyleBackColor = true;
            this.UpdataLimits_2.Click += new System.EventHandler(this.UpdateLimits_2_Click);
            // 
            // cb_min_2
            // 
            this.cb_min_2.AutoSize = true;
            this.cb_min_2.Location = new System.Drawing.Point(10, 16);
            this.cb_min_2.Name = "cb_min_2";
            this.cb_min_2.Size = new System.Drawing.Size(15, 14);
            this.cb_min_2.TabIndex = 4;
            this.cb_min_2.UseVisualStyleBackColor = true;
            this.cb_min_2.CheckedChanged += new System.EventHandler(this.Cb_min_2_CheckedChanged);
            // 
            // label_max_2
            // 
            this.label_max_2.AutoSize = true;
            this.label_max_2.Location = new System.Drawing.Point(42, 52);
            this.label_max_2.Name = "label_max_2";
            this.label_max_2.Size = new System.Drawing.Size(27, 13);
            this.label_max_2.TabIndex = 3;
            this.label_max_2.Text = "Max";
            // 
            // label_min_2
            // 
            this.label_min_2.AutoSize = true;
            this.label_min_2.Location = new System.Drawing.Point(42, 16);
            this.label_min_2.Name = "label_min_2";
            this.label_min_2.Size = new System.Drawing.Size(24, 13);
            this.label_min_2.TabIndex = 3;
            this.label_min_2.Text = "Min";
            // 
            // tb_max_2
            // 
            this.tb_max_2.Location = new System.Drawing.Point(72, 49);
            this.tb_max_2.Name = "tb_max_2";
            this.tb_max_2.Size = new System.Drawing.Size(97, 20);
            this.tb_max_2.TabIndex = 2;
            // 
            // tb_min_2
            // 
            this.tb_min_2.Location = new System.Drawing.Point(72, 13);
            this.tb_min_2.Name = "tb_min_2";
            this.tb_min_2.Size = new System.Drawing.Size(97, 20);
            this.tb_min_2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.Zeroize_3);
            this.panel4.Controls.Add(this.tb_min_3);
            this.panel4.Controls.Add(this.UpdataLimits_3);
            this.panel4.Controls.Add(this.tb_max_3);
            this.panel4.Controls.Add(this.label_min_3);
            this.panel4.Controls.Add(this.label_max_3);
            this.panel4.Controls.Add(this.cb_max_3);
            this.panel4.Controls.Add(this.cb_min_3);
            this.panel4.Location = new System.Drawing.Point(432, 379);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(179, 182);
            this.panel4.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.label_testsuresi);
            this.panel5.Controls.Add(this.cb_zamanayarlandı);
            this.panel5.Controls.Add(this.b_setzaman);
            this.panel5.Controls.Add(this.tb_ZamanYukle);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.randomData);
            this.panel5.Location = new System.Drawing.Point(623, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(165, 564);
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
            this.panel7.Controls.Add(this.Kesici_2_C);
            this.panel7.Controls.Add(this.Kesici_2_B);
            this.panel7.Controls.Add(this.Kesici_2_A);
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel7.Location = new System.Drawing.Point(5, 191);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(145, 132);
            this.panel7.TabIndex = 2;
            // 
            // Kesici_2_C
            // 
            this.Kesici_2_C.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesici_2_C.Location = new System.Drawing.Point(50, 85);
            this.Kesici_2_C.Name = "Kesici_2_C";
            this.Kesici_2_C.Size = new System.Drawing.Size(50, 34);
            this.Kesici_2_C.TabIndex = 0;
            this.Kesici_2_C.Text = "Kesici 2-C";
            this.Kesici_2_C.UseVisualStyleBackColor = true;
            this.Kesici_2_C.Click += new System.EventHandler(this.Kesici_2_C_Click);
            // 
            // Kesici_2_B
            // 
            this.Kesici_2_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesici_2_B.Location = new System.Drawing.Point(50, 45);
            this.Kesici_2_B.Name = "Kesici_2_B";
            this.Kesici_2_B.Size = new System.Drawing.Size(50, 34);
            this.Kesici_2_B.TabIndex = 0;
            this.Kesici_2_B.Text = "Kesici 2-B";
            this.Kesici_2_B.UseVisualStyleBackColor = true;
            this.Kesici_2_B.Click += new System.EventHandler(this.Kesici_2_B_Click);
            // 
            // Kesici_2_A
            // 
            this.Kesici_2_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesici_2_A.Location = new System.Drawing.Point(50, 5);
            this.Kesici_2_A.Name = "Kesici_2_A";
            this.Kesici_2_A.Size = new System.Drawing.Size(50, 34);
            this.Kesici_2_A.TabIndex = 0;
            this.Kesici_2_A.Text = "Kesici 2-A";
            this.Kesici_2_A.UseVisualStyleBackColor = true;
            this.Kesici_2_A.Click += new System.EventHandler(this.Kesici_2_A_Click);
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
            this.Text = "MAVIS";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartA3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartV3)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartV1;
        private System.Windows.Forms.Button randomData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartA1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartA2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartV2;
        private System.Windows.Forms.CheckBox cb_max_3;
        private System.Windows.Forms.CheckBox cb_min_3;
        private System.Windows.Forms.Label label_max_3;
        private System.Windows.Forms.Label label_min_3;
        private System.Windows.Forms.TextBox tb_max_3;
        private System.Windows.Forms.TextBox tb_min_3;
        private System.Windows.Forms.Button Zeroize_3;
        private System.Windows.Forms.Button UpdataLimits_3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartA3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartV3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cb_max_1;
        private System.Windows.Forms.CheckBox cb_min_1;
        private System.Windows.Forms.Button Zeroize_1;
        private System.Windows.Forms.TextBox tb_max_1;
        private System.Windows.Forms.Label label_max_1;
        private System.Windows.Forms.TextBox tb_min_1;
        private System.Windows.Forms.Button UpdataLimits_1;
        private System.Windows.Forms.Label label_min_1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Zeroize_2;
        private System.Windows.Forms.CheckBox cb_max_2;
        private System.Windows.Forms.Button UpdataLimits_2;
        private System.Windows.Forms.CheckBox cb_min_2;
        private System.Windows.Forms.Label label_max_2;
        private System.Windows.Forms.Label label_min_2;
        private System.Windows.Forms.TextBox tb_max_2;
        private System.Windows.Forms.TextBox tb_min_2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button Kesici_2_C;
        private System.Windows.Forms.Button Kesici_2_B;
        private System.Windows.Forms.Button Kesici_2_A;
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
    }
}

