using System.Diagnostics;
using HOT2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOT2.Controllers
{
    public class HomeController : Controller
    {
        private ProductContext Context { get; set; }
        public HomeController(ProductContext ctx)
        {
            Context = ctx;
        }
        public IActionResult Index()
        {
            var products = Context.Products.Include(p => p.Category).OrderBy(p => p.ProductName).ToList();
            return View(products);
        }
    }
}
