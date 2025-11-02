using System.Diagnostics;
using EmployeeValidation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeValidation.Controllers
{
    public class HomeController : Controller
    {
        private SalesContext context { get; set; }
        public HomeController(SalesContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            IQueryable<Sales> query = context.Sales
                .Include(s => s.Employee)
                .OrderByDescending(s => s.Year);

            if (id > 0)
            {
                query = query.Where(s => s.EmployeeId == id);
            }

            SalesListViewModel vm = new SalesListViewModel
            {
                Sales = query.ToList(),
                Employees = context.Employees.OrderBy(e => e.FirstName).ToList(),
                EmployeeId = id
            };

            return View(vm);
        }
        [HttpPost]
        public RedirectToActionResult Index(Employee employee)
        {
            string id = (employee.EmployeeId > 0) ? employee.EmployeeId.ToString() : "";
            return RedirectToAction("Index", new { id = id });
        }
    }
}
