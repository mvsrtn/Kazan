using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace grafikdeneme
{
    public partial class LVT : Form
    {
        public LVT()
        {
            InitializeComponent();
            ReadScalesForCalibration();
        }

        private void ReadScalesForCalibration()
        {
            string fullPathToFile = System.Windows.Forms.Application.StartupPath + "\\parameters.txt";
            StreamReader stream_calib = new StreamReader(fullPathToFile);
            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string temp = Regex.Replace(stream_calib.ReadToEnd(), "[.,]", separator);
            stream_calib.Close();
            string[] hede = temp.Split('\t', '\n', '\r', ';');
            string[] parameters = new string[255];
            int ii = 0;
            for (int i = 0; i < hede.Length; i++)
            {
                if (hede[i].Length != 0)
                {
                    parameters[ii] = hede[i];
                    ii = ii + 1;
                }
            }
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == "#Scale")
                {
                    while (true)
                    {
                        i++;
                        if (parameters[i] == "#RMS")
                        {
                            break;
                        }
                        if (parameters[i] != "")
                        {
                            Cb_AkimSkala.Items.Add(parameters[i]);
                        }
                    }
                }
                if (parameters[i] == "#RMS")
                {
                    int count = 0;
                    while (true)
                    {
                        i++;
                        if (parameters[i] == "#PEAK")
                        {
                            break;
                        }
                        if (parameters[i] != "")
                        {
                            L1_RMS_params[count] = Convert.ToDouble(parameters[i]);
                            i++;
                            L2_RMS_params[count] = Convert.ToDouble(parameters[i]);
                            i++;
                            L3_RMS_params[count] = Convert.ToDouble(parameters[i]);
                            count++;
                        }
                    }
                } 
                if (parameters[i] == "#PEAK")
                {
                    int count = 0;
                    while (true)
                    {
                        i++;
                        if (parameters[i] == "#END")
                        {
                            break;
                        }
                        if (parameters[i] != "")
                        {
                            L1_PEAK_params[count] = Convert.ToDouble(parameters[i]);
                            i++;
                            L2_PEAK_params[count] = Convert.ToDouble(parameters[i]);
                            i++;
                            L3_PEAK_params[count] = Convert.ToDouble(parameters[i]);
                            count++;
                        }
                    }
                }
            }
        }

        private void AcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel dosyaları (*.xls)|*V1.csv"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Path.GetFullPath(ofd.FileName);
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz.", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // read Data from file
            //double[] ch_clock = new double[6];
            UInt16[] ch_size = new UInt16[6];

            string[] fileList = new string[6];
            string baseName = ofd.FileName.Substring(0, ofd.FileName.Length - 6);

            fileList[0] = baseName + "V1.csv";
            fileList[1] = baseName + "A1.csv";
            fileList[2] = baseName + "V2.csv";
            fileList[3] = baseName + "A2.csv";
            fileList[4] = baseName + "V3.csv";
            fileList[5] = baseName + "A3.csv";
            
            double maxV = double.MinValue;
            double minV = double.MaxValue;
            double maxA = double.MinValue;
            double minA = double.MaxValue;

            //V1
            chart_V1.Series[0].Points.Clear();
            ReadData(fileList[0], out ch_clock[0], out ch_size[0], out V1_Data);
            for (int ii = 0; ii < V1_Data.Count; ii++)
            {
                chart_V1.Series[0].Points.AddXY(ii * ch_clock[0]*10/V1_Data.Count, V1_Data[ii]);
            }
            foreach (double type in V1_Data)
            {
                if (type > maxV)
                {
                    maxV = type;
                }
            }
            foreach (double type in V1_Data)
            {
                if (type < minV)
                {
                    minV = type;
                }
            }
            chart_V1.Series[0].Color = Color.Blue;
            chart_V1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart_V1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart_V1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart_V1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart_V1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart_V1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            
            //A1
            chart_A1.Series[0].Points.Clear();
            ReadData(fileList[1], out ch_clock[1], out ch_size[1], out A1_Data);
            for (int ii = 0; ii < A1_Data.Count; ii++)
            {
                chart_A1.Series[0].Points.AddXY(ii * ch_clock[1] * 10 / A1_Data.Count, A1_Data[ii]);
            }
            foreach (double type in A1_Data)
            {
                if (type > maxA)
                {
                    maxA = type;
                }
            }
            foreach (double type in A1_Data)
            {
                if (type < minA)
                {
                    minA = type;
                }
            }
            chart_A1.Series[0].Color = Color.Red;
            chart_A1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart_A1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart_A1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart_A1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart_A1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart_A1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            //V2
            chart_V2.Series[0].Points.Clear();
            ReadData(fileList[2], out ch_clock[2], out ch_size[2], out V2_Data);
            for (int ii = 0; ii < V2_Data.Count; ii++)
            {
                chart_V2.Series[0].Points.AddXY(ii * ch_clock[2] * 10 / V2_Data.Count, V2_Data[ii]);
            }
            foreach (double type in V2_Data)
            {
                if (type > maxV)
                {
                    maxV = type;
                }
            }
            foreach (double type in V2_Data)
            {
                if (type < minV)
                {
                    minV = type;
                }
            }
            chart_V2.Series[0].Color = Color.Green;
            chart_V2.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart_V2.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart_V2.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart_V2.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart_V2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart_V2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            //A2
            chart_A2.Series[0].Points.Clear();
            ReadData(fileList[3], out ch_clock[3], out ch_size[3], out A2_Data);
            for (int ii = 0; ii < A2_Data.Count; ii++)
            {
                chart_A2.Series[0].Points.AddXY(ii * ch_clock[3] * 10 / A2_Data.Count, A2_Data[ii]);
            }
            foreach (double type in A2_Data)
            {
                if (type > maxA)
                {
                    maxA = type;
                }
            }
            foreach (double type in A2_Data)
            {
                if (type < minA)
                {
                    minA = type;
                }
            }
            chart_A2.Series[0].Color = Color.Magenta;
            chart_A2.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart_A2.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart_A2.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart_A2.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart_A2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart_A2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            //V3
            chart_V3.Series[0].Points.Clear();
            ReadData(fileList[4], out ch_clock[4], out ch_size[4], out V3_Data);
            for (int ii = 0; ii < V3_Data.Count; ii++)
            {
                chart_V3.Series[0].Points.AddXY(ii * ch_clock[4] * 10 / V3_Data.Count, V3_Data[ii]);
            }
            foreach (double type in V3_Data)
            {
                if (type > maxV)
                {
                    maxV = type;
                }
            }
            foreach (double type in V3_Data)
            {
                if (type < minV)
                {
                    minV = type;
                }
            }
            chart_V3.Series[0].Color = Color.Orange;
            chart_V3.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart_V3.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart_V3.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart_V3.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart_V3.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart_V3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            //A3
            chart_A3.Series[0].Points.Clear();
            ReadData(fileList[5], out ch_clock[5], out ch_size[5], out A3_Data);
            for (int ii = 0; ii < A3_Data.Count; ii++)
            {
                chart_A3.Series[0].Points.AddXY(ii * ch_clock[5] * 10 / A3_Data.Count, A3_Data[ii]);
            }
            foreach (double type in A3_Data)
            {
                if (type > maxA)
                {
                    maxA = type;
                }
            }
            foreach (double type in A3_Data)
            {
                if (type < minA)
                {
                    minA = type;
                }
            }
            chart_A3.Series[0].Color = Color.DarkBlue;
            chart_A3.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart_A3.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart_A3.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart_A3.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart_A3.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart_A3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            //Axisleri ayarla
            double ucdeger = 0;
            double V_AdimAraligi = 0;
            if ( Math.Abs(maxV) > Math.Abs(minV) )
            {
                ucdeger = Math.Abs(maxV);
            }
            else
            {
                ucdeger = Math.Abs(minV);
            }
            V_AdimAraligi = Math.Ceiling (ucdeger / 30) * 10;
            chart_V1.ChartAreas[0].AxisY.Maximum = V_AdimAraligi * 3;
            chart_V1.ChartAreas[0].AxisY.Minimum = V_AdimAraligi * (-3);
            chart_V1.ChartAreas[0].AxisY.Interval = V_AdimAraligi;
            chart_V2.ChartAreas[0].AxisY.Maximum = V_AdimAraligi * 3;
            chart_V2.ChartAreas[0].AxisY.Minimum = V_AdimAraligi * (-3);
            chart_V2.ChartAreas[0].AxisY.Interval = V_AdimAraligi;
            chart_V3.ChartAreas[0].AxisY.Maximum = V_AdimAraligi * 3;
            chart_V3.ChartAreas[0].AxisY.Minimum = V_AdimAraligi * (-3);
            chart_V3.ChartAreas[0].AxisY.Interval = V_AdimAraligi;

            double A_AdimAraligi = 0;
            if (Math.Abs(maxA) > Math.Abs(minA))
            {
                ucdeger = Math.Abs(maxA);
            }
            else
            {
                ucdeger = Math.Abs(minA);
            }
            A_AdimAraligi = Math.Ceiling(ucdeger*10 / 3) / 10;
            chart_A1.ChartAreas[0].AxisY.Maximum = A_AdimAraligi * 3;
            chart_A1.ChartAreas[0].AxisY.Minimum = A_AdimAraligi * (-3);
            chart_A1.ChartAreas[0].AxisY.Interval = A_AdimAraligi;
            chart_A2.ChartAreas[0].AxisY.Maximum = A_AdimAraligi * 3;
            chart_A2.ChartAreas[0].AxisY.Minimum = A_AdimAraligi * (-3);
            chart_A2.ChartAreas[0].AxisY.Interval = A_AdimAraligi;
            chart_A3.ChartAreas[0].AxisY.Maximum = A_AdimAraligi * 3;
            chart_A3.ChartAreas[0].AxisY.Minimum = A_AdimAraligi * (-3);
            chart_A3.ChartAreas[0].AxisY.Interval = A_AdimAraligi;
            
            chart_V1.ChartAreas[0].AxisX.Minimum = 0;
            chart_V1.ChartAreas[0].AxisX.Maximum = ch_clock[0]*10;
            chart_V1.ChartAreas[0].AxisX.Interval = ch_clock[0];
            chart_V2.ChartAreas[0].AxisX.Minimum = 0;
            chart_V2.ChartAreas[0].AxisX.Maximum = ch_clock[1] * 10;
            chart_V2.ChartAreas[0].AxisX.Interval = ch_clock[1];
            chart_V3.ChartAreas[0].AxisX.Minimum = 0;
            chart_V3.ChartAreas[0].AxisX.Maximum = ch_clock[2] * 10;
            chart_V3.ChartAreas[0].AxisX.Interval = ch_clock[2];
            chart_A1.ChartAreas[0].AxisX.Minimum = 0;
            chart_A1.ChartAreas[0].AxisX.Maximum = ch_clock[3] * 10;
            chart_A1.ChartAreas[0].AxisX.Interval = ch_clock[3];
            chart_A2.ChartAreas[0].AxisX.Minimum = 0;
            chart_A2.ChartAreas[0].AxisX.Maximum = ch_clock[4] * 10;
            chart_A2.ChartAreas[0].AxisX.Interval = ch_clock[4];
            chart_A3.ChartAreas[0].AxisX.Minimum = 0;
            chart_A3.ChartAreas[0].AxisX.Maximum = ch_clock[5] * 10;
            chart_A3.ChartAreas[0].AxisX.Interval = ch_clock[5];

            //Refresh graphs
            chart_V1.Refresh();
            chart_A1.Refresh();
            chart_V2.Refresh();
            chart_A2.Refresh();
            chart_V3.Refresh();
            chart_A3.Refresh();

            //Skalaları yaz
            Tb_A_div.Text = Convert.ToString(A_AdimAraligi);
            Tb_v_div.Text = Convert.ToString(V_AdimAraligi);
            Tb_ms_div.Text = Convert.ToString(ch_clock[0]);

            //hesaplamalar
            Hesaplamalar();

            //limitler
            GraphStart.Text = "0";

        }

        private void ReadData(string path, out double ch_clock, out UInt16 ch_size, out List<double> data)
        {
            // Get the number separator for this culture and replace any others with it
            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            int i = 0;
            data = new List<double>();
            //data = new double[0];
            ch_clock = 0;
            ch_size = 0;

            bool flag = true;

            StreamReader readFile = new StreamReader(path);

            while (flag)
            {
                string line = readFile.ReadLine();
                if (line == "" || line == null)
                {
                    flag = false;
                    return;
                }
                if (line.ToCharArray()[0] == '#')
                {
                    string[] temp = line.Split('#');
                    string[] temp2 = temp[1].Split('=');
                    if (temp2[0] == "CLOCK")
                    {
                        string temp_s = Regex.Replace(temp2[1], "[.,]", separator);
                        ch_clock = Convert.ToDouble(temp_s)*1000;
                    }
                    if (temp2[0] == "SIZE")
                    {
                        string temp_s = Regex.Replace(temp2[1], "[.,]", separator);
                        ch_size = Convert.ToUInt16(temp_s);
                        //data = new double[ch_size];
                    }
                }
                else
                {
                    string[] data_line = line.Split(',');
                    string temp_s = Regex.Replace(data_line[0], "[.,]", separator);
                    data.Add(Convert.ToDouble(temp_s));
                    //data[i] = Convert.ToDouble(temp_s);
                    i = i + 1;
                }
            }
            readFile.Close();
        }

        private void Cb_AkimSkala_SelectedIndexChanged(object sender, EventArgs e)
        {
            L1_RMS = L1_RMS_params[Cb_AkimSkala.SelectedIndex];
            L2_RMS = L2_RMS_params[Cb_AkimSkala.SelectedIndex];
            L3_RMS = L3_RMS_params[Cb_AkimSkala.SelectedIndex];
            L1_PEAK = L1_PEAK_params[Cb_AkimSkala.SelectedIndex];
            L2_PEAK = L2_PEAK_params[Cb_AkimSkala.SelectedIndex];
            L3_PEAK = L3_PEAK_params[Cb_AkimSkala.SelectedIndex];

            Hesaplamalar();
        }

        private void RSMHesapla(List<double> data, out double RMS, out double PEAK)
        {
            RMS = 0;
            PEAK = 0;

            if (data.Count == 0)
                return;

            double maxValue = double.MinValue;
            foreach (double temp in data)
            {
                if (temp > maxValue)
                {
                    maxValue = temp;
                }
            }
            double minValue = double.MaxValue;
            foreach (double temp in data)
            {
                if (temp < minValue)
                {
                    minValue = temp;
                }
            }

            RMS = ((maxValue - minValue));// / (2 * Math.Sqrt(2)));
            if (maxValue > Math.Abs(minValue))
            {
                PEAK = maxValue;
            }
            else
            {
                PEAK = minValue;
            }
        }

        private void Hesaplamalar()
        {
        double V1_RMS;
        double V1_PEAK;
        RSMHesapla(V1_Data, out V1_RMS, out V1_PEAK);
        V1_RMS = V1_RMS* L1_RMS;
        V1_PEAK = V1_PEAK* L1_PEAK;
        tb_V1_rms.Text = V1_RMS.ToString("#,##0.000");

        double I1_RMS;
        double I1_PEAK;
        RSMHesapla(A1_Data, out I1_RMS, out I1_PEAK);
        I1_RMS = I1_RMS* L1_RMS;
        I1_PEAK = I1_PEAK* L1_PEAK;
        tb_I1_rms.Text = I1_RMS.ToString("#,##0.000");
        tb_I1_peak.Text = I1_PEAK.ToString("#,##0.000");

        double V2_RMS;
        double V2_PEAK;
        RSMHesapla(V2_Data, out V2_RMS, out V2_PEAK);
        V2_RMS = V2_RMS* L2_RMS;
        V2_PEAK = V2_PEAK* L2_PEAK;
        tb_V2_rms.Text = V2_RMS.ToString("#,##0.000");

        double I2_RMS;
        double I2_PEAK;
        RSMHesapla(A2_Data, out I2_RMS, out I2_PEAK);
        I2_RMS = I2_RMS* L2_RMS;
        I2_PEAK = I2_PEAK* L2_PEAK;
        tb_I2_rms.Text = I2_RMS.ToString("#,##0.000");
        tb_I2_peak.Text = I2_PEAK.ToString("#,##0.000");

        double V3_RMS;
        double V3_PEAK;
        RSMHesapla(V3_Data, out V3_RMS, out V3_PEAK);
        V3_RMS = V3_RMS* L3_RMS;
        V3_PEAK = V3_PEAK* L3_PEAK;
        tb_V3_rms.Text = V3_RMS.ToString("#,##0.000");

        double I3_RMS;
        double I3_PEAK;
        RSMHesapla(A3_Data, out I3_RMS, out I3_PEAK);
        I3_RMS = I3_RMS* L3_RMS;
        I3_PEAK = I3_PEAK* L3_PEAK;
        tb_I3_rms.Text = I3_RMS.ToString("#,##0.000");
        tb_I3_peak.Text = I3_PEAK.ToString("#,##0.000");
        }

        private void AddCursor_L1(object sender, MouseEventArgs e)
        {
            if (L1_zoomed == true)
            {
                L1_zoomed = false;
                chart_V1.Series[0].Points.Clear();
                for (int ii = 0; ii < V1_Data.Count; ii++)
                {
                    chart_V1.Series[0].Points.AddXY(ii * ch_clock[0] * 10 / V1_Data.Count, V1_Data[ii]);
                }
                chart_V1.ChartAreas[0].AxisX.Minimum = 0;
                chart_V1.ChartAreas[0].AxisX.Maximum = ch_clock[0] * 10;
                chart_A1.Series[0].Points.Clear();
                for (int ii = 0; ii < A1_Data.Count; ii++)
                {
                    chart_A1.Series[0].Points.AddXY(ii * ch_clock[0] * 10 / A1_Data.Count, A1_Data[ii]);
                }
                chart_A1.ChartAreas[0].AxisX.Minimum = 0;
                chart_A1.ChartAreas[0].AxisX.Maximum = ch_clock[0] * 10;
                return;
            }
            Point mousePoint = new Point(e.X, e.Y);
            if (L1_cursor_flag == false)
            {
                chart_V1.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chart_A1.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                position = chart_V1.ChartAreas[0].CursorX.Position;
                chart_V1.ChartAreas[0].CursorX.SetSelectionPosition(position,position);
                chart_A1.ChartAreas[0].CursorX.SetSelectionPosition(position, position);
                L1_cursor_flag = true;
                return;
            }
            if (L1_cursor_flag == true)
            {
                chart_V1.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chart_A1.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                double pos = chart_V1.ChartAreas[0].CursorX.Position;
                chart_V1.ChartAreas[0].CursorX.SetSelectionPosition(position, pos);
                chart_A1.ChartAreas[0].CursorX.SetSelectionPosition(position, pos);
                L1_cursor_flag = false;
                if (position < pos)
                {
                    Tb_ilk_ms.Text = Convert.ToString(position);
                    Tb_son_ms.Text = Convert.ToString(pos);
                }
                else
                {
                    Tb_son_ms.Text = Convert.ToString(position);
                    Tb_ilk_ms.Text = Convert.ToString(pos);
                }
                Zoom_L1();
                return;
            }         
        }

        private void Zoom_L1()
        {
            L1_zoomed = true;
            chart_V1.Series[0].Points.Clear();
            chart_A1.Series[0].Points.Clear();
            double stepsize = ch_clock[0] * 10 / V1_Data.Count;
            Double ilkpoint = Convert.ToDouble(Tb_ilk_ms.Text) / stepsize;
            double sonpoint = Convert.ToDouble(Tb_son_ms.Text) / stepsize;
            
            for (double ii = ilkpoint; ii < sonpoint; ii++)
            {
                chart_V1.Series[0].Points.AddXY(ii * ch_clock[0] * 10 / V1_Data.Count, V1_Data[Convert.ToInt16(ii)]);
            }
            for (double ii = ilkpoint; ii < sonpoint; ii++)
            {
                chart_A1.Series[0].Points.AddXY(ii * ch_clock[0] * 10 / A1_Data.Count, A1_Data[Convert.ToInt16(ii)]);
            }

            chart_V1.ChartAreas[0].AxisX.Minimum = ilkpoint * stepsize;
            chart_V1.ChartAreas[0].AxisX.Maximum = sonpoint * stepsize;
            chart_A1.ChartAreas[0].AxisX.Minimum = ilkpoint * stepsize;
            chart_A1.ChartAreas[0].AxisX.Maximum = sonpoint * stepsize;
        }

        private void AddCursor_L2(object sender, MouseEventArgs e)
        {
            if (L2_zoomed == true)
            {
                L2_zoomed = false;
                chart_V2.Series[0].Points.Clear();
                for (int ii = 0; ii < V2_Data.Count; ii++)
                {
                    chart_V2.Series[0].Points.AddXY(ii * ch_clock[0] * 10 / V2_Data.Count, V2_Data[ii]);
                }
                chart_V2.ChartAreas[0].AxisX.Minimum = 0;
                chart_V2.ChartAreas[0].AxisX.Maximum = ch_clock[0] * 10;
                chart_A2.Series[0].Points.Clear();
                for (int ii = 0; ii < A2_Data.Count; ii++)
                {
                    chart_A2.Series[0].Points.AddXY(ii * ch_clock[0] * 10 / A2_Data.Count, A2_Data[ii]);
                }
                chart_A2.ChartAreas[0].AxisX.Minimum = 0;
                chart_A2.ChartAreas[0].AxisX.Maximum = ch_clock[0] * 10;
                return;
            }
            Point mousePoint = new Point(e.X, e.Y);
            if (L2_cursor_flag == false)
            {
                chart_V2.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chart_A2.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                position = chart_V2.ChartAreas[0].CursorX.Position;
                chart_V2.ChartAreas[0].CursorX.SetSelectionPosition(position, position);
                chart_A2.ChartAreas[0].CursorX.SetSelectionPosition(position, position);
                L2_cursor_flag = true;
                return;
            }
            if (L2_cursor_flag == true)
            {
                chart_V2.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chart_A2.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                double pos = chart_V2.ChartAreas[0].CursorX.Position;
                chart_V2.ChartAreas[0].CursorX.SetSelectionPosition(position, pos);
                chart_A2.ChartAreas[0].CursorX.SetSelectionPosition(position, pos);
                L2_cursor_flag = false;
                if (position < pos)
                {
                    Tb_ilk_ms.Text = Convert.ToString(position);
                    Tb_son_ms.Text = Convert.ToString(pos);
                }
                else
                {
                    Tb_son_ms.Text = Convert.ToString(position);
                    Tb_ilk_ms.Text = Convert.ToString(pos);
                }
                Zoom_L2();
                return;
            }
        }

        private void Zoom_L2()
        {
            L2_zoomed = true;
            chart_V2.Series[0].Points.Clear();
            chart_A2.Series[0].Points.Clear();
            double stepsize = ch_clock[0] * 10 / V2_Data.Count;
            Double ilkpoint = Convert.ToDouble(Tb_ilk_ms.Text) / stepsize;
            double sonpoint = Convert.ToDouble(Tb_son_ms.Text) / stepsize;

            for (double ii = ilkpoint; ii < sonpoint; ii++)
            {
                chart_V2.Series[0].Points.AddXY(ii * ch_clock[0] * 10 / V2_Data.Count, V2_Data[Convert.ToInt16(ii)]);
            }
            for (double ii = ilkpoint; ii < sonpoint; ii++)
            {
                chart_A2.Series[0].Points.AddXY(ii * ch_clock[0] * 10 / A2_Data.Count, A2_Data[Convert.ToInt16(ii)]);
            }

            chart_V2.ChartAreas[0].AxisX.Minimum = ilkpoint * stepsize;
            chart_V2.ChartAreas[0].AxisX.Maximum = sonpoint * stepsize;
            chart_A2.ChartAreas[0].AxisX.Minimum = ilkpoint * stepsize;
            chart_A2.ChartAreas[0].AxisX.Maximum = sonpoint * stepsize;
        }

        private void AddCursor_L3(object sender, MouseEventArgs e)
        {
            if (L3_zoomed == true)
            {
                L3_zoomed = false;
                chart_V3.Series[0].Points.Clear();
                for (int ii = 0; ii < V3_Data.Count; ii++)
                {
                    chart_V3.Series[0].Points.AddXY(ii * ch_clock[0] * 10 / V3_Data.Count, V3_Data[ii]);
                }
                chart_V3.ChartAreas[0].AxisX.Minimum = 0;
                chart_V3.ChartAreas[0].AxisX.Maximum = ch_clock[0] * 10;
                chart_A3.Series[0].Points.Clear();
                for (int ii = 0; ii < A3_Data.Count; ii++)
                {
                    chart_A3.Series[0].Points.AddXY(ii * ch_clock[0] * 10 / A3_Data.Count, A3_Data[ii]);
                }
                chart_A3.ChartAreas[0].AxisX.Minimum = 0;
                chart_A3.ChartAreas[0].AxisX.Maximum = ch_clock[0] * 10;
                return;
            }
            Point mousePoint = new Point(e.X, e.Y);
            if (L3_cursor_flag == false)
            {
                chart_V3.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chart_A3.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                position = chart_V3.ChartAreas[0].CursorX.Position;
                chart_V3.ChartAreas[0].CursorX.SetSelectionPosition(position, position);
                chart_A3.ChartAreas[0].CursorX.SetSelectionPosition(position, position);
                L3_cursor_flag = true;
                return;
            }
            if (L3_cursor_flag == true)
            {
                chart_V3.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chart_A3.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                double pos = chart_V3.ChartAreas[0].CursorX.Position;
                chart_V3.ChartAreas[0].CursorX.SetSelectionPosition(position, pos);
                chart_A3.ChartAreas[0].CursorX.SetSelectionPosition(position, pos);
                L3_cursor_flag = false;
                if (position < pos)
                {
                    Tb_ilk_ms.Text = Convert.ToString(position);
                    Tb_son_ms.Text = Convert.ToString(pos);
                }
                else
                {
                    Tb_son_ms.Text = Convert.ToString(position);
                    Tb_ilk_ms.Text = Convert.ToString(pos);
                }
                Zoom_L3();
                return;
            }
        }

        private void Zoom_L3()
        {
            L3_zoomed = true;
            chart_V3.Series[0].Points.Clear();
            chart_A3.Series[0].Points.Clear();
            double stepsize = ch_clock[0] * 10 / V3_Data.Count;
            Double ilkpoint = Convert.ToDouble(Tb_ilk_ms.Text) / stepsize;
            double sonpoint = Convert.ToDouble(Tb_son_ms.Text) / stepsize;

            for (double ii = ilkpoint; ii < sonpoint; ii++)
            {
                chart_V3.Series[0].Points.AddXY(ii * ch_clock[0] * 10 / V3_Data.Count, V3_Data[Convert.ToInt16(ii)]);
            }
            for (double ii = ilkpoint; ii < sonpoint; ii++)
            {
                chart_A3.Series[0].Points.AddXY(ii * ch_clock[0] * 10 / A3_Data.Count, A3_Data[Convert.ToInt16(ii)]);
            }

            chart_V3.ChartAreas[0].AxisX.Minimum = ilkpoint * stepsize;
            chart_V3.ChartAreas[0].AxisX.Maximum = sonpoint * stepsize;
            chart_A3.ChartAreas[0].AxisX.Minimum = ilkpoint * stepsize;
            chart_A3.ChartAreas[0].AxisX.Maximum = sonpoint * stepsize;
        }

        private void OlcumAraligiHesapla(object sender, EventArgs e)
        {
            if ((Tb_son_ms.Text == "") || (Tb_ilk_ms.Text == ""))
                return;
            Tb_olcum_araligi.Text = Convert.ToString(Convert.ToDouble(Tb_son_ms.Text)-Convert.ToDouble(Tb_ilk_ms.Text));
        }

        private void I2t_hesapla(object sender, EventArgs e)
        {
            //L1
            if ((Tb_olcum_araligi.Text != "") && (tb_I1_rms.Text != ""))
                Tb_ch1_I2t.Text = Convert.ToString(Convert.ToDouble(tb_I1_rms.Text) * Convert.ToDouble(tb_I1_rms.Text) * Convert.ToDouble(Tb_olcum_araligi.Text));
            
            //L2
            if ((Tb_olcum_araligi.Text != "") && (tb_I2_rms.Text != ""))
                Tb_ch2_I2t.Text = Convert.ToString(Convert.ToDouble(tb_I2_rms.Text) * Convert.ToDouble(tb_I2_rms.Text) * Convert.ToDouble(Tb_olcum_araligi.Text));
            //L1
            if ((Tb_olcum_araligi.Text != "") && (tb_I3_rms.Text != ""))
                Tb_ch3_I2t.Text = Convert.ToString(Convert.ToDouble(tb_I3_rms.Text) * Convert.ToDouble(tb_I3_rms.Text) * Convert.ToDouble(Tb_olcum_araligi.Text));

        }
    }
}
