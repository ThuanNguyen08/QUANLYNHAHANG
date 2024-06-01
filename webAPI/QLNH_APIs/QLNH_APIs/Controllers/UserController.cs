using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;

namespace QLNH_APIs.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.User.ToList();
        }

        [HttpGet("Id")]
        public object Get([FromQuery] int Id)
        {
            return _context.User.Where(user => user.ID == Id).Select(s => new
            {
                Id = s.ID,
                UserName = s.UserName,
                Password = s.Password
            }).FirstOrDefault();
        }

        [HttpPost]
        public User Post([FromQuery] User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
