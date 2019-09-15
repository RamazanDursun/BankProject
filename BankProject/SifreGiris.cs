using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;


namespace BankProject
{
    public partial class SifreGiris : Form
    {
        UserControl4 use4 = new UserControl4();
        UserControl5 UC5 = new UserControl5();
        LoginGirisEkrani lgn = new LoginGirisEkrani();
        KurucuBilgileri krc = new KurucuBilgileri();
        PersonelBilgileri prsn = new PersonelBilgileri();
        UserControl3 user = new UserControl3();
        UserControl1 user1 = new UserControl1();
        public long musterihesapno = 0;
        public long kullanicilimiti=0;
        public DateTime songiristarihi=DateTime.Now;
        public void SadeceSayiGirisi(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.Handled != false)
            {
                SystemSounds.Beep.Play();
            }
        }
        public SifreGiris()
        {
            InitializeComponent();
        }
        void txtSil()
        {
            txtTckn.Clear();
            txtParola.Clear();
        }

        private void SifreGiris_Load(object sender, EventArgs e)
        {
            txtTckn.Focus();
            İsim.SetToolTip(Kapat, "Kapat");
        }
        private void Kapat_Click(object sender, EventArgs e)
        {
            
            this.Close();
            //Environment.Exit(0);//formu zorla kapatıyor
            
        }
        int hak = 3;
        public static string tckn1 = "";
        public string kullanicituru = "";
        public string kullanicituru1 = "";
        public string musteriadsoyad = "";
        private void button1_Click(object sender, EventArgs e)
        {
            tckn1 = txtTckn.Text;
            try
            {
               lgn.TCKN=txtTckn.Text;
                tckn1 = txtTckn.Text;
                lgn.Parola= txtParola.Text;
                prsn.PersonelTCKN = txtTckn.Text;
                if(user1.TCKN(lgn.TCKN) == false){
                    lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                    hak--;
                }
                else 
                {
                    using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
                    {
                        if (db.State == ConnectionState.Closed) db.Open();
                        if (kullanicituru == "Çalışan")
                        {
                            var sonuc1 = db.Query<PersonelBilgileri>("Personel3_SELECT", new { @personeltckn = txtTckn.Text, @personelparola = txtParola.Text, @calisanyonetici = kullanicituru }, commandType: CommandType.StoredProcedure);
                            if (sonuc1.Count() > 0)
                            {
                                foreach (var item in sonuc1)
                                {
                                    this.Close();
                                    txtSil();
                                }
                            }
                            else
                            {
                                lblMesaj.Text = "Lütfen girdiğiniz bilgileri kontrol edin yada\nbu alana girmeye yetkili olamayabilirsiniz.";
                                hak--;
                            }
                        }
                        else if (kullanicituru == "Bireysel Müşteri" || kullanicituru1 == "Ticari Müşteri")
                        {
                            using (IDbConnection db1 = new SqlConnection(Globals.ConnectionString))
                            {
                                if (db.State == ConnectionState.Closed) db.Open();
                                var sonuc2 = db.Query<MusteriBilgileri>("Musteri3_SELECT", new { @musteritckn = lgn.TCKN, @musterisubekodu = lgn.Parola }, commandType: CommandType.StoredProcedure);
                                if (sonuc2.Count() > 0)
                                {
                                    foreach (var item in sonuc2)
                                    {
                                        
                                        musterihesapno = item.MusteriHesapNo;
                                        musteriadsoyad = item.MusteriAdi + "  " + item.MusteriSoyadi;
                                        kullanicilimiti = item.KullanilabilirLimit;
                                        songiristarihi = item.SonGirisTarihi;
                                        txtSil();
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    lblMesaj.Text = "Lütfen girdiğiniz bilgileri kontrol edin ve tekrar deneyin. ";
                                }
                            }
                        }
                    }

                }
            }
            catch (FormatException)
            {
                lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                hak--;
            }
            catch (ArgumentException)
            {
                lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                hak--;
            }
            catch (OverflowException)
            {
                lblMesaj.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                hak--;
            }
            if (hak <= 0)
            {
                this.Close();
                Form1 frm1 = new Form1();
                frm1.Close();
                Application.Exit();
               
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
            if (char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
            if (e.KeyChar == '½')
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }
    }
}
