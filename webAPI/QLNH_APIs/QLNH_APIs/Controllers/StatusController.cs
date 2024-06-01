using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;

namespace QLNH_APIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StatusController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return _context.Status.ToList();
        }

        [HttpGet("Id")]
        public object Get([FromQuery] int Id)
        {
            return _context.Status.Where(status => status.Id == Id).Select(s => new
            {
                Status = s,
            }).FirstOrDefault();
        }

        [HttpPost]
        public Status Post([FromQuery] Status status)
        {
            _context.Status.Add(status);
            _context.SaveChanges();
            return status;
        }
    }
}
