using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommenceMangoDbRedisBasket.Models
{
    public class Siparis
    {
        public string _id { get; set; }
        public string Urunid { get; set; }
        public string MusteriAdi { get; set; }
        public double Tutar { get; set; }
        public int Adet { get; set; }
        public DateTime Tarih { get; set; }
    }
}
