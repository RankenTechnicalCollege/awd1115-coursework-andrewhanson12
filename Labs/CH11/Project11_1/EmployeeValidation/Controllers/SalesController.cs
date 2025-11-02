using EmployeeValidation.Models;
using EmployeeValidation.Models.Validation;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeValidation.Controllers
{
    public class SalesController : Controller
    {
        private SalesContext context;
        public SalesController(SalesContext context) => this.context = context;
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.LastName).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Sales sales)
        {
            string msg = Validate.CheckSales(context, sales);
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(Sales.EmployeeId), msg);
            }
            if (ModelState.IsValid)
            {
                context.Sales.Add(sales);
                context.SaveChanges();
                TempData["message"] = "Sales record added successfully.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = context.Employees.OrderBy(e => e.LastName).ToList();
                return View();
            }
        }
    }
}
