using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace HOT3.Areas.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
