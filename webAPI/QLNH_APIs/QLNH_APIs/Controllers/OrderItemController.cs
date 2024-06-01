using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;

namespace QLNH_APIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<OrderItem> Get()
        {
            return _context.OrderItem.ToList();
        }

        [HttpGet("Id")]
        public object Get([FromQuery] int Id)
        {
            return _context.OrderItem.Where(orderItem => orderItem.Id == Id).Select(s => new
            {
                OrderItem = s,
            }).FirstOrDefault();
        }

        [HttpPost]
        public OrderItem Post([FromQuery] OrderItem orderItem)
        {
            _context.OrderItem.Add(orderItem);
            _context.SaveChanges();
            return orderItem;
        }
    }
}
