using ECommenceMangoDbRedisBasket.Data;
using ECommenceMangoDbRedisBasket.Interface;
using ECommenceMangoDbRedisBasket.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ECommenceMangoDbRedisBasket.Data
{
    public class urunDbContext : IUruns
    {

        // public readonly IMongoDatabase _db;
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<urunlerEntity> uruntablo = null;
        public urunDbContext()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _database = _mongoClient.GetDatabase("eticaret");
            uruntablo = _database.GetCollection<urunlerEntity>("urun");
        }
        public IEnumerable<urunlerEntity> getallurun()
        {
            return uruntablo.Find(a => true).ToList();
        }

        public urunlerEntity GeturunDetails(string _id)
        {
            var urundetails = uruntablo.Find(c => c._id == _id).FirstOrDefault();
            return urundetails;
        }
        public void Create(urunlerEntity urun)
        {
            uruntablo.InsertOne(urun);
        }

        public void Delete(string _id)
        {
            var ara = Builders<urunlerEntity>.Filter.Eq(c => c._id, _id);
            uruntablo.DeleteOne(ara);
        }
        public void Update(string _id, urunlerEntity urun)
        {
            var ara = Builders<urunlerEntity>.Filter.Eq(c => c._id, _id);
            var update = Builders<urunlerEntity>.Update
                .Set("UrunAdi", urun.UrunAdi)
                .Set("Aciklama", urun.Aciklama)
                .Set("Fiyat", urun.Fiyat)
                .Set("KategoriID", urun.KategoriID)
                .Set("Gorsel1", urun.Gorsel1)
                .Set("Gorsel2", urun.Gorsel2);
            uruntablo.UpdateOne(ara, update);
        }


        //public IMongoCollection<urunlerEntity> uruncollection => _db.GetCollection<urunlerEntity>("urun");
        //public urunDbContext(IOptions<Settings> options)
        //{
        //    var client = new MongoClient(options.Value.ConnectionString);
        //    _db = client.GetDatabase(options.Value.Database);
        //}
    }
}
