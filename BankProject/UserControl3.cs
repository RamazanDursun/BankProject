using Dapper;
using System;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace BankProject
{
    public partial class UserControl3 : UserControl
    {
        DateTime dt = DateTime.Now;
        string parayatirma = "";
        
        string anlamsiz="";
        long kullanilabilirlimit = 0;
        public string tckn = "";
        public long para = 0;
        long toplam = 0;
        public UserControl3()
        {
            InitializeComponent();
        }
        private void UserControl3_Load(object sender, EventArgs e)
        {
            
            textBox3.Clear();
            SifreGiris sg = new SifreGiris();
        }
        public static string arama;
        public static string yazi;
        public void Hesap_Hareketleri()
        {
            using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var sonuc = db.QueryFirstOrDefault<HesapHareketleri>("Hesap_INSERT", new { @musteritckn = SifreGiris.tckn1, @musterihesapno = arama, @islemtarihi = dt, @islemaciklama = yazi }, commandType: CommandType.StoredProcedure);
            }
        }
        public void SadeceSayiGirisi(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.Handled != false)
            {
                SystemSounds.Beep.Play();
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult cikis = MessageBox.Show("Çıkmak istiyor musunuz", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (cikis == DialogResult.Yes)
            {
                panel4.Visible = false;
            }
        }
        private void btnParaCekme_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel7.Visible = false;
            panel1.Visible = true;
            
        }
        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
       
        private void btnParaYatirma_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = true;
            panel7.Visible = true;
            panel2.Visible = true;
            parayatirma = btnParaYatirma.Text;
           
        }
        private void button9_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = false;

        }
        string khpy = "";
        private void btnKH_Click(object sender, EventArgs e)
        {
            khpy = "kendihesabınaparayatirma";
            btnKHPY.Visible = true;
            textBox4.Visible = true;
            pnlParaYatirma.Visible = true;
            panel5.Visible = false;
            label2.Visible = false;
            panel6.Visible = true;
            textBox2.Clear();
            textBox4.Clear();
            label5.Visible = false;
            btnParaYatirmaGeri.Visible = true;
            btnParaYatirmaCikis.Visible = false;

        }
        private void button9_Click_1(object sender, EventArgs e)
        {
            pnlParaYatirma.Visible = false;
            panel2.Visible = true;
        }
        private void btnBH_Click(object sender, EventArgs e)
        {
            parayatirma = "Başkasının Hesabına";
            pnlParaYatirma.Visible = true;
            btnKHPY.Visible = true;
            panel5.Visible = true;
            textBox2.Clear();
            textBox4.Clear();
            label5.Visible = false;
            panel6.Visible = true;
            label2.Visible = true;
            
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            pnlParaYatirma.Visible = false;
            panel2.Visible = false;
            panel1.Visible = false;
            frm1.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            textBox3.Clear();
            parayatirma = button7.Text;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel1.Visible = true;
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);
        }
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox3.Text.Length >= 1)
            {
                string ParaCek = textBox3.Text;
                double Faiz = 1.15;
                double KalanTutar = (double.Parse(ParaCek) * Faiz);
                double FaizHesapla = KalanTutar - double.Parse(ParaCek);
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);
        }
        private void btnKHPY_Click(object sender, EventArgs e)
        {
            yazi = "";
            
            long toplam1;
            int sonuc1;
            long toplampara = long.Parse(label10.Text);
            arama = label9.Text;//hesap numarası
            anlamsiz = label9.Text;//hesap numarasını aldık ve aktardık
            try
            {
                long para = long.Parse(textBox4.Text);
                if (para <= 9 || para >= 2001)
                {
                    MessageBox.Show("Tek seferde en az 10₺ en fazla 2000₺ yatırabilirsiniz.");
                    textBox4.Clear();
                }

                else if (khpy == "kendihesabınaparayatirma")
                {
                    if (para % 5 != 0)
                    {
                        MessageBox.Show("Yatırılan para 5 ve 5 'in katları olmak zorundadır. ");
                        textBox4.Clear();
                    }
                    else if(para % 5 == 0)
                    {
                        panel6.Visible = false;
                        using (SqlConnection sqlConnection = new SqlConnection(Globals.ConnectionString))
                        {
                            long ekle2 = long.Parse(label10.Text);
                            toplam1 = ekle2 + para;
                            sqlConnection.Open();
                            sqlConnection.Execute("[MusteriParaYatir_UPDATE]", new { @kullanilabilirlimit = toplam1, @musterihesapno = arama }, commandType: CommandType.StoredProcedure); sqlConnection.Close();
                            MessageBox.Show("Lütfen Bekleyin Paranız Sayılıyor.");
                            Thread.Sleep(3000);
                            parayatirma = "";
                            label5.Visible = true;
                            label5.Text = "Para Yatırma İşlemi Başarılı Bir Şekilde Gerçekleştirilmiştir.";
                            label10.Text = toplam1.ToString();
                            label11.Text = toplam1.ToString();
                            btnParaYatirmaCikis.Visible = true;
                            yazi = "Hesabınıza " + para + " ₺ yatırılmıştır.";
                            string[] row = { label9.Text, SifreGiris.tckn1, dt.ToShortDateString(), yazi };
                            var satir = new ListViewItem(row);
                            listView1.Items.Add(satir);
                            btnParaYatirmaCikis.Visible = true;
                            btnKHPY.Visible = false;
                        }
                        Hesap_Hareketleri();
                    }
                }
                else
                {
                        btnKHPY.Visible = true;
                        int HesapNo = int.Parse(textBox2.Text);
                        tckn = SifreGiris.tckn1;
                        if (textBox2.Text.Length <= 7)
                        {
                            MessageBox.Show("Hesap numarasını kontrol edin ve tekrar deneyin.");
                            textBox2.Clear();
                        }
                        else if (parayatirma == "Başkasının Hesabına")
                        {
                            using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
                            {
                                if (db.State == ConnectionState.Closed) db.Open();
                                var sonuc = db.Query<MusteriBilgileri>("Musteri4_SELECT", new { @musterihesapno = HesapNo }, commandType: CommandType.StoredProcedure);
                                sonuc1 = sonuc.Count();

                            }
                            if (toplampara <= para)
                            {
                                MessageBox.Show("Hesabınızda Yeteri Kadar Limit Bulunmuyor. Havale İçin En Fazla " + kullanilabilirlimit + "₺ Gönderebilirsiniz.");
                            }
                            else if (sonuc1 > 0)
                            {
                                using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
                                {
                                    if (db.State == ConnectionState.Closed) db.Open();
                                    var sonuc = db.Query<MusteriBilgileri>("sp_MoneyTransfer", new { @PurchaserID = textBox2.Text, @SenderID = arama, @Amount = textBox4.Text, @retVal = 1 }, commandType: CommandType.StoredProcedure);
                                    toplampara = long.Parse(label10.Text) - para;
                                    label10.Text = toplampara + "";
                                    label11.Text = toplampara + "";
                                }
                                yazi = textBox2.Text + " Hesabına " + para + " ₺ yatırılmıştır.";
                            Hesap_Hareketleri();

                                string[] row = { label9.Text, SifreGiris.tckn1, dt.ToShortDateString(), yazi };
                                var satir = new ListViewItem(row);
                                listView1.Items.Add(satir);
                                textBox2.Clear();
                                textBox4.Clear();
                                btnParaYatirmaGeri.Visible = false;
                                btnKHPY.Visible = false;
                                panel5.Visible = false;
                                panel6.Visible = false;
                                label5.Visible = true;
                                label5.Text = "Havale İşlemi Başarılı Bir Şekilde Gerçekleştirilmiştir.";
                                btnParaYatirmaCikis.Visible = true;
                            }


                            if (sonuc1 == 0)
                            {
                                MessageBox.Show("Lütfen Hesap Numarasını Kontrol Edin ve Tekrar Deneyin.");
                            }
                        }
                    
                }
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ");
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string arama = label9.Text;
            long hesaptakitoplampara = long.Parse(label10.Text);//hesaptaki toplam para
            string yazi = "";
            if (parayatirma == "")
            {
                long cekilenpara = long.Parse(((Button)sender).Text);
                toplam = hesaptakitoplampara - cekilenpara;
                if (long.Parse(label10.Text) <= long.Parse(((Button)sender).Text))
                {
                    MessageBox.Show("Hesabınız Para Çekmeye Müsait Değildir.");
                }
                else
                {
                    using (SqlConnection sqlConnection = new SqlConnection(Globals.ConnectionString))
                    {
                        para = cekilenpara;
                        sqlConnection.Open();
                        sqlConnection.Execute("[MusteriParaYatir_UPDATE]", new { @kullanilabilirlimit = toplam, @musterihesapno = arama }, commandType: CommandType.StoredProcedure);
                        sqlConnection.Close();
                        MessageBox.Show("Lütfen Bekleyin Paranız Sayılıyor.");
                      Thread.Sleep(3000);
                        MessageBox.Show(cekilenpara + " ₺" + " Hesabınızdan Para Çekildi.");
                        yazi = "Hesabınızdan " + para + " ₺ çekilmiştir.";
                        string[] row = { label9.Text,SifreGiris.tckn1, dt.ToShortDateString(), yazi };
                        var satir = new ListViewItem(row);
                        listView1.Items.Add(satir);
                        textBox3.Clear();
                        panel1.Visible = false;
                        panel4.Visible = true;
                    }
                    label10.Text = toplam.ToString();
                    label11.Text = toplam.ToString();
                }
                Hesap_Hareketleri();
            }
            else if (parayatirma == "DİĞER")
            {
               long digercekilenpara = long.Parse(textBox3.Text);
                hesaptakitoplampara = long.Parse(label10.Text);
                toplam = hesaptakitoplampara - digercekilenpara;
                if (textBox3.Text.Length <= 1 || digercekilenpara%5!=0)
                {
                    MessageBox.Show("Para çekmek istediğiniz tutar en az 10 TL olmalıdır.");
                }
                else if (textBox3.Text.Length > 1)
                {
                    arama = label9.Text;
                    using (SqlConnection sqlConnection = new SqlConnection(Globals.ConnectionString))
                    {
                        sqlConnection.Open();
                        sqlConnection.Execute("[MusteriParaYatir_UPDATE]", new { @kullanilabilirlimit = toplam, @musterihesapno = arama }, commandType: CommandType.StoredProcedure);
                        sqlConnection.Close();
                        MessageBox.Show("Lütfen Bekleyin Paranız Sayılıyor.");
                        Thread.Sleep(3000);
                        MessageBox.Show(digercekilenpara + " ₺" + " Hesabınızdan Para Çekildi.");
                        parayatirma = "";
                        textBox3.Clear();
                        panel1.Visible = false;
                        panel4.Visible = true;
                        label10.Text = toplam.ToString();
                        label11.Text = toplam.ToString();
                    }
                    yazi = "Hesabınızdan " + digercekilenpara + " ₺ çekilmiştir.";
                    Hesap_Hareketleri();
                    string[] row = { label9.Text, SifreGiris.tckn1, dt.ToShortDateString(), yazi };
                    var satir = new ListViewItem(row);
                    listView1.Items.Add(satir);
                }
            }
        }
    }
}