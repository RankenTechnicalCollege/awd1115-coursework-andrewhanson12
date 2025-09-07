using Microsoft.AspNetCore.Mvc;
using PriceQuotation.Models;

namespace PriceQuotation.Controllers
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
