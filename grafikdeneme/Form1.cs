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
        
        private void ChartMain_Click(object sender, MouseEventArgs e)
        {
            // textbox devredışı bırak
            Tb_ilk_ms.TextChanged -= Tb_ilk_ms_TextChanged;
            Tb_son_ms.TextChanged -= Tb_son_ms_TextChanged;

            double start = Math.Round((chartMain.ChartAreas[0].CursorX.SelectionStart / chartMain.Series[1].Points.Count) * (Convert.ToDouble(Tb_ms_div.Text) * 20));
            double end = Math.Round((chartMain.ChartAreas[0].CursorX.SelectionEnd / chartMain.Series[1].Points.Count) * (Convert.ToDouble(Tb_ms_div.Text) * 20));
            if (start < end)
            {
                Tb_ilk_ms.Text = start.ToString();
                Tb_son_ms.Text = end.ToString();
            }
            else
            {
                Tb_ilk_ms.Text = end.ToString();
                Tb_son_ms.Text = start.ToString();
            }

            //Ölçüm aralığı hesabı yap
            Tb_olcum_araligi.Text = (Convert.ToUInt64(Tb_son_ms.Text) - Convert.ToUInt64(Tb_ilk_ms.Text)).ToString();

            int ilk = Convert.ToInt16(Math.Round(chartMain.Series[1].Points.Count * Convert.ToDouble(Tb_ilk_ms.Text) / (20 * Convert.ToDouble(Tb_ms_div.Text))));
            int son = Convert.ToInt16(Math.Round(chartMain.Series[1].Points.Count * Convert.ToDouble(Tb_son_ms.Text) / (20 * Convert.ToDouble(Tb_ms_div.Text))));

            //hesaplamaları yap
            for (int i = 0; i < 6; i++)
            {
                hesaplanacakData[i] = cizilecekData[i].Skip(ilk).Take(son-ilk).ToArray();
            }
            Hesaplamalar();

            // textbox devreye al
            Tb_ilk_ms.TextChanged += Tb_ilk_ms_TextChanged;
            Tb_son_ms.TextChanged += Tb_son_ms_TextChanged;
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
            string[] hede = temp.Split('\t', '\n', '\r');
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

        private double RMSHesapla(double[] giris)
        {
            double cikis = 0;
            for (int i = 0; i <giris.Length; i++)
            {
                cikis = cikis + (giris[i] * giris[i]);
            }
            cikis = Math.Sqrt(cikis / giris.Length);
            
            return cikis;
        }

        private void Hesaplamalar()
        {
            if (hesaplanacakData[1].Length == 0)
                return;

            // V1_RMS
            double V1_RMS = RMSHesapla(hesaplanacakData[0]);
            tb_V1_rms.Text = V1_RMS.ToString("#,##0.000");

            // I1_RMS hesapla
            double I1_RMS = ((hesaplanacakData[1].Max() - hesaplanacakData[1].Min()) * L1_RMS); // kA cinsinden
            tb_I1_rms.Text = I1_RMS.ToString("#,##0.000") + " kA";
                    
            // I1_peak hesapla
            double I1_peak = 0;
            if (hesaplanacakData[1].Max() >= Math.Abs(hesaplanacakData[1].Min()))
                I1_peak = (hesaplanacakData[1].Max() * L1_PEAK); // kA cinsinden
            else
                I1_peak = (hesaplanacakData[1].Min() * L1_PEAK); // kA cinsinden
            I1_peak = Math.Abs(I1_peak);
            tb_I1_peak.Text = I1_peak.ToString("#,##0.000") + " kA";

            // CH1 I2T hesapla
            if (Tb_olcum_araligi.Text.Length != 0)
            {
                double Ch1_I2T = I1_RMS * I1_RMS * Convert.ToDouble(Tb_olcum_araligi.Text);
                Tb_ch1_I2t.Text = Ch1_I2T.ToString("#,##0.0000") + "kA*s";
            }


            // V2_RMS
            double V2_RMS = RMSHesapla(hesaplanacakData[2]);
            tb_V2_rms.Text = V2_RMS.ToString("#,##0.000");

            // I2_RMS hesapla
            double I2_RMS = ((hesaplanacakData[3].Max() - hesaplanacakData[3].Min()) * L2_RMS); // kA cinsinden
            tb_I2_rms.Text = I2_RMS.ToString("#,##0.000") + " kA";

            // I2_peak hesapla
            double I2_peak = 0;
            if (hesaplanacakData[3].Max() >= Math.Abs(hesaplanacakData[3].Min()))
                I2_peak = (hesaplanacakData[3].Max() * L2_PEAK); // kA cinsinden
            else
                I2_peak = (hesaplanacakData[3].Min() * L2_PEAK); // kA cinsinden
            I2_peak = Math.Abs(I2_peak);
            tb_I2_peak.Text = I2_peak.ToString("#,##0.000") + " kA";

            // CH2 I2T hesapla
            if (Tb_olcum_araligi.Text.Length != 0)
            {
                double Ch2_I2T = I2_RMS * I2_RMS * Convert.ToDouble(Tb_olcum_araligi.Text);
                Tb_ch2_I2t.Text = Ch2_I2T.ToString("#,##0.0000") + "kA*s";
            }

            // V3_RMS
            double V3_RMS = RMSHesapla(hesaplanacakData[4]);
            tb_V3_rms.Text = V3_RMS.ToString("#,##0.000");

            // I3_RMS hesapla
            double I3_RMS = ((hesaplanacakData[5].Max() - hesaplanacakData[5].Min()) * L3_RMS); // kA cinsinden
            tb_I3_rms.Text = I3_RMS.ToString("#,##0.000") + " kA";

            // I3_peak hesapla
            double I3_peak = 0;
            if (hesaplanacakData[5].Max() >= Math.Abs(hesaplanacakData[5].Min()))
                I3_peak = (hesaplanacakData[5].Max() * L3_PEAK); // kA cinsinden
            else
                I3_peak = (hesaplanacakData[5].Min() * L3_PEAK); // kA cinsinden
            I3_peak = Math.Abs(I3_peak);
            tb_I3_peak.Text = I3_peak.ToString("#,##0.000") + " kA";

            // CH3 I2T hesapla
            if (Tb_olcum_araligi.Text.Length != 0)
            {
                double Ch3_I2T = I3_RMS * I3_RMS * Convert.ToDouble(Tb_olcum_araligi.Text);
                Tb_ch3_I2t.Text = Ch3_I2T.ToString("#,##0.0000") + "kA*s";
            }
        }

        private void ReadData(string path, out double ch_clock, out UInt16 ch_size, out double[] data)
        {
            // Get the number separator for this culture and replace any others with it
            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            int i = 0;
            data = new double[0];
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
                        data = new double[ch_size];
                    }
                }
                else
                {
                    string[] data_line = line.Split(',');
                    string temp_s = Regex.Replace(data_line[0], "[.,]", separator);
                    data[i] = Convert.ToDouble(temp_s);
                    i = i + 1;
                }
            }
            readFile.Close();
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


            //read calibration parameters
            ReadCalibParams();

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


            for (int i=0; i<6; i++)
            {
                ReadData(fileList[i], out ch_clock[i], out ch_size[i], out cizilecekData[i]);
            }

            double graphStartPoint = 0;
            Color[] Color_list = { Color.Blue, Color.Red, Color.Green, Color.Magenta, Color.Orange, Color.DarkBlue, Color.Yellow, Color.Black };
            int Color_id = 0;
            string[] ch_name = new string[6];
                                   
            double p2p_max = 0;

            for (int i = 0; i < 6; i++)
            {
                double p2p = 0;
                if (Math.Abs(cizilecekData[i].Max()) > Math.Abs(cizilecekData[i].Min()))
                    p2p = 2 * Math.Abs(cizilecekData[i].Max());
                else
                    p2p = 2 * Math.Abs(cizilecekData[i].Min());
                if (p2p_max < p2p)
                {
                    p2p_max = p2p;
                }
            }

            graphStartPoint = -p2p_max / 2;

            for (int ii = 0; ii < 6; ii++)
            {
                chartMain.Series[ii].Points.Clear();
                for (int i = 0; i < cizilecekData[ii].Length; i++)
                {
                    chartMain.Series[ii].Points.AddXY(i, cizilecekData[ii][i] + graphStartPoint);
                }
                graphStartPoint = graphStartPoint - p2p_max;
                chartMain.Series[ii].ChartType = SeriesChartType.FastLine;
                chartMain.Series[ii].Color = Color_list[Color_id++];
            }

            cizilecekData.CopyTo(hesaplanacakData,0);
            Hesaplamalar();

            //XAxis Ayarları              
            chartMain.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartMain.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chartMain.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartMain.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            chartMain.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            //chartMain.ChartAreas[0].AxisX.MajorGrid.Interval = Convert.ToInt32(Regex.Match(ch_size, @"\d+").Value) / 20;
            chartMain.ChartAreas[0].AxisX.MajorGrid.Interval = ch_size[0] / 20;
            chartMain.ChartAreas[0].AxisX.Minimum = 0;
            //chartMain.ChartAreas[0].AxisX.Maximum = Convert.ToInt32(Regex.Match(ch_size, @"\d+").Value) - 1;
            chartMain.ChartAreas[0].AxisX.Maximum = ch_size[0] - 1;

            //YAxis Ayarları
            chartMain.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chartMain.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            chartMain.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chartMain.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chartMain.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartMain.ChartAreas[0].AxisY.MajorGrid.Interval = (p2p_max * 6) / 36;
            chartMain.ChartAreas[0].AxisY.Minimum = -(p2p_max * 6);
            chartMain.ChartAreas[0].AxisY.Maximum = 0;

            //Cursor ayarları
            chartMain.ChartAreas[0].CursorX.IsUserEnabled = true;
            chartMain.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartMain.ChartAreas[0].CursorX.SelectionColor = Color.LightBlue;
            chartMain.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            //chartMain.ChartAreas[0].CursorY.IsUserEnabled = true;
            //chartMain.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            GraphStart.Text = "0";
            
            //tb_ms_div_old = (Double.Parse(Regex.Match(ch_clock, @"\d+").Value) * 10 / 20);
            tb_ms_div_old = (ch_clock[0]*1000 * 10 / 20);
            Tb_ms_div.Text = tb_ms_div_old.ToString("F2");


            tb_v_div_old = (p2p_max * 6) / (36);
            Tb_v_div.Text = tb_v_div_old.ToString("F2");
            tb_A_div_old = (p2p_max * 6) / (36);
            Tb_A_div.Text = tb_v_div_old.ToString("F2");

            
            Tb_A_div.Text = (tb_A_div_old*100).ToString("F2");

            chartMain.Refresh();
            
        }
        
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
            double ms_div;
            if (Tb_ms_div.Text == "")
                return;
            try
            {
                ms_div = Convert.ToDouble(Tb_ms_div.Text);
            }
            catch
            {
                return;
            }
            if (ms_div == 0)
                return;
            if (chartMain.ChartAreas[0].AxisX.Minimum > chartMain.ChartAreas[0].AxisX.Maximum * ms_div / tb_ms_div_old)
            {
                return;
            }
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

        private void Tb_v_div_TextChanged(object sender, EventArgs e)
       {
            double v_div;
            if (Tb_v_div.Text == "")
                return;
            try
            {
                v_div = Convert.ToDouble(Tb_v_div.Text);
            }
            catch
            {
                return;
            }
            if (v_div == 0)
                return;

            double axis_min = chartMain.ChartAreas[0].AxisY.Minimum;
            double axis_max = chartMain.ChartAreas[0].AxisY.Maximum;
            double graphStep = Math.Abs(axis_max - axis_min) / 6;
            double graphStartPoint = axis_max - graphStep / 2;
            if (Double.IsNaN(graphStartPoint))
                return;
            for (int ch_no = 0; ch_no < 6; ch_no = ch_no + 2)
            {
                for (int i = 0; i < chartMain.Series[ch_no].Points.Count(); i++)
                {
                    chartMain.Series[ch_no].Points.ElementAt(i).SetValueY(chartMain.Series[ch_no].Points.ElementAt(i).GetValueByName("Y") * v_div / tb_v_div_old - graphStartPoint * (v_div / tb_v_div_old - 1));
                }
                graphStartPoint = graphStartPoint - graphStep * 2;
            }

            chartMain.Refresh();

            tb_v_div_old = v_div;

        }

        private void Tb_v_div_MouseClick(object sender, MouseEventArgs e)
        {
            if (Tb_v_div.Text != "")
            {
                tb_v_div_old = Convert.ToDouble(Tb_v_div.Text);
            }
            else
            {
                tb_v_div_old = 1;
            }
        }

        private void Tb_A_div_TextChanged(object sender, EventArgs e)
        {
            double A_div;
            if (Tb_A_div.Text == "")
                return;
            try
            {
                A_div = Convert.ToDouble(Tb_A_div.Text);
            }
            catch
            {
                return;
            }
            if (A_div == 0)
                return;

            double axis_min = chartMain.ChartAreas[0].AxisY.Minimum;
            double axis_max = chartMain.ChartAreas[0].AxisY.Maximum;
            double graphStep = Math.Abs(axis_max - axis_min) / 6;
            double graphStartPoint = axis_max - graphStep *3/ 2;
            if (Double.IsNaN(graphStartPoint))
                return;
            for (int ch_no = 1; ch_no < 6; ch_no = ch_no + 2)
            {
                for (int i = 0; i < chartMain.Series[ch_no].Points.Count(); i++)
                {
                    chartMain.Series[ch_no].Points.ElementAt(i).SetValueY(chartMain.Series[ch_no].Points.ElementAt(i).GetValueByName("Y") * A_div / tb_A_div_old - graphStartPoint * (A_div / tb_A_div_old - 1));
                }
                graphStartPoint = graphStartPoint - graphStep * 2;
            }

            chartMain.Refresh();

            tb_A_div_old = A_div;

        }

        private void Tb_A_div_MouseClick(object sender, MouseEventArgs e)
        {
            if (Tb_A_div.Text != "")
            {
                tb_A_div_old = Convert.ToDouble(Tb_A_div.Text);
            }
            else
            {
                tb_A_div_old = 1;
            }
        }

        private void GraphStart_TextChanged(object sender, EventArgs e)
        {
            double StartPoint = 0;
            if (GraphStart.Text == "")
                return;
            try
            {
                StartPoint = (Convert.ToDouble(GraphStart.Text)/Convert.ToDouble(Tb_ms_div.Text))* (chartMain.Series[1].Points.Count/20);
            }
            catch
            {
                return;
            }

            chartMain.ChartAreas[0].AxisX.Minimum = StartPoint;

        }

        private void Tb_ilk_ms_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToUInt64(Tb_son_ms.Text) < Convert.ToUInt64(Tb_ilk_ms.Text))
            {
                MessageBox.Show("geçersiz veri girdiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            chartMain.ChartAreas[0].CursorX.SelectionStart = chartMain.Series[1].Points.Count * Convert.ToDouble(Tb_ilk_ms.Text)/(20* Convert.ToDouble(Tb_ms_div.Text));
            Tb_olcum_araligi.Text = (Convert.ToUInt64(Tb_son_ms.Text) - Convert.ToUInt64(Tb_ilk_ms.Text)).ToString();

            int ilk = Convert.ToInt16(Math.Round(chartMain.Series[1].Points.Count * Convert.ToDouble(Tb_ilk_ms.Text) / (20 * Convert.ToDouble(Tb_ms_div.Text))));
            int son = Convert.ToInt16(Math.Round(chartMain.Series[1].Points.Count * Convert.ToDouble(Tb_son_ms.Text) / (20 * Convert.ToDouble(Tb_ms_div.Text))));

            //hesaplamaları yap
            for (int i = 0; i < 6; i++)
            {
                hesaplanacakData[i] = cizilecekData[i].Skip(ilk).Take(son - ilk).ToArray();
            }
            Hesaplamalar();
        }

        private void Tb_son_ms_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToUInt64(Tb_son_ms.Text) < Convert.ToUInt64(Tb_ilk_ms.Text))
            {
                MessageBox.Show("geçersiz veri girdiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            chartMain.ChartAreas[0].CursorX.SelectionEnd = chartMain.Series[1].Points.Count * Convert.ToDouble(Tb_son_ms.Text) / (20 * Convert.ToDouble(Tb_ms_div.Text));
            Tb_olcum_araligi.Text = (Convert.ToUInt64(Tb_son_ms.Text) - Convert.ToUInt64(Tb_ilk_ms.Text)).ToString();

            int ilk = Convert.ToInt16(Math.Round(chartMain.Series[1].Points.Count * Convert.ToDouble(Tb_ilk_ms.Text) / (20 * Convert.ToDouble(Tb_ms_div.Text))));
            int son = Convert.ToInt16(Math.Round(chartMain.Series[1].Points.Count * Convert.ToDouble(Tb_son_ms.Text) / (20 * Convert.ToDouble(Tb_ms_div.Text))));

            //hesaplamaları yap
            for (int i = 0; i < 6; i++)
            {
                hesaplanacakData[i] = cizilecekData[i].Skip(ilk).Take(son - ilk).ToArray();
            }
            Hesaplamalar();

        }

    }
}




