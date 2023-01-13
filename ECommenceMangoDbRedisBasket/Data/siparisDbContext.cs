using ECommenceMangoDbRedisBasket.Data;
using ECommenceMangoDbRedisBasket.Interface;
using ECommenceMangoDbRedisBasket.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ECommenceMangoDbRedisBasket.Data
{
    public class siparisDbContext : ISiparis
    {

       // public readonly IMongoDatabase _db;
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Siparis> siparistablo = null;
        public siparisDbContext()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _database = _mongoClient.GetDatabase("eticaret");
            siparistablo = _database.GetCollection<Siparis>("siparis");
        }
        public IEnumerable<Siparis> getall()
        {
            return siparistablo.Find(a => true).ToList();
        }
        
        public void Create(Siparis siparis)
        {
            siparistablo.InsertOne(siparis);
        }
        
        //public void Delete(string _id)
        //{
        //    var ara = Builders<urunlerEntity>.Filter.Eq(c => c._id, _id);
        //    uruntablo.DeleteOne(ara);
        //}

       
    }
}
