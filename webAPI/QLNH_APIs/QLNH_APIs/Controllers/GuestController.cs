using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;

namespace QLNH_APIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class GuestController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GuestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Guest> Get()
        {
            return _context.Guest.ToList();
        }

        [HttpGet("Id")]
        public object Get([FromQuery] int Id)
        {
            return _context.Guest.Where(guest => guest.Id == Id).Select(s => new
            {
                Guest = s,
            }).FirstOrDefault();
        }

        [HttpPost]
        public Guest Post([FromQuery] Guest guest)
        {
            _context.Guest.Add(guest);
            _context.SaveChanges();
            return guest;
        }
    }
}
