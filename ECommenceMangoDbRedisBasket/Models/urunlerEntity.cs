using MongoDB.Bson.Serialization.Attributes;

namespace ECommenceMangoDbRedisBasket.Models
{
    public class urunlerEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string UrunAdi { get; set; }
        public double Fiyat { get; set; }
        public string Aciklama { get; set; }
        public string Gorsel1 { get; set; }
        public string Gorsel2 { get; set; }
        public int KategoriID { get; set; }
    }
}
