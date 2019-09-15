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
    public partial class UserControl1 : UserControl
    {
        BankaBilgileri bnk = new BankaBilgileri();
        KurucuBilgileri krc = new KurucuBilgileri();
        UserControl5 user5 = new UserControl5();
        ErrorProvider provider = new ErrorProvider();
        public bool TCKN(string Tckn)
        {
            try
            {
                double index = 0;
                double tpm = 0;
                foreach (var item in Tckn){
                    if (index < 10){
                        tpm += Convert.ToInt32(char.ToString(item));
                    }
                    index++;
                }
                if (tpm % 10 != Convert.ToInt32(Tckn[10].ToString()) || Tckn.Length <= 10){

                    mskdTckn.Clear();
                    return false;
                }
                return true;
            }
            catch{
                return false;
            }
            
        }
        public UserControl1()
        {
            InitializeComponent();
        }
        public void SadeceSayiGirisi(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.Handled != false){
                SystemSounds.Beep.Play();
            }
        }
        public void SadeceHarfGirisi(KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
            if (e.Handled != false){
                SystemSounds.Beep.Play();
            }
        }
        public void IconHatalı(string kontrol,string kontrol1)
        {
            string ata = kontrol;
            switch (kontrol1){
                case "txtBankaAdi": kontrol = "Bankanın adını girmelisiniz.";  break;
                case "txtBankaKodu": kontrol = "Bankanın kodunu girmelisiniz."; break;
                case "txtKaynakPara": kontrol = "Bankanın kaynak para miktarını girmelisiniz."; break;
                case "textBox4": kontrol = "Bankanın website adresini girmelisiniz."; break;
                case "txtAdi": kontrol = "Bankanın kurucu adını girmelisiniz."; break;
                case "txtSoyadi": kontrol = "Bankanın kurucu soyadını girmelisiniz."; break;
                case "txtSifre": kontrol = "Bankanın kurucu şifrenizi girmelisiniz."; break;
                case "mskdTckn": kontrol = "Bankanın kurucu kişinin T.C.kimlik numarasını girmelisiniz."; break;
                default:
                    break;
            }
            string name = kontrol1;
            Control ctn = this.Controls[name];
            ctn.Name = name;
            if (ata == ""){
                provider.SetError(ctn, kontrol);
            }
            else{
                provider.SetError(ctn, "");
            }
                
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            dtBankaTarihi.Value = DateTime.Now;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int sonuc2 = 0;
            int sonuc4 = 0;
            try{
                
                bnk.BankaAdi = txtBankaAdi.Text;
                bnk.BankaninWebSitesi = textBox4.Text;
                krc.KurucuAdi = txtAdi.Text;
                krc.KurucuSoyadi = txtSoyadi.Text;
                bnk.BankaKodu = int.Parse(txtBankaKodu.Text);
                bnk.KaynakPara = long.Parse(txtKaynakPara.Text);
                bnk.BankaKurulusTarihi = DateTime.Parse(dtBankaTarihi.Text);
                krc.TCKN = mskdTckn.Text;
                krc.KurucuSifre = double.Parse(txtSifre.Text);
                if (bnk.BankaAdi == "" || bnk.BankaninWebSitesi == "" || krc.KurucuAdi == "" || krc.KurucuSoyadi == "" ||  TCKN(mskdTckn.Text) == false){
                    lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                }
                else if (txtBankaAdi.Text.Length <= 0 || txtAdi.Text.Length <= 2 || txtSoyadi.Text.Length <= 2){
                    lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
                }
                else if (txtBankaKodu.Text.Length <= 5 ) {
                    lblHataMesaji.Text = "Banka kodunuz en az 6 karakterli olabilir.";
                }
                else if (txtKaynakPara.Text.Length <= 9 || bnk.KaynakPara<30000000000){
                    lblHataMesaji.Text = "Banka kurmak için en az 30 milyar tl olmalıdır.";
                    txtKaynakPara.Clear();
                }
                else if (txtSifre.Text.Length < 5) {
                    lblHataMesaji.Text = "Şifreniz en az 5 karakterli olmalıdır.";
                }
                else if (chckKontrol.Checked == false){
                    lblHataMesaji.Text = "Lütfen kutucuğu işaretleyin.";
                }
                else{
                    using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
                    {
                                var sonuc1 = db.Query<BankaBilgileri>("BankaBilgileri_SELECT", new { @bankaadi = bnk.BankaAdi, @bankakodu = bnk.BankaKodu, @websitesi = bnk.BankaninWebSitesi }, commandType: CommandType.StoredProcedure);
                                sonuc4 = sonuc1.Count();
                                if (sonuc1.Count() > 0){
                                    lblHataMesaji.Text = "Bu bilgiler kayıtlarımızda mevcuttur. Lütfen bilgilerinizi değiştirip tekrar deneyin.";
                                }
                    }
                            if (sonuc4 <= 0) {
                    using (IDbConnection db = new SqlConnection  
                            (Globals.ConnectionString))
                    {
                            if (db.State == ConnectionState.Closed) db.Open();
                            var sonuc = db.Execute("BankaBilgileri_INSERT", bnk, commandType: CommandType.StoredProcedure);
                            var sonuc3 = db.Execute("KurucuBilgileri_INSERT", krc, commandType: CommandType.StoredProcedure);

                            if (sonuc > 0 || sonuc3 > 0){
                                Thread.Sleep(1000);
                                Application.Restart();
                                Environment.Exit(0);
                            }
                            else{
                                lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin.";
                            }
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
            catch (IndexOutOfRangeException)
            {
                lblHataMesaji.Text = "Lütfen bilgilerinizi kontrol edin ve tekrar deneyin. ";
            }
        }
        private void txtBankaAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceHarfGirisi(e);
        }
        private void txtBankaKodu_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);
        }
        private void txtKaynakPara_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);
        }
        private void txtAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceHarfGirisi(e);
        }
        private void txtSoyadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            SadeceHarfGirisi(e);
        }
        private void txtSifre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            SadeceSayiGirisi(e);
        }
        private void dtBankaTarihi_ValueChanged_1(object sender, EventArgs e)
        {
            if (dtBankaTarihi.Value > DateTime.Now){
                MessageBox.Show("Bankanın Kuruluş Tarihi" + "\n" + "İleri Tarihli Birgün Olamaz", "", MessageBoxButtons.OK);
                dtBankaTarihi.Value = DateTime.Now;
            }
        }
        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox1.Text != "Şifreniz sadece rakamlardan oluşmalıdır."){
                textBox1.Clear();
            }
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "Şifreniz sadece rakamlardan oluşmalıdır."){
                textBox1.Text = "Şifreniz sadece rakamlardan oluşmalıdır.";
                textBox1.UseSystemPasswordChar = false;
            }
            else{
                txtSifre.UseSystemPasswordChar = true;
            }
        }
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
            textBox1.UseSystemPasswordChar = true;
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == "Şifreniz sadece rakamlardan oluşmalıdır.")
            {
                textBox1.Clear();
                textBox1.UseSystemPasswordChar = true;
            }
        }
        private void txtBankaAdi_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IconHatalı(((TextBox)sender).Text, ((TextBox)sender).Name);
        }
        private void txtBankaKodu_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IconHatalı(((TextBox)sender).Text, ((TextBox)sender).Name);
        }
        private void txtKaynakPara_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IconHatalı(((TextBox)sender).Text, ((TextBox)sender).Name);
        }
        private void textBox4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IconHatalı(((TextBox)sender).Text, ((TextBox)sender).Name);
        }
        private void txtAdi_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IconHatalı(((TextBox)sender).Text, ((TextBox)sender).Name);
        }
        private void txtSoyadi_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IconHatalı(((TextBox)sender).Text, ((TextBox)sender).Name);
        }
        private void mskdTckn_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IconHatalı(((MaskedTextBox)sender).Text, ((MaskedTextBox)sender).Name);
        }
        private void txtSifre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IconHatalı(((TextBox)sender).Text, ((TextBox)sender).Name);
        }
    }
}
