using EmployeeValidation.Models;
using EmployeeValidation.Models.Validation;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace EmployeeValidation.Controllers
{
    public class EmployeeController : Controller
    {
        private SalesContext context { get; set; }
        public EmployeeController(SalesContext context) => this.context = context;
        public IActionResult Add()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.FirstName).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            // FIX: Use the correct namespace/class for Validation.Validate
            string msg = Validate.CheckEmployee(context, employee); 
            if(!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(Employee.DOB), msg);
            }
            msg = Validate.CheckManagerEmployeeMatch(context, employee);
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(Employee.ManagerId), msg);
            }
            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                TempData["message"] = $"Employee {employee.FullName} added";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = context.Employees.OrderBy(e => e.FirstName).ToList();
                return View();
            }
        }
    }
}
