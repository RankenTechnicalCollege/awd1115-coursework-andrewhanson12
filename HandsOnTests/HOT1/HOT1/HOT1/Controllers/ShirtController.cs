using HOT1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT1.Controllers
{
    public class ShirtController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Discount = string.Empty;
            ViewBag.SubTotal = string.Empty;
            ViewBag.Tax = string.Empty;
            ViewBag.Total = string.Empty;
            return View();
        }
        [HttpPost]
        public IActionResult Index(ShirtOrder shirtOrder)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Discount = string.Empty;
                ViewBag.SubTotal = string.Empty;
                ViewBag.Tax = string.Empty;
                ViewBag.Total = string.Empty;
                return View();
            }
            ViewBag.Discount = shirtOrder.GetDiscount();
            ViewBag.SubTotal = $"Subtotal: {shirtOrder.CalculateSubTotal():C}";
            ViewBag.Tax = $"Tax: {shirtOrder.CalculateTax():C}";
            ViewBag.Total = $"Total: {shirtOrder.CalculateTotal():C}";
            return View();
        }
    }
}
