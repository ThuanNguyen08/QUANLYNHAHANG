using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;

namespace QLNH_APIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ItemImageController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemImageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ItemImage> Get()
        {
            return _context.ItemImage.ToList();
        }

        [HttpGet("Id")]
        public object Get([FromQuery] int Id)
        {
            return _context.ItemImage.Where(itemImage => itemImage.Id == Id).Select(s => new
            {
                ItemImage = s,
            }).FirstOrDefault();
        }

        [HttpPost]
        public ItemImage Post([FromQuery] ItemImage itemImage)
        {
            _context.ItemImage.Add(itemImage);
            _context.SaveChanges();
            return itemImage;
        }
    }
}
