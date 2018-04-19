using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.IO.Ports;
using System.Globalization;
using System.Text.RegularExpressions;

namespace grafikdeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            //SetPortConfig();
        }

        private int SetPortConfig()
        {
            sp.Close();
            string fullPathToFile = System.Windows.Forms.Application.StartupPath + "\\PortSettings.txt";
            StreamReader stream_ayarlar = new StreamReader(fullPathToFile);
            string temp = stream_ayarlar.ReadToEnd();
            stream_ayarlar.Close();
            string[] ayarlar = temp.Split();
            char[] delimeters = new char[] { '#', ':', ' ' };
            for (int i = 0; i < ayarlar.Length; i++)
            {
                string[] satir = ayarlar[i].Split(delimeters);
                if (ayarlar[i] == "")
                    continue;
                switch (satir[1])
                {
                    case "PortName":
                        sp.PortName = satir[2];
                        break;
                    case "BaudRate":
                        sp.BaudRate = Convert.ToInt32(satir[2]);
                        break;
                    case "StopBits":
                        switch (satir[2])
                        {
                            case "0.0": //Stop bit 0 olamaz
                                //sp.StopBits = None; 
                                break;
                            case "1.0":
                                sp.StopBits = StopBits.One;
                                break;
                            case "1.5":
                                sp.StopBits = StopBits.OnePointFive;
                                break;
                            case "2.0":
                                sp.StopBits = StopBits.Two;
                                break;
                            default:
                                sp.StopBits = StopBits.One;
                                break;
                        }
                        break;
                    case "Parity":
                        switch (satir[2])
                        {
                            case "Even":
                                sp.Parity = Parity.Even;
                                break;
                            case "Mark":
                                sp.Parity = Parity.Mark;
                                break;
                            case "None":
                                sp.Parity = Parity.None;
                                break;
                            case "Odd":
                                sp.Parity = Parity.Odd;
                                break;
                            case "Space":
                                sp.Parity = Parity.Space;
                                break;
                            default:
                                sp.Parity = Parity.None;
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            try
            {
                sp.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Port Başlatılamadı!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
            return 0;
        }

        private void PortAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int error = SetPortConfig();
            if (error == 1)
                return;
            MessageBox.Show("Haberleşme Ayarları Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DataReceivedHandler(object sender, EventArgs e)
        {
             if (sp.ReadByte() == 0xCD)
            {
                if (sp.ReadByte() == 0xAB)
                {
                    int temp = sp.ReadByte();
                    // Zaman yükleme komutu cevabı
                    if (temp == 0x54)
                    {
                        int surehigh = sp.ReadByte();
                        int surelow = sp.ReadByte();
                        int sure = surehigh * 256 + surelow;
                        if (sure == Int16.Parse(tb_ZamanYukle.Text))
                            cb_zamanayarlandı.Checked = true;
                        else
                            cb_zamanayarlandı.Checked = false;
                    }
                    // Teste başla komutu cevabı
                    else if (temp == 0xBA)
                    {
                        Application.UseWaitCursor = true;
                    }
                    //Teste başla komutu cevabı
                    else if (temp == 0xEE)
                    {
                        Application.UseWaitCursor = false;
                        MessageBox.Show("Test Sonlandı", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    //Topraklı Ayırıcı Devreye al/devre dışı komutu cevabı
                    else if (temp == 0xAA)
                    {
                        int ayirici_no = sp.ReadByte();
                        int ayirici_state = sp.ReadByte();
                        if (ayirici_no == 0x01)
                        {
                            if (ayirici_state == 0x00)
                            {
                                //TopraklıAyirici devredışı
                                this.TopraklıAyirici.BackColor = Color.Green;
                            }
                            else if (ayirici_state == 0x0F)
                            {
                                //ToprakliAyirici devrede
                                this.TopraklıAyirici.BackColor = Color.Red;
                            }
                        }
                        else if (ayirici_no == 0x02)
                        {
                            if (ayirici_state == 0x00)
                            {
                                //DirencliAyirici devredışı
                                this.DirencliAyirici.BackColor = Color.Green;
                            }
                            else if (ayirici_state == 0x0F)
                            {
                                //DirencliliAyirici devrede
                                this.DirencliAyirici.BackColor = Color.Red;
                            }
                        }
                    }
                    //Kesici Devreye al/devre dışı komutu cevabı
                    else if (temp == 0x4B)
                    {
                        int kesici_no = sp.ReadByte();
                        int kesici_state = sp.ReadByte();

                        if (kesici_no == 0x01)
                        {
                            if (kesici_state == 0x00) 
                            {
                                //Kesici 1 devredışı
                                this.Kesici_1.BackColor = Color.Green;
                            }
                            else if (kesici_state == 0x0F)
                            {
                                //Kesici 1 devrede
                                this.Kesici_1.BackColor = Color.Red;
                            }
                        }
                        else if (kesici_no == 0x02)
                        {
                            if (kesici_state == 0x00)
                            {
                                //Kesici 2 devredışı
                                this.Kesici_2.BackColor = Color.Green;
                            }
                            else if (kesici_state == 0x0F)
                            {
                                //Kesici 2 devrede
                                this.Kesici_2.BackColor = Color.Red;
                            }
                        }
                        else if (kesici_no == 0x03)
                        {
                            if (kesici_state == 0x00)
                            {
                                //Kesici 3 devredışı
                                this.Kesici_3.BackColor = Color.Green;
                            }
                            else if (kesici_state == 0x0F)
                            {
                                //Kesici 3 devrede
                                this.Kesici_3.BackColor = Color.Red;
                            }
                        }


                    }
                    //Hatalı mesaj
                    else if (temp == 0x48)
                    {
                        int[] komut = new int[2];
                        for (int i = 0; i < 2; i++)
                        {
                            komut[i] = sp.ReadByte();
                        }
                        int[] hata = { 0x54, 0x41 };

                        if (hata.SequenceEqual(komut))
                        {
                            //HATA MESAJI ÜRET
                            {
                                MessageBox.Show("Hatalı Mesaj Alındı", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    else
                    {
                        byte[] bytes = new byte[15];
                        sp.Read(bytes, 0, 15);
                        int[] data = new int[16];
                        data[0] = temp;
                        bytes.CopyTo(data, 1);

                    }
                }
            }
        }
        
        private void RandomData_Click(object sender, EventArgs e)
        {

            chartMain.Series["V1"].Points.Clear();
            chartMain.Series["A1"].Points.Clear();
            chartMain.Series["V2"].Points.Clear();
            chartMain.Series["A2"].Points.Clear();
            chartMain.Series["V3"].Points.Clear();
            chartMain.Series["A3"].Points.Clear();

            Random rdn = new Random();
            for (int i = 0; i <= 100; i++)
            {
                chartMain.Series["V1"].Points.AddXY(i, rdn.Next(0, 100));
                chartMain.Series["V2"].Points.AddXY(i, rdn.Next(0, 100));
                chartMain.Series["V3"].Points.AddXY(i, rdn.Next(0, 100));
            }
            chartMain.ChartAreas[0].AxisX.Maximum = 100;
            chartMain.ChartAreas[0].AxisX.Minimum = 0;
            chartMain.Series["V1"].ChartType = SeriesChartType.FastLine;
            chartMain.Series["V1"].Color = Color.Red;
            chartMain.ChartAreas[0].AxisX.Maximum = 100;
            chartMain.ChartAreas[0].AxisX.Minimum = 0;
            chartMain.Series["V2"].ChartType = SeriesChartType.FastLine;
            chartMain.Series["V2"].Color = Color.Red;
            chartMain.ChartAreas[0].AxisX.Maximum = 100;
            chartMain.ChartAreas[0].AxisX.Minimum = 0;
            chartMain.Series["V3"].ChartType = SeriesChartType.FastLine;
            chartMain.Series["V3"].Color = Color.Red;

            for (int i = 0; i <= 100; i++)
            {
                chartMain.Series["A1"].Points.AddXY(i, rdn.Next(0, 100));
                chartMain.Series["A2"].Points.AddXY(i, rdn.Next(0, 100));
                chartMain.Series["A3"].Points.AddXY(i, rdn.Next(0, 100));
            }
            chartMain.ChartAreas[0].AxisX.Maximum = 100;
            chartMain.ChartAreas[0].AxisX.Minimum = 0;
            chartMain.Series["A1"].ChartType = SeriesChartType.FastLine;
            chartMain.Series["A1"].Color = Color.Blue;
            chartMain.ChartAreas[0].AxisX.Maximum = 100;
            chartMain.ChartAreas[0].AxisX.Minimum = 0;
            chartMain.Series["A2"].ChartType = SeriesChartType.FastLine;
            chartMain.Series["A2"].Color = Color.Blue;
            chartMain.ChartAreas[0].AxisX.Maximum = 100;
            chartMain.ChartAreas[0].AxisX.Minimum = 0;
            chartMain.Series["A3"].ChartType = SeriesChartType.FastLine;
            chartMain.Series["A3"].Color = Color.Blue;

            tb_max_1.Text = (chartMain.Series[0].Points.Count - 1).ToString();
            tb_min_1.Text = "0";

        }

        private void ChartV1_Click(object sender, MouseEventArgs e)
        {
            Axis ax = chartMain.ChartAreas[0].AxisX;

            //double Xpoint;
            double clickedX = ax.PixelPositionToValue(e.X);
            double temp = double.MaxValue;
            string tempstr = "";

            foreach (DataPoint dp in chartMain.Series[0].Points)
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

            chartMain.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_1.Text);
            chartMain.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_1.Text);
            chartMain.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_1.Text);
            chartMain.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_1.Text);

        }

        private void Cb_min_1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_min_1.Checked == true)
                cb_max_1.Checked = false;
        }

        private void Cb_max_1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_max_1.Checked == true)
                cb_min_1.Checked = false;
        }

        private void Zeroize_1_Click(object sender, EventArgs e)
        {
            tb_max_1.Text = (chartMain.Series[0].Points.Count - 1).ToString();
            tb_min_1.Text = "0";


            chartMain.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_1.Text);
            chartMain.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_1.Text);
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

            this.Kesici_1.BackColor = Color.Yellow;
            this.Kesici_2.BackColor = Color.Yellow;
            this.Kesici_3.BackColor = Color.Yellow;
            this.TopraklıAyirici.BackColor = Color.Yellow;
            this.DirencliAyirici.BackColor = Color.Yellow;
            
        }
        
        private void Kesici_2_A_Click(object sender, EventArgs e)
        {
            if (this.TopraklıAyirici.BackColor == Color.Red)
                this.TopraklıAyirici.BackColor = Color.Green;
            else if (this.TopraklıAyirici.BackColor == Color.Green)
                this.TopraklıAyirici.BackColor = Color.Red;
        }

        private void Kesici_2_B_Click(object sender, EventArgs e)
        {
            if (this.DirencliAyirici.BackColor == Color.Red)
                this.DirencliAyirici.BackColor = Color.Green;
            else if (this.DirencliAyirici.BackColor == Color.Green)
                this.DirencliAyirici.BackColor = Color.Red;
        }
                
        private void KaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            string newLine = "t\tV1\tA1\tV2\tA2\tV3\tA3";

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV dosyaları (*.csv)|*.csv"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Path.GetFullPath(sfd.FileName);
            }
            else
            {
                MessageBox.Show("Dosya adı belirtmediniz!!!\nVeriler kaydedilmeyecek.", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var csv = new StringBuilder();

            csv.AppendLine(newLine);

            for (int i = 0; i < chartMain.Series[0].Points.Count; i++)
            {
                string t1 = chartMain.Series[0].Points[i].XValue.ToString();
                string V1 = chartMain.Series[0].Points[i].YValues[0].ToString();
                string A1 = chartA1.Series[0].Points[i].YValues[0].ToString();
                string V2 = chartV2.Series[0].Points[i].YValues[0].ToString();
                string A2 = chartA2.Series[0].Points[i].YValues[0].ToString();
                string V3 = chartV3.Series[0].Points[i].YValues[0].ToString();
                string A3 = chartA3.Series[0].Points[i].YValues[0].ToString();


                newLine = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", t1, V1, A1, V2, A2, V3, A3);
                csv.AppendLine(newLine);
            }
            File.WriteAllText(sfd.FileName, csv.ToString());*/
        }

        private void ReadCalibParams()
        {
            string fullPathToFile = System.Windows.Forms.Application.StartupPath + "\\CalibrationParams.txt";
            StreamReader stream_calib = new StreamReader(fullPathToFile);
            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string temp = Regex.Replace(stream_calib.ReadToEnd(), "[.,]", separator);            
            stream_calib.Close();
            string[] hede = temp.Split('\t','\n','\r');
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
               if (parameters[i] == "#L1")
                {
                    double okunandeger = 0;
                    while (true)
                    {
                        i++;
                        if (parameters[i] == "#L2")
                        {
                            i = i - 1;
                            break;
                        }
                        try
                        {                            
                            okunandeger = double.Parse(parameters[i]);
                        }
                        catch
                        { }
                        if (okunandeger == ScaleFactor)
                        {
                            i++;
                            L1_RMS = double.Parse(parameters[i]);
                            i++;
                            L1_PEAK = double.Parse(parameters[i]);
                        }
                    }
                }
                if (parameters[i] == "#L2")
                {
                    double okunandeger = 0;
                    while (true)
                    {
                        i++;
                        if (parameters[i] == "#L3")
                        {
                            i = i - 1;
                            break;
                        }
                        try
                        {
                            okunandeger = double.Parse(parameters[i]);
                        }
                        catch
                        { }
                        if (okunandeger == ScaleFactor)
                        {
                            i++;
                            L2_RMS = double.Parse(parameters[i]);
                            i++;
                            L2_PEAK = double.Parse(parameters[i]);
                        }
                    }
                }
                if (parameters[i] == "#L3")
                {
                    double okunandeger = 0;
                    while (true)
                    {
                        i++;
                        if (i == parameters.Length)
                        {
                            break;
                        }
                        try
                        {
                            okunandeger = double.Parse(parameters[i]);
                        }
                        catch
                        { }
                        if (okunandeger == ScaleFactor)
                        {
                            i++;
                            L3_RMS = double.Parse(parameters[i]);
                            i++;
                            L3_PEAK = double.Parse(parameters[i]);
                        }
                    }
                }

            }
            
        }
        
        private void AcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ScaleFactor == 0)
            {
                MessageBox.Show("Lüfen Akım Skalası seçiniz.", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel dosyaları (*.xls)|*.xls"
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

            //read calibration parameters
            ReadCalibParams();
            

            // Get the number separator for this culture and replace any others with it
            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            double[] cizilecekData = new double[4000];

            StreamReader readFile = new StreamReader(ofd.FileName);
            Color[] Color_list = { Color.Blue, Color.Red, Color.Green, Color.Magenta, Color.Orange, Color.DarkBlue, Color.Yellow, Color.Black };
            int Color_id = 0;
            double graphStartPoint = 0;
            double graphMinPoint = 0;
            double[] peak2peak = new double[6];
            double[] maxpoints = new double[6];
            double[] minpoints = new double[6];
            int ch_counter = 0;
            string ch_clock = "";
            string ch_size = "";

            while (true)
            {
                string ch_name = readFile.ReadLine();
                if (ch_name == null)
                {
                    break;
                }                
                if (ch_name != "")
                {
                    
                    chartMain.Series[ch_name].Points.Clear();
                    ch_clock = readFile.ReadLine();
                    ch_size = readFile.ReadLine();
                    
                    string ch_unit = readFile.ReadLine();
                    readFile.ReadLine();

                    int numOfData = Convert.ToInt32(string.Join(null, Regex.Split(ch_size, "[^\\d]")));
                    
                    for (int i = 0; i < numOfData; i++)
                    {
                        string hede = Regex.Replace(readFile.ReadLine(), "[.,]", separator);
                        cizilecekData[i] = Convert.ToDouble(hede);                        
                    }

                    graphStartPoint = graphStartPoint + graphMinPoint - cizilecekData.Max();
                    

                    //for (int i=0; i<cizilecekData.Length; i++)
                    for (int i =0; i< Convert.ToInt32(Regex.Match(ch_size, @"\d+").Value); i++)
                    {
                        chartMain.Series[ch_name].Points.AddXY(i, cizilecekData[i] + graphStartPoint);
                    }
                    chartMain.Series[ch_name].ChartType = SeriesChartType.FastLine;
                    chartMain.Series[ch_name].Color = Color_list[Color_id++];
                    chartMain.ChartAreas[0].AxisX.Minimum = 0;
                    chartMain.ChartAreas[0].AxisX.Maximum = Convert.ToInt32(Regex.Match(ch_size, @"\d+").Value)-1;
                    chartMain.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;

                    // MinorGrid Disabled
                    chartMain.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                    chartMain.ChartAreas[0].AxisX.MinorGrid.Interval = Convert.ToInt32(Regex.Match(ch_size, @"\d+").Value) / 20;
                    chartMain.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Gray;
                    chartMain.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;

                    //Major Grid Disabled
                    chartMain.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
                    chartMain.ChartAreas[0].AxisX.MajorGrid.Interval = Convert.ToInt32(Regex.Match(ch_size, @"\d+").Value) / 20;
                    chartMain.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                    chartMain.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
                    chartMain.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;

                    graphMinPoint = cizilecekData.Min();
                    maxpoints[ch_counter] = cizilecekData.Max();
                    minpoints[ch_counter] = cizilecekData.Min();
                    ch_counter = ch_counter + 1;
                }


            }
            readFile.Close();

            // I1_RMS hesapla
            double I1_RMS = ((maxpoints[1]-minpoints[1]) * L1_RMS)/1000; // kA cinsinden
            tb_I1_rms.Text = I1_RMS.ToString("F4") + " kA";

            // I1_peak hesapla
            double I1_peak = 0;
            if (maxpoints[1] >= Math.Abs(minpoints[1]))
                I1_peak = (maxpoints[1] * L1_PEAK) / 1000; // kA cinsinden
            else
                I1_peak = (minpoints[1] * L1_PEAK) / 1000; // kA cinsinden
            tb_I1_peak.Text = I1_peak.ToString("F4") + " kA";

            // I2_RMS hesapla
            double I2_RMS = ((maxpoints[3] - minpoints[3]) * L2_RMS) / 1000; // kA cinsinden
            tb_I2_rms.Text = I2_RMS.ToString("F4") + " kA";

            // I2_peak hesapla
            double I2_peak = 0;
            if (maxpoints[3] >= Math.Abs(minpoints[3]))
                I2_peak = (maxpoints[3] * L2_PEAK) / 1000; // kA cinsinden
            else
                I2_peak = (minpoints[3] * L2_PEAK) / 1000; // kA cinsinden
            tb_I2_peak.Text = I2_peak.ToString("F4") + " kA";

            // I3_RMS hesapla
            double I3_RMS = ((maxpoints[5] - minpoints[5]) * L3_RMS) / 1000; // kA cinsinden
            tb_I3_rms.Text = I3_RMS.ToString("F4") + " kA";

            // I3_peak hesapla
            double I3_peak = 0;
            if (maxpoints[5] >= Math.Abs(minpoints[5]))
                I3_peak = (maxpoints[5] * L3_PEAK) / 1000; // kA cinsinden
            else
                I3_peak = (minpoints[1] * L3_PEAK) / 1000; // kA cinsinden
            tb_I3_peak.Text = I3_peak.ToString("F4") + " kA";


            tb_ms_div_old = (Double.Parse(Regex.Match(ch_clock, @"\d+").Value) * Double.Parse(Regex.Match(ch_size, @"\d+").Value) * 0.001 / 20);
            Tb_ms_div.Text = tb_ms_div_old.ToString("F2");

        }

        /*
        private void AcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV dosyaları (*.csv)|*.csv"                
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

            StreamReader readFile = new StreamReader(ofd.FileName);
            string line;
            string[] row;
            string first_line = readFile.ReadLine();

            string[] headers = first_line.Split('\t');

            if (first_line != "t\tV1\tA1\tV2\tA2\tV3\tA3")
            {
                MessageBox.Show("Seçtiğiniz dosya uygun değil.", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            chartV1.Series[headers[1]].Points.Clear();
            chartA1.Series[headers[2]].Points.Clear();
            chartV2.Series[headers[3]].Points.Clear();
            chartA2.Series[headers[4]].Points.Clear();
            chartV3.Series[headers[5]].Points.Clear();
            chartA3.Series[headers[6]].Points.Clear();

            int i = 0;
            while ((line = readFile.ReadLine()) != null)
            {

                row = line.Split('\t');

                //V1
                chartV1.Series[headers[1]].Points.AddXY(Convert.ToDouble(row[0]), Convert.ToDouble(row[1]));
                chartV1.Series[headers[1]].ChartType = SeriesChartType.FastLine;
                chartV1.Series[headers[1]].Color = Color.Red;
                //A1
                chartA1.Series[headers[2]].Points.AddXY(Convert.ToDouble(row[0]), Convert.ToDouble(row[2]));
                chartA1.Series[headers[2]].ChartType = SeriesChartType.FastLine;
                chartA1.Series[headers[2]].Color = Color.Blue;
                //V2
                chartV2.Series[headers[3]].Points.AddXY(Convert.ToDouble(row[0]), Convert.ToDouble(row[3]));
                chartV2.Series[headers[3]].ChartType = SeriesChartType.FastLine;
                chartV2.Series[headers[3]].Color = Color.Red;
                //A2
                chartA2.Series[headers[4]].Points.AddXY(Convert.ToDouble(row[0]), Convert.ToDouble(row[4]));
                chartA2.Series[headers[4]].ChartType = SeriesChartType.FastLine;
                chartA2.Series[headers[4]].Color = Color.Blue;
                //V3
                chartV3.Series[headers[5]].Points.AddXY(Convert.ToDouble(row[0]), Convert.ToDouble(row[5]));
                chartV3.Series[headers[5]].ChartType = SeriesChartType.FastLine;
                chartV3.Series[headers[5]].Color = Color.Red;
                //A3
                chartA3.Series[headers[6]].Points.AddXY(Convert.ToDouble(row[0]), Convert.ToDouble(row[6]));
                chartA3.Series[headers[6]].ChartType = SeriesChartType.FastLine;
                chartA3.Series[headers[6]].Color = Color.Blue;

                i++;
            }
            readFile.Close();

            tb_max_1.Text = (chartV1.Series[0].Points.Count - 1).ToString();
            tb_min_1.Text = "0";
            tb_max_2.Text = (chartV2.Series[0].Points.Count - 1).ToString();
            tb_min_2.Text = "0";
            tb_max_3.Text = (chartV2.Series[0].Points.Count - 1).ToString();
            tb_min_3.Text = "0";
        }
        */

        private void Tb_ZamanYukle_TextChanged(object sender, EventArgs e)
        {
            cb_zamanayarlandı.Checked = false;
        }

        private void B_setzaman_Click(object sender, EventArgs e)
        {
            if (tb_ZamanYukle.Text.Length == 0)
            {
                MessageBox.Show("Test Süresi Değeri Boş Bırakılamaz", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            byte[] zaman = BitConverter.GetBytes(Int16.Parse(tb_ZamanYukle.Text));
            Array.Reverse(zaman);

            byte[] data = { 0xAB, 0xCD, 0x54, zaman[0], zaman[1] };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
        private void Kesici_1_On_Click(object sender, EventArgs e)
        {
            byte[] data = { 0xAB, 0xCD, 0x4B, 0x01, 0x0F };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Kesici_1_Off_Click(object sender, EventArgs e)
        {
            byte[] data = { 0xAB, 0xCD, 0x4B, 0x01, 0x00 };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Kesici_2_On_Click(object sender, EventArgs e)
        {
            byte[] data = { 0xAB, 0xCD, 0x4B, 0x02, 0x0F };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Kesici_2_Off_Click(object sender, EventArgs e)
        {
            byte[] data = { 0xAB, 0xCD, 0x4B, 0x02, 0x00 };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Kesici_3_On_Click(object sender, EventArgs e)
        {
            byte[] data = { 0xAB, 0xCD, 0x4B, 0x03, 0x0F };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Kesici_3_Off_Click(object sender, EventArgs e)
        {
            byte[] data = { 0xAB, 0xCD, 0x4B, 0x03, 0x00 };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ToprakliOn_Click(object sender, EventArgs e)
        {
            byte[] data = { 0xAB, 0xCD, 0xAA, 0x01, 0x0F };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ToprakliOff_Click(object sender, EventArgs e)
        {
            byte[] data = { 0xAB, 0xCD, 0xAA, 0x01, 0x00 };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void DirencliOn_Click(object sender, EventArgs e)
        {
            byte[] data = { 0xAB, 0xCD, 0xAA, 0x02, 0x0F };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void DirencliOff_Click(object sender, EventArgs e)
        {
            byte[] data = { 0xAB, 0xCD, 0xAA, 0x02, 0x00 };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void TesteBasla_Click(object sender, EventArgs e)
        {
            if (cb_zamanayarlandı.Checked == false)
                return;

            byte[] data = { 0xAB, 0xCD, 0xBA, 0x00, 0x00 };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void TestiDurdur_Click(object sender, EventArgs e)
        {
            byte[] data = { 0xAB, 0xCD, 0xEE, 0x00, 0x00 };

            try
            {
                sp.Write(data, 0, 5);
            }
            catch (Exception)
            {
                MessageBox.Show("Haberleşme Hatası!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Rb_120kA_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_120kA.Checked == true)
            {
                Rb_50kA.Checked = false;
                Rb_10kA.Checked = false;
                Rb_5kA.Checked = false;
                Rb_2kA.Checked = false;
                Rb_500A.Checked = false;
                Rb_100A.Checked = false;
            }
            ScaleFactor = 120000;
        }

        private void Rb_50kA_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_50kA.Checked == true)
            {
                Rb_120kA.Checked = false;
                Rb_10kA.Checked = false;
                Rb_5kA.Checked = false;
                Rb_2kA.Checked = false;
                Rb_500A.Checked = false;
                Rb_100A.Checked = false;
            }
            ScaleFactor = 50000;
        }

        private void Rb_10kA_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_10kA.Checked == true)
            {
                Rb_120kA.Checked = false;
                Rb_50kA.Checked = false;
                Rb_5kA.Checked = false;
                Rb_2kA.Checked = false;
                Rb_500A.Checked = false;
                Rb_100A.Checked = false;
            }
            ScaleFactor = 10000;
        }

        private void Rb_5kA_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_5kA.Checked == true)
            {
                Rb_120kA.Checked = false;
                Rb_50kA.Checked = false;
                Rb_10kA.Checked = false;
                Rb_2kA.Checked = false;
                Rb_500A.Checked = false;
                Rb_100A.Checked = false;
            }
            ScaleFactor = 5000;
        }

        private void Rb_2kA_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_2kA.Checked == true)
            {
                Rb_120kA.Checked = false;
                Rb_50kA.Checked = false;
                Rb_10kA.Checked = false;
                Rb_5kA.Checked = false;
                Rb_500A.Checked = false;
                Rb_100A.Checked = false;
            }
            ScaleFactor = 2000;
        }

        private void Rb_500A_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_500A.Checked == true)
            {
                Rb_120kA.Checked = false;
                Rb_50kA.Checked = false;
                Rb_10kA.Checked = false;
                Rb_5kA.Checked = false;
                Rb_2kA.Checked = false;
                Rb_100A.Checked = false;
            }
            ScaleFactor = 500;
        }

        private void Rb_100A_CheckedChanged(object sender, EventArgs e)
        {

            if (Rb_100A.Checked == true)
            {
                Rb_120kA.Checked = false;
                Rb_50kA.Checked = false;
                Rb_10kA.Checked = false;
                Rb_5kA.Checked = false;
                Rb_2kA.Checked = false;
                Rb_500A.Checked = false;
            }
            ScaleFactor = 100;
        }
        
        private void Tb_ms_div_TextChanged(object sender, EventArgs e)
        {
            if (Tb_ms_div.Text == "")
                return;
            double ms_div = Convert.ToDouble(Tb_ms_div.Text);
            chartMain.ChartAreas[0].AxisX.Maximum = chartMain.ChartAreas[0].AxisX.Maximum * ms_div / tb_ms_div_old;
            tb_ms_div_old = ms_div;
            chartMain.ChartAreas[0].AxisX.MajorGrid.Interval = chartMain.ChartAreas[0].AxisX.Maximum / 20;

        }

        private void Tb_ms_div_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (Tb_ms_div.Text != "")
            {
                tb_ms_div_old = Convert.ToDouble(Tb_ms_div.Text);
            }
            else
            {
                tb_ms_div_old = 1;
            }
        }
    }
}




