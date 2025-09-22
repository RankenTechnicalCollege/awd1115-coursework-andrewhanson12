using CH4.Models;
using Microsoft.AspNetCore.Mvc;

namespace CH4.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext Context { get; set; }
        public ContactController(ContactContext ctx)
        {
            Context = ctx;
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = Context.Contacts.Find(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            Context.Contacts.Remove(contact);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add Contact";
            ViewBag.Categories = Context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View("Edit", new Contact());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit Contact";
            ViewBag.Categories = Context.Categories.OrderBy(c => c.CategoryName).ToList();
            var contact = Context.Contacts.Find(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                {
                    Context.Contacts.Add(contact);
                }
                else
                {
                    Context.Contacts.Update(contact);
                }
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (contact.ContactId == 0) ? "Add" : "Edit";
                ViewBag.Categories = Context.Categories.OrderBy(c => c.CategoryName).ToList();
                return View("Edit", contact);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
