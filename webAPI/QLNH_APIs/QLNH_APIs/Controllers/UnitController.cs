using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;

namespace QLNH_APIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UnitController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UnitController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Unit> Get()
        {
            return _context.Unit.ToList();
        }

        [HttpGet("Id")]
        public object Get([FromQuery] int Id)
        {
            return _context.Unit.Where(unit => unit.Id == Id).Select(s => new
            {
                Unit = s,                
            }).FirstOrDefault();
        }

        [HttpPost]
        public Unit Post([FromQuery] Unit unit)
        {
            _context.Unit.Add(unit);
            _context.SaveChanges();
            return unit;
        }
    }
}
