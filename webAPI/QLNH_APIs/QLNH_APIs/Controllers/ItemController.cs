using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;

namespace QLNH_APIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _context.Item.ToList();
        }

        [HttpGet("Id")]
        public object Get([FromQuery] int Id)
        {
            return _context.Item.Where(item => item.Id == Id).Select(s => new
            {
                Item = s,
            }).FirstOrDefault();
        }

        [HttpPost]
        public Item Post([FromQuery] Item item)
        {
            _context.Item.Add(item);
            _context.SaveChanges();
            return item;
        }
    }
}
