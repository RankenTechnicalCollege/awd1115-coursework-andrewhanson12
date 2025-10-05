using Microsoft.AspNetCore.Mvc;

namespace CH07.Areas.Help.Controllers
{
    [Area("Help")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Help Page";
            return View();
        }
    }
}
