using System.Diagnostics;
using HOT1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Centimeters = 0;
            ViewBag.Message = string.Empty;
            return View();
        }
        [HttpPost]
        public IActionResult Index(ConvertDistance convertDistance)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Centimeters = 0;
                ViewBag.Message = string.Empty;
                return View();
            }
            ViewBag.Centimeters = convertDistance.ConvertToCm();
            ViewBag.Message = $"{convertDistance.Inches} inches equals {ViewBag.Centimeters} centimeters";
            return View();
        }
    }
}
