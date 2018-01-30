using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace grafikdeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void randomData_Click(object sender, EventArgs e)
        {
            Random rdn = new Random();
            for (int i = 0; i <= 100; i++)
            {
                chartV1.Series["randomSeries"].Points.AddXY(i, rdn.Next(0, 100));
                chartV2.Series["randomSeries"].Points.AddXY(i, rdn.Next(0, 100));
                chartV3.Series["randomSeries"].Points.AddXY(i, rdn.Next(0, 100));
            }
            chartV1.ChartAreas[0].AxisX.Maximum = 100;
            chartV1.ChartAreas[0].AxisX.Minimum = 0;
            chartV1.Series["randomSeries"].ChartType = SeriesChartType.FastLine;
            chartV1.Series["randomSeries"].Color = Color.Red;
            chartV2.ChartAreas[0].AxisX.Maximum = 100;
            chartV2.ChartAreas[0].AxisX.Minimum = 0;
            chartV2.Series["randomSeries"].ChartType = SeriesChartType.FastLine;
            chartV2.Series["randomSeries"].Color = Color.Red;
            chartV3.ChartAreas[0].AxisX.Maximum = 100;
            chartV3.ChartAreas[0].AxisX.Minimum = 0;
            chartV3.Series["randomSeries"].ChartType = SeriesChartType.FastLine;
            chartV3.Series["randomSeries"].Color = Color.Red;

            for (int i = 0; i <= 100; i++)
            {
                chartA1.Series["randomSeries"].Points.AddXY(i, rdn.Next(0, 100));
                chartA2.Series["randomSeries"].Points.AddXY(i, rdn.Next(0, 100));
                chartA3.Series["randomSeries"].Points.AddXY(i, rdn.Next(0, 100));
            }
            chartA1.ChartAreas[0].AxisX.Maximum = 100;
            chartA1.ChartAreas[0].AxisX.Minimum = 0;
            chartA1.Series["randomSeries"].ChartType = SeriesChartType.FastLine;
            chartA1.Series["randomSeries"].Color = Color.Blue;
            chartA2.ChartAreas[0].AxisX.Maximum = 100;
            chartA2.ChartAreas[0].AxisX.Minimum = 0;
            chartA2.Series["randomSeries"].ChartType = SeriesChartType.FastLine;
            chartA2.Series["randomSeries"].Color = Color.Blue;
            chartA3.ChartAreas[0].AxisX.Maximum = 100;
            chartA3.ChartAreas[0].AxisX.Minimum = 0;
            chartA3.Series["randomSeries"].ChartType = SeriesChartType.FastLine;
            chartA3.Series["randomSeries"].Color = Color.Blue;

        }

        private void chartV1_Click(object sender, MouseEventArgs e)
        {
            Axis ax = chartV1.ChartAreas[0].AxisX;

            //double Xpoint;
            double clickedX = ax.PixelPositionToValue(e.X);
            double temp = double.MaxValue;
            string tempstr = "";

            foreach (DataPoint dp in chartV1.Series[0].Points)
            {
                if (Math.Abs(dp.XValue - clickedX) < temp)
                {
                    temp = Math.Abs(dp.XValue - clickedX);
                    tempstr = dp.XValue.ToString();                  
                }
                else
                    break;
            }

            if (cb_min_1.Checked == true)
            {
                tb_min_1.Text = tempstr;
                cb_min_1.Checked = false;
            }
            if (cb_max_1.Checked == true)
            {
                tb_max_1.Text = tempstr;
                cb_max_1.Checked = false;
            }
            
        }

        private void chartA1_Click(object sender, MouseEventArgs e)
        {
            Axis ax = chartA1.ChartAreas[0].AxisX;

            //double Xpoint;
            double clickedX = ax.PixelPositionToValue(e.X);
            double temp = double.MaxValue;
            string tempstr = "";

            foreach (DataPoint dp in chartA1.Series[0].Points)
            {
                if (Math.Abs(dp.XValue - clickedX) < temp)
                {
                    temp = Math.Abs(dp.XValue - clickedX);
                    tempstr = dp.XValue.ToString();
                }
                else
                    break;
            }

            if (cb_min_1.Checked == true)
            {
                tb_min_1.Text = tempstr;
                cb_min_1.Checked = false;
            }
            if (cb_max_1.Checked == true)
            {
                tb_max_1.Text = tempstr;
                cb_max_1.Checked = false;
            }

        }
                
        private void UpdateLimits_1_Click(object sender, EventArgs e)
        {

            if (tb_min_1.Text.Length == 0)
            {
                MessageBox.Show("Grafik Minimum Değeri Boş Bırakılamaz", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tb_max_1.Text.Length == 0)
            {
                MessageBox.Show("Grafik Maximum Değeri Boş Bırakılamaz", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Int32.Parse(tb_min_1.Text) >= Int32.Parse(tb_max_1.Text))
            {
                MessageBox.Show("Grafik Minimum Değeri Grafik Maksimum Değerinden Küçük Olamaz", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            chartV1.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_1.Text);
            chartV1.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_1.Text);
            chartA1.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_1.Text);
            chartA1.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_1.Text);
                       
        }

        private void cb_min_1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_min_1.Checked == true)
                cb_max_1.Checked = false;
        }

        private void cb_max_1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_max_1.Checked == true)
                cb_min_1.Checked = false;
        }

        private void Zeroize_1_Click(object sender, EventArgs e)
        {
            tb_max_1.Text = (chartA1.Series[0].Points.Count - 1).ToString();
            tb_min_1.Text = "0";

            
            chartV1.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_1.Text);
            chartV1.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_1.Text);
            chartA1.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_1.Text);
            chartA1.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_1.Text);
        }

        
        private void chartV2_Click(object sender, MouseEventArgs e)
        {
            Axis ax = chartV2.ChartAreas[0].AxisX;

            //double Xpoint;
            double clickedX = ax.PixelPositionToValue(e.X);
            double temp = double.MaxValue;
            string tempstr = "";

            foreach (DataPoint dp in chartV2.Series[0].Points)
            {
                if (Math.Abs(dp.XValue - clickedX) < temp)
                {
                    temp = Math.Abs(dp.XValue - clickedX);
                    tempstr = dp.XValue.ToString();
                }
                else
                    break;
            }

            if (cb_min_2.Checked == true)
            {
                tb_min_2.Text = tempstr;
                cb_min_2.Checked = false;
            }
            if (cb_max_2.Checked == true)
            {
                tb_max_2.Text = tempstr;
                cb_max_2.Checked = false;
            }

        }

        private void chartA2_Click(object sender, MouseEventArgs e)
        {
            Axis ax = chartA2.ChartAreas[0].AxisX;

            //double Xpoint;
            double clickedX = ax.PixelPositionToValue(e.X);
            double temp = double.MaxValue;
            string tempstr = "";

            foreach (DataPoint dp in chartA2.Series[0].Points)
            {
                if (Math.Abs(dp.XValue - clickedX) < temp)
                {
                    temp = Math.Abs(dp.XValue - clickedX);
                    tempstr = dp.XValue.ToString();
                }
                else
                    break;
            }

            if (cb_min_2.Checked == true)
            {
                tb_min_2.Text = tempstr;
                cb_min_2.Checked = false;
            }
            if (cb_max_2.Checked == true)
            {
                tb_max_2.Text = tempstr;
                cb_max_2.Checked = false;
            }

        }

        private void UpdateLimits_2_Click(object sender, EventArgs e)
        {

            if (tb_min_2.Text.Length == 0)
            {
                MessageBox.Show("Grafik Minimum Değeri Boş Bırakılamaz", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tb_max_2.Text.Length == 0)
            {
                MessageBox.Show("Grafik Maximum Değeri Boş Bırakılamaz", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Int32.Parse(tb_min_2.Text) >= Int32.Parse(tb_max_2.Text))
            {
                MessageBox.Show("Grafik Minimum Değeri Grafik Maksimum Değerinden Küçük Olamaz", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            chartV2.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_2.Text);
            chartV2.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_2.Text);
            chartA2.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_2.Text);
            chartA2.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_2.Text);

        }

        private void cb_min_2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_min_2.Checked == true)
                cb_max_2.Checked = false;
        }

        private void cb_max_2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_max_2.Checked == true)
                cb_min_2.Checked = false;
        }
        
        private void Zeroize_2_Click(object sender, EventArgs e)
        {
            tb_max_2.Text = (chartA2.Series[0].Points.Count - 1).ToString();
            tb_min_2.Text = "0";


            chartV2.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_2.Text);
            chartV2.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_2.Text);
            chartA2.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_2.Text);
            chartA2.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_2.Text);
        }



        private void chartV3_Click(object sender, MouseEventArgs e)
        {
            Axis ax = chartV3.ChartAreas[0].AxisX;

            //double Xpoint;
            double clickedX = ax.PixelPositionToValue(e.X);
            double temp = double.MaxValue;
            string tempstr = "";

            foreach (DataPoint dp in chartV3.Series[0].Points)
            {
                if (Math.Abs(dp.XValue - clickedX) < temp)
                {
                    temp = Math.Abs(dp.XValue - clickedX);
                    tempstr = dp.XValue.ToString();
                }
                else
                    break;
            }

            if (cb_min_3.Checked == true)
            {
                tb_min_3.Text = tempstr;
                cb_min_3.Checked = false;
            }
            if (cb_max_3.Checked == true)
            {
                tb_max_3.Text = tempstr;
                cb_max_3.Checked = false;
            }

        }

        private void chartA3_Click(object sender, MouseEventArgs e)
        {
            Axis ax = chartA3.ChartAreas[0].AxisX;

            //double Xpoint;
            double clickedX = ax.PixelPositionToValue(e.X);
            double temp = double.MaxValue;
            string tempstr = "";

            foreach (DataPoint dp in chartA3.Series[0].Points)
            {
                if (Math.Abs(dp.XValue - clickedX) < temp)
                {
                    temp = Math.Abs(dp.XValue - clickedX);
                    tempstr = dp.XValue.ToString();
                }
                else
                    break;
            }

            if (cb_min_3.Checked == true)
            {
                tb_min_3.Text = tempstr;
                cb_min_3.Checked = false;
            }
            if (cb_max_3.Checked == true)
            {
                tb_max_3.Text = tempstr;
                cb_max_3.Checked = false;
            }

        }

        private void UpdateLimits_3_Click(object sender, EventArgs e)
        {

            if (tb_min_3.Text.Length == 0)
            {
                MessageBox.Show("Grafik Minimum Değeri Boş Bırakılamaz", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tb_max_3.Text.Length == 0)
            {
                MessageBox.Show("Grafik Maximum Değeri Boş Bırakılamaz", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Int32.Parse(tb_min_3.Text) >= Int32.Parse(tb_max_3.Text))
            {
                MessageBox.Show("Grafik Minimum Değeri Grafik Maksimum Değerinden Küçük Olamaz", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            chartV3.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_3.Text);
            chartV3.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_3.Text);
            chartA3.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_3.Text);
            chartA3.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_3.Text);

        }

        private void cb_min_3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_min_3.Checked == true)
                cb_max_3.Checked = false;
        }

        private void cb_max_3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_max_3.Checked == true)
                cb_min_3.Checked = false;
        }

        private void Zeroize_3_Click(object sender, EventArgs e)
        {
            tb_max_3.Text = (chartA3.Series[0].Points.Count - 1).ToString();
            tb_min_3.Text = "0";


            chartV3.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_3.Text);
            chartV3.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_3.Text);
            chartA3.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_3.Text);
            chartA3.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_3.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (Properties.Settings.Default.F1Size.Width == 0) Properties.Settings.Default.Upgrade();

            if (Properties.Settings.Default.F1Size.Width == 0 || Properties.Settings.Default.F1Size.Height == 0)
            {
                // first start
                // optional: add default values
            }
            else
            {
                this.WindowState = Properties.Settings.Default.F1State;

                // we don't want a minimized window at startup
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;

                this.Location = Properties.Settings.Default.F1Location;
                this.Size = Properties.Settings.Default.F1Size;                
            }

            this.Kesici_1_A.BackColor = Color.Red;
            this.Kesici_1_B.BackColor = Color.Red;
            this.Kesici_1_C.BackColor = Color.Red;
            this.Kesici_2_A.BackColor = Color.Red;
            this.Kesici_2_B.BackColor = Color.Red;
            this.Kesici_2_C.BackColor = Color.Red;



        }

        private void Kesici_1_A_Click(object sender, EventArgs e)
        {
            if (this.Kesici_1_A.BackColor == Color.Red)
                this.Kesici_1_A.BackColor = Color.Green;
            else if (this.Kesici_1_A.BackColor == Color.Green)
                this.Kesici_1_A.BackColor = Color.Red;
        }

        private void Kesici_1_B_Click(object sender, EventArgs e)
        {
            if (this.Kesici_1_B.BackColor == Color.Red)
                this.Kesici_1_B.BackColor = Color.Green;
            else if (this.Kesici_1_B.BackColor == Color.Green)
                this.Kesici_1_B.BackColor = Color.Red;
        }

        private void Kesici_1_C_Click(object sender, EventArgs e)
        {
            if (this.Kesici_1_C.BackColor == Color.Red)
                this.Kesici_1_C.BackColor = Color.Green;
            else if (this.Kesici_1_C.BackColor == Color.Green)
                this.Kesici_1_C.BackColor = Color.Red;
        }

        private void Kesici_2_A_Click(object sender, EventArgs e)
        {
            if (this.Kesici_2_A.BackColor == Color.Red)
                this.Kesici_2_A.BackColor = Color.Green;
            else if (this.Kesici_2_A.BackColor == Color.Green)
                this.Kesici_2_A.BackColor = Color.Red;
        }

        private void Kesici_2_B_Click(object sender, EventArgs e)
        {
            if (this.Kesici_2_B.BackColor == Color.Red)
                this.Kesici_2_B.BackColor = Color.Green;
            else if (this.Kesici_2_B.BackColor == Color.Green)
                this.Kesici_2_B.BackColor = Color.Red;
        }

        private void Kesici_2_C_Click(object sender, EventArgs e)
        {
            if (this.Kesici_2_C.BackColor == Color.Red)
                this.Kesici_2_C.BackColor = Color.Green;
            else if (this.Kesici_2_C.BackColor == Color.Green)
                this.Kesici_2_C.BackColor = Color.Red;
        }


        /*
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.F1State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                Properties.Settings.Default.F1Location = this.Location;
                Properties.Settings.Default.F1Size = this.Size;
            }
            else
            {
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.F1Location = this.RestoreBounds.Location;
                Properties.Settings.Default.F1Size = this.RestoreBounds.Size;
            }

            // don't forget to save the settings
            Properties.Settings.Default.Save();
        }*/


    }
}


