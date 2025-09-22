using System.Diagnostics;
using CH4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CH4.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext Context { get; set; }
        public HomeController(ContactContext ctx)
        {
            Context = ctx;
        }
        public IActionResult Index()
        {
            var contacts = Context.Contacts.Include(c => c.Category).OrderBy(c => c.LastName).ToList();
            return View(contacts);
        }
    }
}
