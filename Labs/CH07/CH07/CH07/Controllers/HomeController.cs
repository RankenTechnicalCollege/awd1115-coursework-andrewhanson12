using System.Diagnostics;
using CH07.Models;
using Microsoft.AspNetCore.Mvc;

namespace CH07.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About() => View();
        public IActionResult Contact()
        {
            ViewBag.Phone = "425-555-0100";
            ViewBag.Email = "Me@MyWebsite.com";
            ViewBag.Facebook = "fb.com/MyProfile";
            return View();
        }
    }
}
