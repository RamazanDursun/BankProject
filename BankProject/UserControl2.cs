using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
namespace BankProject
{
    
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
        Globals Globals = new Globals();
        HesapHareketleri hesap = new HesapHareketleri();
        private Thread cpuThread;
        private double[] cpuArray = new double[60];
        
        private void getPerformanceCounters()
        {
            var cpuPerfCounter = new PerformanceCounter("Processor Information","% Processor Time","_Total");
            while (true)
            {
                cpuArray[cpuArray.Length - 1] = Math.Round(cpuPerfCounter.NextValue(),0);
                Array.Copy(cpuArray,1,cpuArray,0,cpuArray.Length-1);
                if (chart1.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateCpuChart(); });
                }
                else
                {

                }
                   Thread.Sleep(1000);  

            }
        }
        private void UpdateCpuChart()
        {
            chart1.Series["CPU"].Points.Clear();
            for (int i = 0; i < cpuArray.Length; i++)
            {
                chart1.Series["CPU"].Points.AddY(cpuArray[i]);
            }
        }
        private void UserControl2_Load(object sender, EventArgs e)
        {
            int sonuc1 = 0;
            using (IDbConnection db = new SqlConnection(Globals.ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var sonuc = db.Query<HesapHareketleri>("Hesapa_SELECT", new { @musterihesapno = hesap.MusteriHesapNo }, commandType: 
CommandType.StoredProcedure);
                sonuc1 = sonuc.Count();
                chart2.Series["Kayıt Sayısı"].Points.AddY(sonuc1);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   }
        private void button1_Click_1(object sender, EventArgs e)
        {
            int a, b, c, d;
            float d1, d2, d3, d4, toplam = 0;
            Pen p;
            Graphics g;
            Brush b1, b2, b3, b4;
            a = 22;// veritabanından gelen değerleri tutacakalar.
            b = 33;
            c = 44;
            d = 55;
            toplam = a + b + c + d;
            d1 = (a / toplam) * 360;// çeviri yapıldıktan sonra grafik değerlerini tuacak.
            d2 = (b / toplam) * 360;
            d3 = (c / toplam) * 360;
            d4 = (d / toplam) * 360;
            p = new Pen(Color.Yellow, 2);
            g = this.CreateGraphics();
            Rectangle rec = new Rectangle(50, 100, 250, 250);
            b1 = new SolidBrush(Color.Red);
            b2 = new SolidBrush(Color.Cyan);
            b3 = new SolidBrush(Color.Blue);
            b4 = new SolidBrush(Color.Green);
            g.DrawPie(p, rec, 0, d1);
            g.FillPie(b1, rec, 0, d1);
            g.DrawPie(p, rec, d1, d2);
            g.FillPie(b2, rec, d1, d2);
            g.DrawPie(p, rec, d1 + d2, d3);
            g.FillPie(b3, rec, d1 + d2, d3);
            g.DrawPie(p, rec, d1 + d2 + d3, d4);
            g.FillPie(b4, rec, d1 + d2 + d3, d2);
            System.Drawing.Graphics grafiknesne;
            grafiknesne = this.CreateGraphics();
            Brush dolgu = new SolidBrush(System.Drawing.Color.Red);
            Brush dolgu1 = new SolidBrush(System.Drawing.Color.Cyan);
            Brush dolgu2 = new SolidBrush(System.Drawing.Color.Blue);
            Brush dolgu3 = new SolidBrush(System.Drawing.Color.BurlyWood);
            Brush dolgu4 = new SolidBrush(System.Drawing.Color.Green);
            grafiknesne.FillRectangle(dolgu, 165, 370, 10, 10);
            grafiknesne.FillRectangle(dolgu1, 165, 390, 10, 10);
            grafiknesne.FillRectangle(dolgu2, 165, 410, 10, 10);
            grafiknesne.FillRectangle(dolgu3, 165, 430, 10, 10);
            grafiknesne.FillRectangle(dolgu4, 165, 450, 10, 10);
            //grafiknesne.FillEllipse(dolgu2, 10, 180, 100, 50);
            //grafiknesne.FillEllipse(dolgu, 10, 240, 50, 50);
            pnlYillar.Visible = true;
            label7.Visible = true;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {   }

        private void button2_Click(object sender, EventArgs e)
        {
            cpuThread = new Thread(new ThreadStart(this.getPerformanceCounters));
            cpuThread.IsBackground = true;
            cpuThread.Start();


        }

        private void button3_Click(object sender, EventArgs e)
        {   }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.ForeColor = Color.White;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.ForeColor = Color.Black;
        }
    }
}
