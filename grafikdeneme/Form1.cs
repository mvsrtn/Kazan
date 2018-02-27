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
namespace grafikdeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            SetPortConfig();
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
                        int surehigh = sp.ReadByte();
                        int surelow = sp.ReadByte();
                        int sure = surehigh * 256 + surelow;
                    }
                    //Teste başla komutu cevabı
                    else if (temp == 0xEE)
                    {
                        int surehigh = sp.ReadByte();
                        int surelow = sp.ReadByte();
                        int sure = surehigh * 256 + surelow;
                    }
                    //Topraklı Ayırıcı Devreye al/devre dışı komutu cevabı
                    else if (temp == 0xAA)
                    {
                        int ayirici_no = sp.ReadByte();
                        int ayirici_state = sp.ReadByte();
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

            chartV1.Series["V1"].Points.Clear();
            chartA1.Series["A1"].Points.Clear();
            chartV2.Series["V2"].Points.Clear();
            chartA2.Series["A2"].Points.Clear();
            chartV3.Series["V3"].Points.Clear();
            chartA3.Series["A3"].Points.Clear();

            Random rdn = new Random();
            for (int i = 0; i <= 100; i++)
            {
                chartV1.Series["V1"].Points.AddXY(i, rdn.Next(0, 100));
                chartV2.Series["V2"].Points.AddXY(i, rdn.Next(0, 100));
                chartV3.Series["V3"].Points.AddXY(i, rdn.Next(0, 100));
            }
            chartV1.ChartAreas[0].AxisX.Maximum = 100;
            chartV1.ChartAreas[0].AxisX.Minimum = 0;
            chartV1.Series["V1"].ChartType = SeriesChartType.FastLine;
            chartV1.Series["V1"].Color = Color.Red;
            chartV2.ChartAreas[0].AxisX.Maximum = 100;
            chartV2.ChartAreas[0].AxisX.Minimum = 0;
            chartV2.Series["V2"].ChartType = SeriesChartType.FastLine;
            chartV2.Series["V2"].Color = Color.Red;
            chartV3.ChartAreas[0].AxisX.Maximum = 100;
            chartV3.ChartAreas[0].AxisX.Minimum = 0;
            chartV3.Series["V3"].ChartType = SeriesChartType.FastLine;
            chartV3.Series["V3"].Color = Color.Red;

            for (int i = 0; i <= 100; i++)
            {
                chartA1.Series["A1"].Points.AddXY(i, rdn.Next(0, 100));
                chartA2.Series["A2"].Points.AddXY(i, rdn.Next(0, 100));
                chartA3.Series["A3"].Points.AddXY(i, rdn.Next(0, 100));
            }
            chartA1.ChartAreas[0].AxisX.Maximum = 100;
            chartA1.ChartAreas[0].AxisX.Minimum = 0;
            chartA1.Series["A1"].ChartType = SeriesChartType.FastLine;
            chartA1.Series["A1"].Color = Color.Blue;
            chartA2.ChartAreas[0].AxisX.Maximum = 100;
            chartA2.ChartAreas[0].AxisX.Minimum = 0;
            chartA2.Series["A2"].ChartType = SeriesChartType.FastLine;
            chartA2.Series["A2"].Color = Color.Blue;
            chartA3.ChartAreas[0].AxisX.Maximum = 100;
            chartA3.ChartAreas[0].AxisX.Minimum = 0;
            chartA3.Series["A3"].ChartType = SeriesChartType.FastLine;
            chartA3.Series["A3"].Color = Color.Blue;

            tb_max_1.Text = (chartV1.Series[0].Points.Count - 1).ToString();
            tb_min_1.Text = "0";
            tb_max_2.Text = (chartV2.Series[0].Points.Count - 1).ToString();
            tb_min_2.Text = "0";
            tb_max_3.Text = (chartV2.Series[0].Points.Count - 1).ToString();
            tb_min_3.Text = "0";

        }

        private void ChartV1_Click(object sender, MouseEventArgs e)
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

        private void ChartA1_Click(object sender, MouseEventArgs e)
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
            tb_max_1.Text = (chartA1.Series[0].Points.Count - 1).ToString();
            tb_min_1.Text = "0";


            chartV1.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_1.Text);
            chartV1.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_1.Text);
            chartA1.ChartAreas[0].AxisX.Maximum = Int32.Parse(tb_max_1.Text);
            chartA1.ChartAreas[0].AxisX.Minimum = Int32.Parse(tb_min_1.Text);
        }
        
        private void ChartV2_Click(object sender, MouseEventArgs e)
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

        private void ChartA2_Click(object sender, MouseEventArgs e)
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

        private void Cb_min_2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_min_2.Checked == true)
                cb_max_2.Checked = false;
        }

        private void Cb_max_2_CheckedChanged(object sender, EventArgs e)
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

        private void ChartV3_Click(object sender, MouseEventArgs e)
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

        private void ChartA3_Click(object sender, MouseEventArgs e)
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

        private void Cb_min_3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_min_3.Checked == true)
                cb_max_3.Checked = false;
        }

        private void Cb_max_3_CheckedChanged(object sender, EventArgs e)
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

            this.Kesici_1.BackColor = Color.Red;
            this.Kesici_2.BackColor = Color.Red;
            this.Kesici_3.BackColor = Color.Red;
            this.Kesici_2_A.BackColor = Color.Red;
            this.Kesici_2_B.BackColor = Color.Red;
            this.Kesici_2_C.BackColor = Color.Red;



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
        
        private void KaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

            for (int i = 0; i < chartV1.Series[0].Points.Count; i++)
            {
                string t1 = chartV1.Series[0].Points[i].XValue.ToString();
                string V1 = chartV1.Series[0].Points[i].YValues[0].ToString();
                string A1 = chartA1.Series[0].Points[i].YValues[0].ToString();
                string V2 = chartV2.Series[0].Points[i].YValues[0].ToString();
                string A2 = chartA2.Series[0].Points[i].YValues[0].ToString();
                string V3 = chartV3.Series[0].Points[i].YValues[0].ToString();
                string A3 = chartA3.Series[0].Points[i].YValues[0].ToString();


                newLine = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", t1, V1, A1, V2, A2, V3, A3);
                csv.AppendLine(newLine);
            }
            File.WriteAllText(sfd.FileName, csv.ToString());
        }

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

    }
}




