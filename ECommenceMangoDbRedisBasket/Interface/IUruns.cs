using ECommenceMangoDbRedisBasket.Models;
using System.Collections.Generic;

namespace ECommenceMangoDbRedisBasket.Interface
{
    public interface IUruns
    {
        IEnumerable<urunlerEntity> getallurun();
        urunlerEntity GeturunDetails(string _id);

        void Create(urunlerEntity urun);

        void Update(string _id, urunlerEntity urun);

        void Delete(string _id);
    }
}
