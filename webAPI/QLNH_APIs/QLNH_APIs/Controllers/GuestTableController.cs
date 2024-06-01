using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;

namespace QLNH_APIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class GuestTableController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GuestTableController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<GuestTable> Get()
        {
            return _context.GuestTable.ToList();
        }

        [HttpGet("Id")]
        public object Get([FromQuery] int Id)
        {
            return _context.GuestTable.Where(guestTable => guestTable.Id == Id).Select(s => new
            {
                GuestTable = s,
            }).FirstOrDefault();
        }

        [HttpPost]
        public GuestTable Post([FromQuery] GuestTable guestTable)
        {
            _context.GuestTable.Add(guestTable);
            _context.SaveChanges();
            return guestTable;
        }
    }
}
