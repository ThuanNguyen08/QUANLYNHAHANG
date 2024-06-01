using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;
using System.Data;

namespace QLNH_APIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _context.Role.ToList();
        }

        [HttpGet("Id")]
        public object Get([FromQuery] int Id)
        {
            return _context.Role.Where(role => role.Id == Id).Select(s => new
            {
                //Id = s.Id,
                //Name = s.Name,
                //Description = s.Description,
                //CreatedDate = s.CreatedDate,
                //Updated = s.Updated,
                //Deleted = s.Deleted,

                role = s

            }).FirstOrDefault();
        }

        [HttpPost]
        public Role Post([FromQuery] Role role)
        {
            _context.Role.Add(role);
            _context.SaveChanges();
            return role;
        }
    }
}
