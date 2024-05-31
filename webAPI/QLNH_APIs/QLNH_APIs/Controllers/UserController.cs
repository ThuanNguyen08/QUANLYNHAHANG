using Microsoft.AspNetCore.Mvc;

namespace QLNH_APIs.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return null;
        }
    }
}
