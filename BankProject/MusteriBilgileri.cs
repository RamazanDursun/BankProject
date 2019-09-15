using System;

namespace BankProject
{
    public class MusteriBilgileri
    {
        public int MusteriID { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }
        public string MusteriTCKN { get; set; }
        public string MusteriAnneKizlikSoyadi { get; set; }
        public string MusteriDogumYeri { get; set; }
        public DateTime MusteriDogumTarihi { get; set; }
        public string MusteriTel { get; set; }
        public string MusteriAdres { get; set; }
        public string MusteriSubeAdi { get; set; }
        public int MusteriSubeKodu { get; set; }
        public long MusteriHesapNo { get; set; }
        public string MusteriHesapTuru { get; set; }
        public string BireyselTicari { get; set; }
        public long KullanilabilirLimit { get; set; }
        public DateTime SonGirisTarihi { get; set; }
        
    }
}