using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;

namespace QLNH_APIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _context.Order.ToList();
        }

        [HttpGet("Id")]
        public object Get([FromQuery] int Id)
        {
            return _context.Order.Where(order => order.Id == Id).Select(s => new
            {
                Order = s,
            }).FirstOrDefault();
        }

        [HttpPost]
        public Order Post([FromQuery] Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
            return order;
        }
    }
}
