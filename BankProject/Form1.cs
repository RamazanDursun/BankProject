using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BankProject
{
    public partial class Form1 : Form
    {
         bool drag = false;
        Point start_point = new Point(0, 0);
        SifreGiris SG = new SifreGiris();
        BankaBilgileri bnk = new BankaBilgileri();
        public string test = "";
        UserControl4 use4 = new UserControl4();
        public void PanelClose()
        {
            userControl11.Visible = false;
            userControl21.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
            SG.ShowDialog();
        }
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            //btnYonetici.MouseMove += RenkDegistirmeAqua;
            this.FormBorderStyle = FormBorderStyle.None;
            toolTip1.SetToolTip(Kapat, "Kapat");
            toolTip1.SetToolTip(Minimize, "Simge Durumuna");
            string sql = "Select TOP 1* From BankaBilgileri Order by BankaID desc";
            using (var connection = new SqlConnection(Globals.ConnectionString))
            {
                var bankaBilgileris = connection.Query<BankaBilgileri>(sql).ToList();

                foreach (var item in bankaBilgileris)
                {
                    lblBankaAdii.Text = item.BankaAdi;
                }
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnBankaBilgileri_Click(object sender, EventArgs e)
        {
            userControl11.Visible = true;
            userControl21.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
        }
        private void btnYonetici_MouseLeave(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "Banka Bilgileri": btnBankaBilgileri.ForeColor = Color.White; break;
                case "Finansal": btnFinansal.ForeColor = Color.White; break;
                case "Bireysel": btnBireysel.ForeColor = Color.White; break;
                case "Ticari": btnTicari.ForeColor = Color.White; break;
                case "Yönetici": btnYonetici.ForeColor = Color.White; break;
                default: break;
            }
        }
        private void RenkDegistirmeAqua(object sender, MouseEventArgs e)
        {
            //btnYonetici.ForeColor = Color.Aqua;
        }
        private void btnYonetici_MouseMove(object sender, MouseEventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "Banka Bilgileri": btnBankaBilgileri.ForeColor = Color.Aqua;break;
                case "Finansal": btnFinansal.ForeColor = Color.Aqua; break;
                case "Bireysel": btnBireysel.ForeColor = Color.Aqua; break;
                case "Ticari": btnTicari.ForeColor = Color.Aqua; break;
                case "Yönetici": btnYonetici.ForeColor = Color.Aqua; break;
                default: break;
            }
        }
        private void btnHosgeldiniz_Click(object sender, EventArgs e)
        {
            SG.kullanicituru = "Yönetici";
            PanelClose();
            userControl21.Visible = true;
        }
        private void btnBireysel_Click(object sender, EventArgs e)
        {
            SG.kullanicituru = "Bireysel Müşteri";
            SG.kullanicituru1 = "Ticari Müşteri";
            SG.txtParola.MaxLength = 4;
            PanelClose();
            userControl31.Visible = true;
            userControl31.label9.Text = SG.musterihesapno.ToString();
            userControl31.label8.Text = SG.musteriadsoyad;
            userControl31.label10.Text = SG.kullanicilimiti.ToString();
            userControl31.label11.Text = SG.kullanicilimiti.ToString();
            userControl31.label16.Text = SG.songiristarihi.ToShortDateString();
            string arama = SG.musterihesapno.ToString();
            using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var sonuc = db.Query<HesapHareketleri>("Hesap_SELECT", new { @musterihesapno = int.Parse(arama) }, commandType: CommandType.StoredProcedure);
                if (sonuc.Count() > 0)
                {
                    foreach (var item in sonuc)
                    {
                        string[] row = {item.MusteriHesapNo.ToString(),item.MusteriTckn,item.İslemTarihi.ToShortDateString(),item.İslemAciklama };
                        var satir = new ListViewItem(row);
                        userControl31.listView1.Items.Add(satir);
                    }
                }
            }
        }
        
        private void btnTicari_Click(object sender, EventArgs e)
        {
            SG.kullanicituru = "Çalışan";
            SG.txtParola.MaxLength = 49;
            PanelClose();
            userControl41.Visible = true;
            userControl41.dataGridView1.Visible = true;
            
            userControl41.dataGridView1.DataSource = userControl41.source();
        }
        private void btnYonetici_Click(object sender, EventArgs e)
        {
            SG.kullanicituru = "Kurucu";
            SG.txtParola.MaxLength = 16;
            PanelClose();
            userControl51.Visible = true;
            
        }
        private void lblBankaAdii_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
