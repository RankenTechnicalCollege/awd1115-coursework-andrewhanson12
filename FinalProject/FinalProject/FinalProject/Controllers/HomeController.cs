using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
// Add using final project models here and viewimports

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
