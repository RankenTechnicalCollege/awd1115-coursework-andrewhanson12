using System.Diagnostics;
using CH03Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace CH03Lab.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.DiscountAmount = 0;
            ViewBag.Total = 0;
            return View();
        }
        public IActionResult Index(CalculatePrice price)
        {
            ViewBag.DiscountAmount = price.CalculateDiscountAmount();
            ViewBag.Total = price.CalculateTotal();
            return View(price);
        }

    }
}
