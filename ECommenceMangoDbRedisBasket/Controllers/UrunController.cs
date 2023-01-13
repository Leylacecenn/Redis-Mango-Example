using ECommenceMangoDbRedisBasket.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ECommenceMangoDbRedisBasket.Controllers
{
    public class UrunController : Controller
    {
        public readonly IUruns _context;

        public UrunController(IUruns context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.getallurun());
        }
    }
}
