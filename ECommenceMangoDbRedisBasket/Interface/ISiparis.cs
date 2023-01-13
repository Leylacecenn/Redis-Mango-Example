
using ECommenceMangoDbRedisBasket.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;

namespace ECommenceMangoDbRedisBasket.Interface
{
    public interface ISiparis
    {
        //burada urunler tablosu için genel Api mantığında crud methodları yazıldı
        //IMongoCollection<urunlerEntity> uruncollection { get; }
        IEnumerable<Siparis> getall();

        void Create(Siparis urun);


    }
}
