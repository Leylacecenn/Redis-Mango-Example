using ECommenceMangoDbRedisBasket.Interface;
using ECommenceMangoDbRedisBasket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pipelines.Sockets.Unofficial;
using System.Threading.Tasks;

namespace ECommenceMangoDbRedisBasket.Controllers
{
    public class SepetController : Controller
    {
        private IDistributedCache _distributedCache;

        public readonly IUruns _context;
        public SepetController(IDistributedCache distributedCache, IUruns context)
        {
            _context = context;
            _distributedCache = distributedCache;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> siparisCasheEkle(string id)
        {

            DistributedCacheEntryOptions cache = new DistributedCacheEntryOptions();
            cache.AbsoluteExpiration = DateTime.Now.AddMinutes(30);
            Siparis siparis = new Siparis { Adet = 1, MusteriAdi = "leyla"+ kayit.maxkayitsayisi, Tarih = DateTime.Now, Tutar = 100, Urunid = id};
            kayit.maxkayitsayisi--;
            string jsonsiparis = Newtonsoft.Json.JsonConvert.SerializeObject(siparis);
            await _distributedCache.SetStringAsync("Siparis" + kayit.maxkayitsayisi, jsonsiparis, cache);
            return RedirectToAction("Index", "Urun");
        }
        public IActionResult Siparisler()
        {
            List<Siparis> siparislist = new List<Siparis>();
            for (int i = 20; i > 0; i--)
            {
                string jsonsiparis = _distributedCache.GetString("Siparis" + i);
                if (jsonsiparis != null)
                {
                    var siparis = Newtonsoft.Json.JsonConvert.DeserializeObject<Siparis>(jsonsiparis);
                    siparislist.Add(siparis);
                }

            }
            ViewBag.sepettoplam = siparislist.Count;
            return View(siparislist);
        }
        public ActionResult sepettoplam()
        {
            List<Siparis> siparislist = new List<Siparis>();
            for (int i = 20; i > 0; i--)
            {
                string jsonsiparis = _distributedCache.GetString("Siparis" + i);
                if (jsonsiparis != null)
                {
                    var siparis = Newtonsoft.Json.JsonConvert.DeserializeObject<Siparis>(jsonsiparis);
                    siparislist.Add(siparis);
                }

            }
            ViewBag.sepettoplam = siparislist.Count;
            return View(siparislist);
        }
    }
}
