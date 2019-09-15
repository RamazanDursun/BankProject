using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using System.Xml;

namespace BankProject
{
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }
        public void SadeceSayiGirisi(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.Handled!=false)
            {
                SystemSounds.Beep.Play();
            }
        }
        UserControl1 user1 = new UserControl1();
        UserControl5 user = new UserControl5();
        Mevduatİslemleri mvdt = new Mevduatİslemleri();
        Dovizİslemleri dvz = new Dovizİslemleri();
        string def = "";
        long atalimit;
        byte atavade;
        private void UserControl4_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnPersonelSil, "Personeli Silmek İçin TCKN Yazın.");

            user.Visible = true;
            user.Show();
            panel2.Visible = false;
            dataGridView1.Visible = true;

        }
        string a;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a = "1";
                
                double sayi;
                    byte Vade = byte.Parse(numericUpDown1.Text);
                    long Limit = long.Parse(txtLimit.Text);
                    double sonuc = (Limit*0.020*Vade)+Limit;
                atalimit = Limit;
                atavade = Vade;
                if (txtLimit.Text.Length <= 3)
                    {
                        lblMesaj.Text = "Girdiğiniz limit minumum 1000tl olmalıdır";
                    }
                    else
                    {
                    sayi = sonuc / Vade;
                     sayi= Math.Round(sayi, 2);
                    lblToplamTutar.Text = sonuc+""/*+"\nAylık Taksit Tutarı: "+sayi*/;
                    lblMesaj.Text = "";
                    }
            }
                
            //}
            catch (FormatException)
            {
                lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
            }
            catch (ArgumentException)
            {
                lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
            }
            catch (OverflowException)
            {
                lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
             def = "fed";
            try
            {
                string Dolar = dataGridView1.Rows[0].Cells[2].Value.ToString();
                string Euro = dataGridView1.Rows[3].Cells[3].Value.ToString();
                if (comboBox2.Text.Length <= 0)
                {
                    lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                }
                else if (txtDovizTutari.Text.Length<=0 )
                {
                    lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                }

                else if (comboBox2.Text == "USD")
                {
                    decimal Tutar = decimal.Parse(txtDovizTutari.Text);
                    decimal sonuc = (decimal.Parse(Dolar) * Tutar)/10000;
                    lblToplamTutar2.Text = sonuc + " TL";
                    lblMesaj.Text = "";
                }
                else
                {
                    decimal Tutar = decimal.Parse(txtDovizTutari.Text);
                    decimal sonuc = (decimal.Parse(Euro) * Tutar )/ 10000;
                    lblToplamTutar2.Text = sonuc + " TL";
                    lblMesaj.Text = "";
                }
                }
            catch (FormatException)
            {
                lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
            }
            catch (ArgumentException)
            {
                lblMesaj.Text="Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
            }
            catch (OverflowException)
            {
                lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
            }
        }
        private void txtTCKN_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);

        }
        private void txtLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);
        }
        private void txtVade_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);
        }
        private void txtPersonelCepTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);
        }
        private void txtDovizTutari_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);
        }
        private void btnPersonelKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                mvdt.MusteriTckn = txtTCKN.Text;
                if (user1.TCKN(mvdt.MusteriTckn) == false || mvdt.MusteriTckn=="")
                {
                    lblMesaj.Text = "Lütfen TCKN kontrol edin ve tekrar deneyin. ";
                    txtTCKN.Clear();
                    
                }
                else if (lblToplamTutar.Text != "")
                {
                    mvdt.MusteriTckn = txtTCKN.Text;
                    mvdt.Limit = atalimit;
                    mvdt.VadeSuresi = atavade;
                }
               
                if (def == "fed")
                {
                    
                        dvz.MusteriTckn = txtTCKN.Text;
                        dvz.DovizCinsi = comboBox2.Text;
                        dvz.DovizTutari = long.Parse(txtDovizTutari.Text);
                    
                        using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
                        {
                                if (db.State == ConnectionState.Closed) db.Open();
                                var sonuc12 = db.Query<Dovizİslemleri>("Doviz_INSERT", new{@musteritckn=dvz.MusteriTckn,@dovizcinsi= dvz.DovizCinsi,@limit = dvz.DovizTutari }, commandType: CommandType.StoredProcedure);
                            lblMesaj.Text = "Döviz Hesabınız Oluşturulmuştur.";
                        }
                        def ="";
                }
                if(def!="fed" && a=="1")
                {
                    using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
                        {
                        if (db.State == ConnectionState.Closed) db.Open();
                        var sonuc12 = db.Query<Mevduatİslemleri>("Mevduat_INSERT", mvdt, commandType: CommandType.StoredProcedure);
                    
                        lblMesaj.Text = "Mevduat hesabınız oluşturulmuştur.";
                        }
                }
            }
            catch (FormatException)
            {
                lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
            }
            catch (ArgumentException)
            {
                lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
            }
            catch (OverflowException)
            {
                lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
            }
       
        }
        public DataTable source()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("Adı", typeof(string)));
            dt.Columns.Add(new DataColumn("Kod", typeof(string)));
            dt.Columns.Add(new DataColumn("Döviz alış", typeof(string)));
            dt.Columns.Add(new DataColumn("Döviz satış", typeof(string)));
            dt.Columns.Add(new DataColumn("Efektif alış", typeof(string)));
            dt.Columns.Add(new DataColumn("Efektif Satış", typeof(string)));
            XmlTextReader rdr = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");
            XmlDocument myxml = new XmlDocument();
            myxml.Load(rdr);
            XmlNode tarih = myxml.SelectSingleNode("/Tarih_Date/@Tarih");
            XmlNodeList mylist = myxml.SelectNodes("/Tarih_Date/Currency");
            XmlNodeList adi = myxml.SelectNodes("/Tarih_Date/Currency/Isim");
            XmlNodeList kod = myxml.SelectNodes("/Tarih_Date/Currency/@Kod");
            XmlNodeList doviz_alis = myxml.SelectNodes("/Tarih_Date/Currency/ForexBuying");
            XmlNodeList doviz_satis = myxml.SelectNodes("/Tarih_Date/Currency/ForexSelling");
            XmlNodeList efektif_alis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteBuying");
            XmlNodeList efektif_satis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteSelling");
            int x = 19;
            for (int i = 0; i < x; i++)
            {
                dr = dt.NewRow();
                dr[0] = adi.Item(i).InnerText.ToString();
                dr[1] = kod.Item(i).InnerText.ToString();
                dr[2] = doviz_alis.Item(i).InnerText.ToString();
                dr[3] = doviz_satis.Item(i).InnerText.ToString();
                dr[4] = efektif_alis.Item(i).InnerText.ToString();
                dr[5] = efektif_satis.Item(i).InnerText.ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private void btnDovizİslemleri_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.DataSource = source();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel2.Visible = true;
        }
        private void btnPersonelSil_Click(object sender, EventArgs e)
        {
            string arama = txtTCKN.Text;
            if (user1.TCKN(arama) == false)
            {
                lblMesaj.Text = "Lütfen TCKN Kontrol Edin ve Tekrar Deneyin. ";
                txtTCKN.Clear();
            }
            else
            {
                using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
                {
                    if (db.State == ConnectionState.Closed) db.Open();
                    var sonuc = db.Query<Mevduatİslemleri>("Doviz_SELECT", new { @musteritckn = arama }, commandType: CommandType.StoredProcedure);
                    if (sonuc.Count() > 0)
                    {
                        using (SqlConnection sqlConnection = new SqlConnection(Globals.ConnectionString))
                        {
                            sqlConnection.Open();
                            sqlConnection.Execute("Doviz_DELETE", new { @musteritckn = arama }, commandType: CommandType.StoredProcedure);
                            sqlConnection.Close();
                            lblMesaj.Text = "Müşteriye ait yapılan işlem başarılı bir şekilde gerçekleştirilmiştir.";
                        }
                    }
                    else
                    {
                        lblMesaj.Text = "Müşteri Bulunamadı. Lütfen Girdiğiniz Bilgileri Kontrol Edin ve Tekrar Deneyin.";
                    }
                }
            }
            
        }

        private void btnPersonelDegistir_Click(object sender, EventArgs e)
        {
            //içerisine kodlar yazılmadı..
        }
    }
}
