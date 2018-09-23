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
            double[] ch_clock = new double[6];
            UInt16[] ch_size = new UInt16[6];

            string[] fileList = new string[6];
            string baseName = ofd.FileName.Substring(0, ofd.FileName.Length - 6);

            fileList[0] = baseName + "V1.csv";
            fileList[1] = baseName + "A1.csv";
            fileList[2] = baseName + "V2.csv";
            fileList[3] = baseName + "A2.csv";
            fileList[4] = baseName + "V3.csv";
            fileList[5] = baseName + "A3.csv";

            //V1
            ReadData(fileList[0], out ch_clock[0], out ch_size[0], out V1_Data);
            for (int ii = 0; ii <V1_Data.Count; ii++)
            {
                chart_V1.Series[0].Points.AddXY(ii, V1_Data[ii]);
            }
            chart_V1.Series[0].Color = Color.Blue;
            chart_V1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart_V1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart_V1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart_V1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart_V1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart_V1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            //A1
            ReadData(fileList[1], out ch_clock[1], out ch_size[1], out A1_Data);
            for (int ii = 0; ii < A1_Data.Count; ii++)
            {
                chart_A1.Series[0].Points.AddXY(ii, A1_Data[ii]);
            }
            chart_A1.Series[0].Color = Color.Red;
            chart_A1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart_A1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart_A1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart_A1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart_A1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart_A1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            //V2
            ReadData(fileList[2], out ch_clock[2], out ch_size[2], out V2_Data);
            for (int ii = 0; ii < V2_Data.Count; ii++)
            {
                chart_V2.Series[0].Points.AddXY(ii, V2_Data[ii]);
            }
            chart_V2.Series[0].Color = Color.Green;
            chart_V2.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart_V2.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart_V2.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart_V2.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart_V2.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart_V2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            //A2
            ReadData(fileList[3], out ch_clock[3], out ch_size[3], out A2_Data);
            for (int ii = 0; ii < A2_Data.Count; ii++)
            {
                chart_A2.Series[0].Points.AddXY(ii, A2_Data[ii]);
            }
            chart_A2.Series[0].Color = Color.Magenta;
            chart_A2.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart_A2.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart_A2.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart_A2.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart_A2.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart_A2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            //V3
            ReadData(fileList[4], out ch_clock[4], out ch_size[4], out V3_Data);
            for (int ii = 0; ii < V3_Data.Count; ii++)
            {
                chart_V3.Series[0].Points.AddXY(ii, V3_Data[ii]);
            }
            chart_V3.Series[0].Color = Color.Orange;
            chart_V3.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart_V3.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart_V3.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart_V3.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart_V3.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart_V3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            //A3
            ReadData(fileList[5], out ch_clock[5], out ch_size[5], out A3_Data);
            for (int ii = 0; ii < A3_Data.Count; ii++)
            {
                chart_A3.Series[0].Points.AddXY(ii, A3_Data[ii]);
            }
            chart_A3.Series[0].Color = Color.DarkBlue;
            chart_A3.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart_A3.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart_A3.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart_A3.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart_A3.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart_A3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            //chartMain.Refresh();
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
                        ch_clock = Convert.ToDouble(temp_s);
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

        }
    }
}
