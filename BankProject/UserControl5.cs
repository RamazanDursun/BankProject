using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace BankProject
{
    public partial class UserControl5 : UserControl
	{
        public UserControl5()
		{
			InitializeComponent();
		}
        public void SadeceSayiGirisi(KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
			if (e.Handled != false)
			{
				SystemSounds.Beep.Play();
			}
		}
        public void SadeceHarfGirisi(KeyPressEventArgs e)
		{
			e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
				 && !char.IsSeparator(e.KeyChar);
			if (e.Handled != false)
			{
				SystemSounds.Beep.Play();
			}
		}
        private void textclear(Control ctl)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
                if (item.Controls.Count > 0)
                {
                    textclear(item);
                    mskdTckn.Clear();
                    txtSifre.Clear();
                    txtSubeAdi.Clear();
                    txtHesapNo.Clear();
                    txtMusteriSifreTekrari.Text = "00.00.0000";
                    ClearSonrasitxt();
                }
            }
        }
        public void ClearSonrasitxt()
        {
            txtMusteriSifreTekrari.Text = "00.00.0000";
            txtMusteriTel.Text = "0 Rakamıyla Başlamayın";
            txtSifre.Text = "Hesabınıza Şifrenizi Giriniz";
            txtSubeAdi.Text = "Şube Adı Giriniz";
            txtHesapNo.Text = "Hesap Numarası Giriniz";
        }
        private void textclear1()
		{
            foreach (TextBox txt in this.PanelMusteri.Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }
            comboBox1.SelectedIndex = 0;
            mskdTckn.Clear();
            rdMusteriBireysel.Checked = false;
            rdMusteriTicari.Checked = false;
            ClearSonrasitxt();
        }
        public void txtTemizlik(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = item as TextBox;
                    txt.Clear();
                }
                
            }
        }
        string Personelİslemleri = "Müşteri İşlemleri";
        static public UserControl1 user1 = new UserControl1();
        MusteriBilgileri mstr = new MusteriBilgileri();
        DateTime SimdikiZaman = DateTime.Now;
        DateTime DogumTarihi;
        public string Tckn = "";
        PersonelBilgileri prsnl = new PersonelBilgileri();
        string ara = "";
        long kullanilabilirlimit = 0;
        int PersonelID = 0;
        public int Musteriid = 0;
        private void button2_Click(object sender, EventArgs e)
		{
            Personelİslemleri = btnPersonelİslemleri.Text;
            if (Personelİslemleri == btnPersonelİslemleri.Text)
            {
                PanelMusteri.Visible = true;
                lblMusteriAnneKizlikSoyadi.Text = "Maaş:";
                txtSifre.Text = "Doğum Yeriniz";
                txtSubeAdi.Text="Doğum Tarihiniz: 00.00.0000";
                txtHesapNo.Text = "Not Yaz:";
                rdMusteriBireysel.Text = "Çalışan";
                rdMusteriTicari.Text = "Yönetici";
                txtSifre.Clear();
                txtSubeAdi.Clear();
                txtHesapNo.Clear();
                txtSifre.Text = "Parola Giriniz";
                txtSubeAdi.Text = "Parolayı Tekrar Giriniz";
                txtHesapNo.Text = "Not Yaz";
                comboBox1.Visible = false;
                Personelİslemleri = "";
                txtSifre.MaxLength = 49;
                txtSifre.MaxLength = 49;
                txtHesapNo.MaxLength = 249;
            }
        }
        private void button1_Click(object sender, EventArgs e)
		{
            Personelİslemleri = btnMusteriİslemleri.Text;
            if (Personelİslemleri == btnMusteriİslemleri.Text)
            {
                btnMusteriAra.Visible = true;
                PanelMusteri.Visible = true;
                lblMusteriAnneKizlikSoyadi.Text = "Anne Kızlık" + "\n" + "Soyadı:";
                lblMusteriSifre.Text = "Doğum Yeri:";
                lblMusteriSifreTekrari.Text = "Doğum Tarihi:";
                txtSifre.Text = "Hesabınıza Şifre Giriniz";
                txtSifre.MaxLength = 4;
                txtSubeAdi.Text = "Şube Adı Giriniz";
                txtHesapNo.Text = "Hesap Numarası Giriniz";
                rdMusteriBireysel.Text = "Bireysel Müşteri";
                rdMusteriTicari.Text = "Ticari Müşteri";
                comboBox1.Visible = true;
                txtHesapNo.MaxLength = 8;
            }
        }
        private void UserControl5_Load(object sender, EventArgs e)
		{
            toolTip1.SetToolTip(btnMusteriAra, "Müşteriyi Listelemek İçin TCKN Yazın.");
			toolTip1.SetToolTip(btnMusteriSil, "Müşteriyi Silmek İçin TCKN Yazın.");
			comboBox1.SelectedIndex = 0;
        }
        
        
        private void btnMusteriKaydet_Click(object sender, EventArgs e)
        {
            int sonuc5 = 0;
            try
            {
                mstr.MusteriDogumTarihi = DateTime.Parse(txtMusteriSifreTekrari.Text);
                TimeSpan snc = mstr.MusteriDogumTarihi - SimdikiZaman;
                mstr.MusteriSubeKodu = int.Parse(txtSifre.Text);
                mstr.MusteriHesapNo = long.Parse(txtHesapNo.Text);
                mstr.MusteriHesapTuru = comboBox1.SelectedItem.ToString();
                mstr.SonGirisTarihi = DateTime.Parse(SimdikiZaman.ToShortDateString());
                mstr.MusteriAdi = txtMusteriAdi.Text;
                mstr.MusteriSoyadi = txtMusteriSoyadi.Text;
                mstr.MusteriTCKN = mskdTckn.Text;
                mstr.MusteriAnneKizlikSoyadi = txtMusteriAnneKizlikSoyadi.Text;
                mstr.MusteriDogumYeri = txtMusteriSifre.Text;
                mstr.MusteriTel = txtMusteriTel.Text;
                mstr.MusteriAdres = txtMusteriAdres.Text;
                mstr.MusteriSubeAdi = txtSubeAdi.Text;
                mstr.KullanilabilirLimit = kullanilabilirlimit;
                if (user1.TCKN(mskdTckn.Text) == false) 
                {
                    lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                }
                else if (snc.Days >= 1 || mstr.MusteriDogumTarihi.Year<1920)
                {
                    lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                }
                else if (mstr.MusteriTel.Length<9 || mstr.MusteriTel.Length > 10)
                {
                    lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                }
                else if (mstr.MusteriAdi == "" || mstr.MusteriSoyadi == "" || mstr.MusteriAnneKizlikSoyadi == "" || mstr.MusteriAdres == "" || mstr.MusteriSubeKodu.Equals(null))
                {
                    lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                }
                else if (mstr.MusteriDogumTarihi == null || mstr.MusteriSubeAdi == "" || mstr.MusteriSubeKodu.Equals(null))
                {
                    lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";

                }
                else if (comboBox1.Text == "Hesap Türü" || comboBox1.Text == "")
                {
                    lblHataMesaji.Text = "Lütfen Hesap Türünü Seçin.";
                }
                else if (rdMusteriBireysel.Checked != true && rdMusteriTicari.Checked != true)
                {
                    lblHataMesaji.Text = "Lütfen Hesap Cinsini Kontrol Edin.";
                }
                else if (txtMusteriTel.Text.Length < 9 || txtMusteriSifreTekrari.Text.Length < 8)
                {
                    lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                }
                 else if (Personelİslemleri == btnMusteriİslemleri.Text)
                 {
                     
                     if( txtHesapNo.Text.Length <= 7)
                     {
                        lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                     }
                    if (rdMusteriBireysel.Checked == true)
                    { mstr.BireyselTicari = "Bireysel Müşteri"; }
                    else { mstr.BireyselTicari = "Ticari Müşteri"; }
                    if (ara == "")
                    {
                        using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
                        {
                            var sonuc12 = db.Query<MusteriBilgileri>("Musteri2_SELECT", new { @musteritckn = mstr.MusteriTCKN, @Musterihesapno = mstr.MusteriHesapNo, @musteritel = mstr.MusteriTel }, commandType: CommandType.StoredProcedure);
                            sonuc5 = sonuc12.Count();
                        }
                        if (sonuc5 > 0)
                        {
                            lblHataMesaji.Text = "Bu Müşteri Kayıtlarınızda Mevcut.";
                        }
                        else
                        {
                            using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
                            {
                                if (db.State == ConnectionState.Closed) db.Open();
                                var sonuc = db.Execute("Musteri_INUP", mstr, commandType: CommandType.StoredProcedure);
                                    lblHataMesaji.Text = "Müşteri Eklendi.";
                                    txtTemizlik(sender, e);
                            }
                        }
                    }
                    else
                    { 
                        mstr.MusteriID = Musteriid;
                        using (SqlConnection sqlConnection = new SqlConnection(Globals.ConnectionString))
                        {
                            {
                                sqlConnection.Open();
                                sqlConnection.Execute("Musteri_INUP", mstr, commandType: CommandType.StoredProcedure);
                                sqlConnection.Close();
                                lblHataMesaji.Text = "Müşteri Bilgileri Güncellendi.";
                                sqlConnection.Execute("Musteri_DELETE2", new { @musteriid = Musteriid }, commandType: CommandType.StoredProcedure);
                                textclear1();
                                ara = "";
                            }
                            mstr.MusteriID = 0;
                        }
                    }
                 }
                else 
                {
                    prsnl.PersonelAdi = txtMusteriAdi.Text;
                    //Adi = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Adi);//sadece ilk harfi büyük
                    prsnl.PersonelSoyadi = txtMusteriSoyadi.Text;
                    //Soyadi = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Soyadi);
                    prsnl.PersonelTCKN = mskdTckn.Text;
                    prsnl.PersonelMaas = txtMusteriAnneKizlikSoyadi.Text;
                    prsnl.PersonelDogumYeri = txtMusteriSifre.Text;
                    //DogumYeri = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DogumYeri);
                    prsnl.PersonelDogumTarihi = DateTime.Parse(txtMusteriSifreTekrari.Text);
                    prsnl.PersonelAdres = txtMusteriAdres.Text;
                    prsnl.PersonelTelefon = txtMusteriTel.Text;
                    string parolatekrari = txtSifre.Text;
                    prsnl.PersonelParola = txtSubeAdi.Text;
                    prsnl.PersonelHakkinda = txtHesapNo.Text;
                    if (txtSifre.Text != txtSubeAdi.Text || txtSifre.Text.Length <= 9 || txtSubeAdi.Text.Length <= 9)
                    {
                        lblHataMesaji.Text = "Girdiğiniz Parololar Birbirlerine Eşit Değil Yada En Az 10 Karakterli Bir Parola Belirlemeniz Gerekmektedir.";
                        txtSifre.Clear();
                        txtSubeAdi.Clear();
                    }
                    if (rdMusteriBireysel.Checked == true)
                    {
                        prsnl.CalisanYonetici = rdMusteriBireysel.Text;
                    }
                    prsnl.CalisanYonetici = rdMusteriTicari.Text;
                    if (ara=="aradangeldim")
                    {
                        using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
                        {
                            if (db.State == ConnectionState.Closed) db.Open();
                            var sonuc12 = db.Query<PersonelBilgileri>("Personel2_SELECT", new { @personeltckn = prsnl.PersonelTCKN, @personelparola = prsnl.PersonelParola, @personeltel = prsnl.PersonelTelefon }, commandType: CommandType.StoredProcedure);
                            if (sonuc12.Count() > 0)
                            {
                                lblHataMesaji.Text = "Bu Personel Kayıtlarınızda Mevcut.";
                            }
                            else if (sonuc12.Count() <= 0)
                            {
                                var sonuc = db.Execute("Personel_INSERT", prsnl, commandType: CommandType.StoredProcedure);
                                if (sonuc > 0)
                                {
                                    lblHataMesaji.Text = "Personel Eklendi.";

                                    textclear(this);
                                }
                                else
                                {
                                    lblHataMesaji.Text = "Personel Eklenirken Hata Oluştu. Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                                }
                            }
                        }
                    }
                    if (ara == "aradangeldim")
                    {
                        mstr.MusteriID = 0;
                        using (SqlConnection sqlConnection = new SqlConnection(Globals.ConnectionString))
                        {
                            prsnl.PersonelID = PersonelID;
                            sqlConnection.Open();
                            
                            sqlConnection.Execute("Personel_UPDATE", prsnl, commandType: CommandType.StoredProcedure);
                            sqlConnection.Close();
                            lblHataMesaji.Text = "Personel Bilgileri Güncellendi.";
                            textclear(this);
                            txtSifre.UseSystemPasswordChar = false;
                            txtSubeAdi.UseSystemPasswordChar = false;
                        }
                    }
                }
            }
            catch (FormatException)
			{
                lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
			}
			catch (ArgumentException)
			{
                lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
			}
			catch (OverflowException)
			{
                lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
			}
			catch(IndexOutOfRangeException)
			{
                lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
			}
        }
        private void txtMusteriAdi_KeyPress(object sender, KeyPressEventArgs e)
		{
			SadeceHarfGirisi(e);
		}
        private void txtMusteriSoyadi_KeyPress(object sender, KeyPressEventArgs e)
		{
			SadeceHarfGirisi(e);
		}
        private void txtMusteriAnneKizlikSoyadi_KeyPress(object sender, KeyPressEventArgs e)
		{
            
            if (Personelİslemleri==btnMusteriİslemleri.Text)
            {
                SadeceHarfGirisi(e);
            }
            else
            {
                SadeceSayiGirisi(e);
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                if ((int)e.KeyChar == 046)
                {
                    e.Handled = false;

                }
                if (e.Handled != false)
                {
                    SystemSounds.Beep.Play();
                }
            }
        }
        private void txtMusteriSifre_KeyPress(object sender, KeyPressEventArgs e)
		{
            SadeceHarfGirisi(e);
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
            if (Personelİslemleri == btnMusteriİslemleri.Text)
            {
                SadeceHarfGirisi(e); 
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			SadeceSayiGirisi(e);
		}
        private void txtMusteriSifreTekrari_KeyPress(object sender, KeyPressEventArgs e)
		{
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if ((int)e.KeyChar == 046)
            {
                e.Handled = false;//eğer basılan tuş . ise yazdır.
            }
            if (e.Handled != false)
            {
                SystemSounds.Beep.Play();
            }
        }
        private void txtMusteriSifreTekrari_MouseLeave(object sender, EventArgs e)
		{
            if (txtMusteriSifreTekrari.Text=="")
            {
                txtMusteriSifreTekrari.Text = "00.00.0000";
            }

        }
        private void textBox4_MouseLeave_1(object sender, EventArgs e)
		{
            if (Personelİslemleri == btnMusteriİslemleri.Text)
            {
                if (txtMusteriTel.Text == "")
			    {
				txtMusteriTel.Text = "0 Rakamıyla Başlamayın";
			    }
            }
        }
       
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			SadeceSayiGirisi(e);
		}

		private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
		{
			//SadeceSayiGirisi(e);
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
			if ((int)e.KeyChar == 046)
			{
				e.Handled = false;
			}
			if (e.Handled != false)
			{
				SystemSounds.Beep.Play();
			}
		}
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
		{
			SadeceHarfGirisi(e);
		}
        private void toolTip1_Popup(object sender, PopupEventArgs e)
		{
        }
        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
		{
			SadeceHarfGirisi(e);
		}
        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
		{
			SadeceHarfGirisi(e);
		}
        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
			if ((int)e.KeyChar == 046)
			{
				e.Handled = false;
			}
			if (e.Handled != false)
			{
				SystemSounds.Beep.Play();
			}
		}
        private void txtPersonelTel_MouseLeave(object sender, EventArgs e)
		{
			if (txtMusteriTel.Text == "")
			{
				txtMusteriTel.Text = "0 Rakamıyla Başlamayın";
			}
		}
        private void txtPersonelTel_KeyPress(object sender, KeyPressEventArgs e)
		{
			SadeceSayiGirisi(e);
		}
        private void txtPersonelDogumYeri_KeyPress(object sender, KeyPressEventArgs e)
		{
			SadeceHarfGirisi(e);
		}
        private void txtPersonelDogumTarihi_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
			if ((int)e.KeyChar == 046)
			{
				e.Handled = false;
			}
			if (e.Handled != false)
			{
				SystemSounds.Beep.Play();
			}
		}
		
		private void button1_Click_1(object sender, EventArgs e)
		{
			string arama = mskdTckn.Text;
        }
       
		private void button1_Click_2(object sender, EventArgs e)
		{
            ara = "aradangeldim";
			string arama = mskdTckn.Text;

            if (user1.TCKN(arama) == false)
            {
                lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
            }
            else if (Personelİslemleri == btnMusteriİslemleri.Text)
            {
                using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
                {
                    if (db.State == ConnectionState.Closed) db.Open();
                    var sonuc1 = db.Query<MusteriBilgileri>("Musteri_SELECT", new { @musteritckn = arama }, commandType: CommandType.StoredProcedure);
                    if (sonuc1.Count() > 0)
                    {
                        lblHataMesaji.Text = "";

                        foreach (var item in sonuc1)
                        {
                            txtMusteriAdi.Text = item.MusteriAdi;
                            txtMusteriSoyadi.Text = item.MusteriSoyadi;
                            mskdTckn.Text = item.MusteriTCKN;
                            txtMusteriAnneKizlikSoyadi.Text =item.MusteriAnneKizlikSoyadi;
                            txtMusteriSifre.Text = item.MusteriDogumYeri;
                            txtMusteriSifreTekrari.Text = item.MusteriDogumTarihi.ToShortDateString();
                            txtMusteriTel.Text = item.MusteriTel;
                            txtMusteriAdres.Text = item.MusteriAdres;
                            txtSubeAdi.Text = item.MusteriSubeAdi;
                            txtSifre.Text = item.MusteriSubeKodu + "";
                            txtHesapNo.Text = item.MusteriHesapNo + "";
                            comboBox1.Text = item.MusteriHesapTuru;
                            kullanilabilirlimit = item.KullanilabilirLimit;
                            SimdikiZaman = item.SonGirisTarihi;
                            Musteriid = item.MusteriID;
                            if (item.BireyselTicari == "Bireysel")
                                rdMusteriBireysel.Checked = true;
                            else
                                rdMusteriTicari.Checked = true;
                            
                        }
                    }
                    else
                    {
                        lblHataMesaji.Text = "Müşteri Bulunamadı.";
                    }
                }
            }
            else
            {
                txtSifre.UseSystemPasswordChar=true;
                txtSubeAdi.UseSystemPasswordChar = true;
                txtTemizlik(sender, e);
                using (IDbConnection db0 = new SqlConnection(Globals.ConnectionString))
                {
                    if (db0.State == ConnectionState.Closed) db0.Open();
                    var sonuc = db0.Query<PersonelBilgileri>("Personel_SELECT", new { @personeltckn = arama }, commandType: CommandType.StoredProcedure);
                    if (sonuc.Count() > 0)
                    {
                       foreach (var item in sonuc)
                       {
                          txtMusteriAdi.Text = item.PersonelAdi;
                          txtMusteriSoyadi.Text = item.PersonelSoyadi;
                          mskdTckn.Text = item.PersonelTCKN;
                          txtMusteriAnneKizlikSoyadi.Text = item.PersonelMaas;
                          txtMusteriSifre.Text = item.PersonelParola;
                          txtSifre.Text = item.PersonelParola;
                          txtSubeAdi.Text = item.PersonelParola;
                          txtMusteriTel.Text = item.PersonelTelefon;
                          txtMusteriAdres.Text = item.PersonelAdres;
                          txtMusteriSifre.Text = item.PersonelDogumYeri;
                          txtMusteriSifreTekrari.Text = item.PersonelDogumTarihi.ToShortDateString();
                          txtHesapNo.Text = item.PersonelHakkinda;
                          PersonelID = item.PersonelID;
                             if (item.CalisanYonetici == "Çalışan")
                             {
                                 rdMusteriBireysel.Checked = true;
                             }
                             else
                             {
                                rdMusteriTicari.Checked = true;
                             }
                       }
                        btnMusteriKaydet.Enabled = true;
                    }
                    else
                    {
                        lblHataMesaji.Text = "Personel Bulunamadı.";
                    }
                }
                Personelİslemleri = "";
            }
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
		{
            string arama = mskdTckn.Text;
            if (user1.TCKN(arama) == false)
            {
                lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
            }
            else
            {
                using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
                {
                    if (db.State == ConnectionState.Closed) db.Open();
                    var sonuc = db.Query<MusteriBilgileri>("Musteri_SELECT", new { @musteritckn = arama }, commandType: CommandType.StoredProcedure);
                    var sonuc1 = db.Query<PersonelBilgileri>("Personel_SELECT", new { @personeltckn = arama }, commandType: CommandType.StoredProcedure);
                    if (sonuc.Count() > 0 || sonuc1.Count() > 0)
                    {
                        using (SqlConnection sqlConnection = new SqlConnection(Globals.ConnectionString))
                        {
                            sqlConnection.Open();
                            sqlConnection.Execute("Musteri_DELETE", new { @musteritckn = arama }, commandType: CommandType.StoredProcedure);
                            sqlConnection.Execute("Personel_DELETE", new { @personeltckn = arama }, commandType: CommandType.StoredProcedure);
                            sqlConnection.Close();
                            lblHataMesaji.Text = "İşlem Başarılı Bir Şekilde Gerçekleştirilmiştir.";
                            textclear1(/*this*/);
                        }
                    }
                    else
                    {
                        lblHataMesaji.Text = "İstenilen Kişi Bulunamadı.";
                    }
                }
            }
        }
        private void txtMusteriTel_KeyDown(object sender, KeyEventArgs e)
		{
			if (txtMusteriTel.Text == "0 Rakamıyla Başlamayın")
			{
				txtMusteriTel.Clear();
			}
		}
        private void txtSifre_MouseLeave(object sender, EventArgs e)
        {
            if (Personelİslemleri==btnMusteriİslemleri.Text)
            {
                if (txtSifre.Text=="")
                {
                    txtSifre.Text = "Hesabınıza Şifre Oluşturun";
                }
                else if(txtSubeAdi.Text == "")
                {
                    txtSubeAdi.Text = "Şube Adı Giriniz";
                }
                else if(txtHesapNo.Text == "")
                {
                    txtHesapNo.Text = "Hesap Numarası Giriniz";
                }
            }
        }
        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (Personelİslemleri == btnMusteriİslemleri.Text)
            {
                if (txtSifre.Text == "Hesabınıza Şifre Oluşturun")
                {
                    txtSifre.Clear();
                }
            }
        }
        private void txtSubeAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (Personelİslemleri == btnMusteriİslemleri.Text)
            {
                if (txtSubeAdi.Text == "Şube Adı Giriniz")
                {
                txtSubeAdi.Clear();
                }
            }
        }
        private void txtHesapNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (Personelİslemleri == btnMusteriİslemleri.Text)
            {
                if (txtHesapNo.Text == "Hesap Numarası Giriniz")
                {
                txtHesapNo.Clear();
                }
            }
        }
        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Personelİslemleri == btnMusteriİslemleri.Text)
            {
                SadeceSayiGirisi(e);
            }
        }
        private void txtSubeAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Personelİslemleri == btnMusteriİslemleri.Text)
            {
                SadeceHarfGirisi(e);
            }
        }
        private void txtHesapNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Personelİslemleri == btnMusteriİslemleri.Text)
            {
                SadeceSayiGirisi(e);
            }
        }
        private void txtSifre_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSifre.Text=="Hesabınıza Şifre Oluşturun" || txtSubeAdi.Text== "Şube Adı Giriniz" || txtHesapNo.Text== "Hesap Numarası Giriniz")
            {
                ((TextBox)sender).Clear();
            }
        }
        private void txtMusteriSifreTekrari_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtMusteriSifreTekrari.Text == "00.00.0000" )
            {
                ((TextBox)sender).Clear();
            }
        }
        private void txtMusteriTel_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtMusteriTel.Text == "0 Rakamıyla Başlamayın")
            {
                ((TextBox)sender).Clear();
            }
        }
        private void txtMusteriSifreTekrari_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtMusteriSifreTekrari.Text == "00.00.0000")
            {
                txtMusteriSifreTekrari.Clear();
            }
        }

        
    }
}
