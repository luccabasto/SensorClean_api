using Microsoft.AspNetCore.Mvc;

namespace SensorClean.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
