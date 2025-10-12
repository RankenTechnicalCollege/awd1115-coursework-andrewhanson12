using Microsoft.AspNetCore.Mvc;

namespace HOT3.Areas.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
