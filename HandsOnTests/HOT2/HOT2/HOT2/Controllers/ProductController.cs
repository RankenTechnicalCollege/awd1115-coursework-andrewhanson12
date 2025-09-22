using HOT2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT2.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext Context { get; set; }
        public ProductController(ProductContext ctx)
        {
            Context = ctx;
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = Context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            Context.Products.Remove(product);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add New Product";
            ViewBag.Categories = Context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View("Edit", new Product());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit Product";
            ViewBag.Categories = Context.Categories.OrderBy(c => c.CategoryName).ToList();
            var product = Context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                    Context.Products.Add(product);
                else
                    Context.Products.Update(product);
                    Context.SaveChanges();
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (product.ProductId == 0) ? "Add New Product" : "Edit Product";
                ViewBag.Categories = Context.Categories.OrderBy(c => c.CategoryName).ToList();
                return View(product);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
