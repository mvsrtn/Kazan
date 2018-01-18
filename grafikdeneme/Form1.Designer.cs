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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea25 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea26 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea27 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea28 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series28 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea29 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series29 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea30 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series30 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartV1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.randomData = new System.Windows.Forms.Button();
            this.tb_min_1 = new System.Windows.Forms.TextBox();
            this.UpdataLimits_1 = new System.Windows.Forms.Button();
            this.label_min_1 = new System.Windows.Forms.Label();
            this.tb_max_1 = new System.Windows.Forms.TextBox();
            this.label_max_1 = new System.Windows.Forms.Label();
            this.cb_min_1 = new System.Windows.Forms.CheckBox();
            this.cb_max_1 = new System.Windows.Forms.CheckBox();
            this.chartA1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Zeroize_1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_max_2 = new System.Windows.Forms.CheckBox();
            this.cb_min_2 = new System.Windows.Forms.CheckBox();
            this.label_max_2 = new System.Windows.Forms.Label();
            this.label_min_2 = new System.Windows.Forms.Label();
            this.tb_max_2 = new System.Windows.Forms.TextBox();
            this.tb_min_2 = new System.Windows.Forms.TextBox();
            this.Zeroize_2 = new System.Windows.Forms.Button();
            this.UpdataLimits_2 = new System.Windows.Forms.Button();
            this.chartA2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartV2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.chartV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartA1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartV2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartA3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartV3)).BeginInit();
            this.SuspendLayout();
            // 
            // chartV1
            // 
            chartArea25.Name = "ChartArea1";
            this.chartV1.ChartAreas.Add(chartArea25);
            this.chartV1.Location = new System.Drawing.Point(10, 20);
            this.chartV1.Name = "chartV1";
            series25.ChartArea = "ChartArea1";
            series25.Legend = "Legend1";
            series25.Name = "randomSeries";
            this.chartV1.Series.Add(series25);
            this.chartV1.Size = new System.Drawing.Size(650, 120);
            this.chartV1.TabIndex = 0;
            this.chartV1.Text = "V1";
            this.chartV1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartV1_Click);
            // 
            // randomData
            // 
            this.randomData.Location = new System.Drawing.Point(918, 857);
            this.randomData.Name = "randomData";
            this.randomData.Size = new System.Drawing.Size(75, 23);
            this.randomData.TabIndex = 1;
            this.randomData.Text = "randomData";
            this.randomData.UseVisualStyleBackColor = true;
            this.randomData.Click += new System.EventHandler(this.randomData_Click);
            // 
            // tb_min_1
            // 
            this.tb_min_1.Location = new System.Drawing.Point(750, 20);
            this.tb_min_1.Name = "tb_min_1";
            this.tb_min_1.Size = new System.Drawing.Size(75, 20);
            this.tb_min_1.TabIndex = 2;
            // 
            // UpdataLimits_1
            // 
            this.UpdataLimits_1.Location = new System.Drawing.Point(688, 94);
            this.UpdataLimits_1.Name = "UpdataLimits_1";
            this.UpdataLimits_1.Size = new System.Drawing.Size(140, 25);
            this.UpdataLimits_1.TabIndex = 1;
            this.UpdataLimits_1.Text = "Update Limits";
            this.UpdataLimits_1.UseVisualStyleBackColor = true;
            this.UpdataLimits_1.Click += new System.EventHandler(this.UpdateLimits_1_Click);
            // 
            // label_min_1
            // 
            this.label_min_1.AutoSize = true;
            this.label_min_1.Location = new System.Drawing.Point(719, 22);
            this.label_min_1.Name = "label_min_1";
            this.label_min_1.Size = new System.Drawing.Size(24, 13);
            this.label_min_1.TabIndex = 3;
            this.label_min_1.Text = "Min";
            // 
            // tb_max_1
            // 
            this.tb_max_1.Location = new System.Drawing.Point(750, 60);
            this.tb_max_1.Name = "tb_max_1";
            this.tb_max_1.Size = new System.Drawing.Size(75, 20);
            this.tb_max_1.TabIndex = 2;
            // 
            // label_max_1
            // 
            this.label_max_1.AutoSize = true;
            this.label_max_1.Location = new System.Drawing.Point(717, 63);
            this.label_max_1.Name = "label_max_1";
            this.label_max_1.Size = new System.Drawing.Size(27, 13);
            this.label_max_1.TabIndex = 3;
            this.label_max_1.Text = "Max";
            // 
            // cb_min_1
            // 
            this.cb_min_1.AutoSize = true;
            this.cb_min_1.Location = new System.Drawing.Point(688, 23);
            this.cb_min_1.Name = "cb_min_1";
            this.cb_min_1.Size = new System.Drawing.Size(15, 14);
            this.cb_min_1.TabIndex = 4;
            this.cb_min_1.UseVisualStyleBackColor = true;
            this.cb_min_1.CheckedChanged += new System.EventHandler(this.cb_min_1_CheckedChanged);
            // 
            // cb_max_1
            // 
            this.cb_max_1.AutoSize = true;
            this.cb_max_1.Location = new System.Drawing.Point(688, 63);
            this.cb_max_1.Name = "cb_max_1";
            this.cb_max_1.Size = new System.Drawing.Size(15, 14);
            this.cb_max_1.TabIndex = 4;
            this.cb_max_1.UseVisualStyleBackColor = true;
            this.cb_max_1.CheckedChanged += new System.EventHandler(this.cb_max_1_CheckedChanged);
            // 
            // chartA1
            // 
            chartArea26.Name = "ChartArea2";
            this.chartA1.ChartAreas.Add(chartArea26);
            this.chartA1.Location = new System.Drawing.Point(10, 150);
            this.chartA1.Name = "chartA1";
            series26.ChartArea = "ChartArea2";
            series26.Legend = "Legend1";
            series26.Name = "randomSeries";
            this.chartA1.Series.Add(series26);
            this.chartA1.Size = new System.Drawing.Size(650, 120);
            this.chartA1.TabIndex = 0;
            this.chartA1.Text = "A1";
            this.chartA1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartA1_Click);
            // 
            // Zeroize_1
            // 
            this.Zeroize_1.Location = new System.Drawing.Point(688, 132);
            this.Zeroize_1.Name = "Zeroize_1";
            this.Zeroize_1.Size = new System.Drawing.Size(140, 25);
            this.Zeroize_1.TabIndex = 1;
            this.Zeroize_1.Text = "Zeroize";
            this.Zeroize_1.UseVisualStyleBackColor = true;
            this.Zeroize_1.Click += new System.EventHandler(this.Zeroize_1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.cb_max_1);
            this.groupBox1.Controls.Add(this.cb_min_1);
            this.groupBox1.Controls.Add(this.label_max_1);
            this.groupBox1.Controls.Add(this.label_min_1);
            this.groupBox1.Controls.Add(this.tb_max_1);
            this.groupBox1.Controls.Add(this.tb_min_1);
            this.groupBox1.Controls.Add(this.Zeroize_1);
            this.groupBox1.Controls.Add(this.UpdataLimits_1);
            this.groupBox1.Controls.Add(this.chartA1);
            this.groupBox1.Controls.Add(this.chartV1);
            this.groupBox1.Location = new System.Drawing.Point(5, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 290);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "V-A 1";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.cb_max_2);
            this.groupBox2.Controls.Add(this.cb_min_2);
            this.groupBox2.Controls.Add(this.label_max_2);
            this.groupBox2.Controls.Add(this.label_min_2);
            this.groupBox2.Controls.Add(this.tb_max_2);
            this.groupBox2.Controls.Add(this.tb_min_2);
            this.groupBox2.Controls.Add(this.Zeroize_2);
            this.groupBox2.Controls.Add(this.UpdataLimits_2);
            this.groupBox2.Controls.Add(this.chartA2);
            this.groupBox2.Controls.Add(this.chartV2);
            this.groupBox2.Location = new System.Drawing.Point(5, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(850, 290);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "V-A 2";
            // 
            // cb_max_2
            // 
            this.cb_max_2.AutoSize = true;
            this.cb_max_2.Location = new System.Drawing.Point(688, 63);
            this.cb_max_2.Name = "cb_max_2";
            this.cb_max_2.Size = new System.Drawing.Size(15, 14);
            this.cb_max_2.TabIndex = 4;
            this.cb_max_2.UseVisualStyleBackColor = true;
            this.cb_max_2.CheckedChanged += new System.EventHandler(this.cb_max_2_CheckedChanged);
            // 
            // cb_min_2
            // 
            this.cb_min_2.AutoSize = true;
            this.cb_min_2.Location = new System.Drawing.Point(688, 23);
            this.cb_min_2.Name = "cb_min_2";
            this.cb_min_2.Size = new System.Drawing.Size(15, 14);
            this.cb_min_2.TabIndex = 4;
            this.cb_min_2.UseVisualStyleBackColor = true;
            this.cb_min_2.CheckedChanged += new System.EventHandler(this.cb_min_2_CheckedChanged);
            // 
            // label_max_2
            // 
            this.label_max_2.AutoSize = true;
            this.label_max_2.Location = new System.Drawing.Point(717, 63);
            this.label_max_2.Name = "label_max_2";
            this.label_max_2.Size = new System.Drawing.Size(27, 13);
            this.label_max_2.TabIndex = 3;
            this.label_max_2.Text = "Max";
            // 
            // label_min_2
            // 
            this.label_min_2.AutoSize = true;
            this.label_min_2.Location = new System.Drawing.Point(719, 22);
            this.label_min_2.Name = "label_min_2";
            this.label_min_2.Size = new System.Drawing.Size(24, 13);
            this.label_min_2.TabIndex = 3;
            this.label_min_2.Text = "Min";
            // 
            // tb_max_2
            // 
            this.tb_max_2.Location = new System.Drawing.Point(750, 60);
            this.tb_max_2.Name = "tb_max_2";
            this.tb_max_2.Size = new System.Drawing.Size(75, 20);
            this.tb_max_2.TabIndex = 2;
            // 
            // tb_min_2
            // 
            this.tb_min_2.Location = new System.Drawing.Point(750, 20);
            this.tb_min_2.Name = "tb_min_2";
            this.tb_min_2.Size = new System.Drawing.Size(75, 20);
            this.tb_min_2.TabIndex = 2;
            // 
            // Zeroize_2
            // 
            this.Zeroize_2.Location = new System.Drawing.Point(688, 132);
            this.Zeroize_2.Name = "Zeroize_2";
            this.Zeroize_2.Size = new System.Drawing.Size(140, 25);
            this.Zeroize_2.TabIndex = 1;
            this.Zeroize_2.Text = "Zeroize";
            this.Zeroize_2.UseVisualStyleBackColor = true;
            this.Zeroize_2.Click += new System.EventHandler(this.Zeroize_2_Click);
            // 
            // UpdataLimits_2
            // 
            this.UpdataLimits_2.Location = new System.Drawing.Point(688, 94);
            this.UpdataLimits_2.Name = "UpdataLimits_2";
            this.UpdataLimits_2.Size = new System.Drawing.Size(140, 25);
            this.UpdataLimits_2.TabIndex = 1;
            this.UpdataLimits_2.Text = "Update Limits";
            this.UpdataLimits_2.UseVisualStyleBackColor = true;
            this.UpdataLimits_2.Click += new System.EventHandler(this.UpdateLimits_2_Click);
            // 
            // chartA2
            // 
            chartArea27.Name = "ChartArea2";
            this.chartA2.ChartAreas.Add(chartArea27);
            this.chartA2.Location = new System.Drawing.Point(10, 150);
            this.chartA2.Name = "chartA2";
            series27.ChartArea = "ChartArea2";
            series27.Legend = "Legend1";
            series27.Name = "randomSeries";
            this.chartA2.Series.Add(series27);
            this.chartA2.Size = new System.Drawing.Size(650, 120);
            this.chartA2.TabIndex = 0;
            this.chartA2.Text = "A2";
            this.chartA2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartA2_Click);
            // 
            // chartV2
            // 
            chartArea28.Name = "ChartArea1";
            this.chartV2.ChartAreas.Add(chartArea28);
            this.chartV2.Location = new System.Drawing.Point(10, 20);
            this.chartV2.Name = "chartV2";
            series28.ChartArea = "ChartArea1";
            series28.Legend = "Legend1";
            series28.Name = "randomSeries";
            this.chartV2.Series.Add(series28);
            this.chartV2.Size = new System.Drawing.Size(650, 120);
            this.chartV2.TabIndex = 0;
            this.chartV2.Text = "V2";
            this.chartV2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartV2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox3.Controls.Add(this.cb_max_3);
            this.groupBox3.Controls.Add(this.cb_min_3);
            this.groupBox3.Controls.Add(this.label_max_3);
            this.groupBox3.Controls.Add(this.label_min_3);
            this.groupBox3.Controls.Add(this.tb_max_3);
            this.groupBox3.Controls.Add(this.tb_min_3);
            this.groupBox3.Controls.Add(this.Zeroize_3);
            this.groupBox3.Controls.Add(this.UpdataLimits_3);
            this.groupBox3.Controls.Add(this.chartA3);
            this.groupBox3.Controls.Add(this.chartV3);
            this.groupBox3.Location = new System.Drawing.Point(5, 610);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(850, 290);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "V-A 3";
            // 
            // cb_max_3
            // 
            this.cb_max_3.AutoSize = true;
            this.cb_max_3.Location = new System.Drawing.Point(688, 63);
            this.cb_max_3.Name = "cb_max_3";
            this.cb_max_3.Size = new System.Drawing.Size(15, 14);
            this.cb_max_3.TabIndex = 4;
            this.cb_max_3.UseVisualStyleBackColor = true;
            this.cb_max_3.CheckedChanged += new System.EventHandler(this.cb_max_3_CheckedChanged);
            // 
            // cb_min_3
            // 
            this.cb_min_3.AutoSize = true;
            this.cb_min_3.Location = new System.Drawing.Point(688, 23);
            this.cb_min_3.Name = "cb_min_3";
            this.cb_min_3.Size = new System.Drawing.Size(15, 14);
            this.cb_min_3.TabIndex = 4;
            this.cb_min_3.UseVisualStyleBackColor = true;
            this.cb_min_3.CheckedChanged += new System.EventHandler(this.cb_min_3_CheckedChanged);
            // 
            // label_max_3
            // 
            this.label_max_3.AutoSize = true;
            this.label_max_3.Location = new System.Drawing.Point(717, 63);
            this.label_max_3.Name = "label_max_3";
            this.label_max_3.Size = new System.Drawing.Size(27, 13);
            this.label_max_3.TabIndex = 3;
            this.label_max_3.Text = "Max";
            // 
            // label_min_3
            // 
            this.label_min_3.AutoSize = true;
            this.label_min_3.Location = new System.Drawing.Point(719, 22);
            this.label_min_3.Name = "label_min_3";
            this.label_min_3.Size = new System.Drawing.Size(24, 13);
            this.label_min_3.TabIndex = 3;
            this.label_min_3.Text = "Min";
            // 
            // tb_max_3
            // 
            this.tb_max_3.Location = new System.Drawing.Point(750, 60);
            this.tb_max_3.Name = "tb_max_3";
            this.tb_max_3.Size = new System.Drawing.Size(75, 20);
            this.tb_max_3.TabIndex = 2;
            // 
            // tb_min_3
            // 
            this.tb_min_3.Location = new System.Drawing.Point(750, 20);
            this.tb_min_3.Name = "tb_min_3";
            this.tb_min_3.Size = new System.Drawing.Size(75, 20);
            this.tb_min_3.TabIndex = 2;
            // 
            // Zeroize_3
            // 
            this.Zeroize_3.Location = new System.Drawing.Point(688, 132);
            this.Zeroize_3.Name = "Zeroize_3";
            this.Zeroize_3.Size = new System.Drawing.Size(140, 25);
            this.Zeroize_3.TabIndex = 1;
            this.Zeroize_3.Text = "Zeroize";
            this.Zeroize_3.UseVisualStyleBackColor = true;
            this.Zeroize_3.Click += new System.EventHandler(this.Zeroize_3_Click);
            // 
            // UpdataLimits_3
            // 
            this.UpdataLimits_3.Location = new System.Drawing.Point(688, 94);
            this.UpdataLimits_3.Name = "UpdataLimits_3";
            this.UpdataLimits_3.Size = new System.Drawing.Size(140, 25);
            this.UpdataLimits_3.TabIndex = 1;
            this.UpdataLimits_3.Text = "Update Limits";
            this.UpdataLimits_3.UseVisualStyleBackColor = true;
            this.UpdataLimits_3.Click += new System.EventHandler(this.UpdateLimits_3_Click);
            // 
            // chartA3
            // 
            chartArea29.Name = "ChartArea2";
            this.chartA3.ChartAreas.Add(chartArea29);
            this.chartA3.Location = new System.Drawing.Point(10, 150);
            this.chartA3.Name = "chartA3";
            series29.ChartArea = "ChartArea2";
            series29.Legend = "Legend1";
            series29.Name = "randomSeries";
            this.chartA3.Series.Add(series29);
            this.chartA3.Size = new System.Drawing.Size(650, 120);
            this.chartA3.TabIndex = 0;
            this.chartA3.Text = "A3";
            this.chartA3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartA3_Click);
            // 
            // chartV3
            // 
            chartArea30.Name = "ChartArea1";
            this.chartV3.ChartAreas.Add(chartArea30);
            this.chartV3.Location = new System.Drawing.Point(10, 20);
            this.chartV3.Name = "chartV3";
            series30.ChartArea = "ChartArea1";
            series30.Legend = "Legend1";
            series30.Name = "randomSeries";
            this.chartV3.Series.Add(series30);
            this.chartV3.Size = new System.Drawing.Size(650, 120);
            this.chartV3.TabIndex = 0;
            this.chartV3.Text = "V3";
            this.chartV3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartV3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 911);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.randomData);
            this.MinimumSize = new System.Drawing.Size(1050, 950);
            this.Name = "Form1";
            this.Text = "MAVIS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartA1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartV2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartA3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartV3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartV1;
        private System.Windows.Forms.Button randomData;
        private System.Windows.Forms.TextBox tb_min_1;
        private System.Windows.Forms.Button UpdataLimits_1;
        private System.Windows.Forms.Label label_min_1;
        private System.Windows.Forms.TextBox tb_max_1;
        private System.Windows.Forms.Label label_max_1;
        private System.Windows.Forms.CheckBox cb_min_1;
        private System.Windows.Forms.CheckBox cb_max_1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartA1;
        private System.Windows.Forms.Button Zeroize_1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_max_2;
        private System.Windows.Forms.CheckBox cb_min_2;
        private System.Windows.Forms.Label label_max_2;
        private System.Windows.Forms.Label label_min_2;
        private System.Windows.Forms.TextBox tb_max_2;
        private System.Windows.Forms.TextBox tb_min_2;
        private System.Windows.Forms.Button Zeroize_2;
        private System.Windows.Forms.Button UpdataLimits_2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartA2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartV2;
        private System.Windows.Forms.GroupBox groupBox3;
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
    }
}

