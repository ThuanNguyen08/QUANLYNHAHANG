using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;

namespace QLNH_APIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UnitTypeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UnitTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<UnitType> Get()
        {
            return _context.UnitType.ToList();
        }

        [HttpGet("Id")]
        public object Get([FromQuery] int Id)
        {
            return _context.UnitType.Where(unitType => unitType.Id == Id).Select(s => new
            {
                UnitType = s,
            }).FirstOrDefault();
        }

        [HttpPost]
        public UnitType Post([FromQuery] UnitType unitType)
        {
            _context.UnitType.Add(unitType);
            _context.SaveChanges();
            return unitType;
        }
    }
}
