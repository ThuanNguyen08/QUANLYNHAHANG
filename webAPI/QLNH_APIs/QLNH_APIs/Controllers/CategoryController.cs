using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;

namespace QLNH_APIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Category.ToList();
        }

        [HttpGet("Id")]
        public object Get([FromQuery] int Id)
        {
            return _context.Category.Where(category => category.Id == Id).Select(s => new
            {
                category = s,
            }).FirstOrDefault();
        }

        [HttpPost]
        public Category Post([FromQuery] Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return category;
        }
    }
}
