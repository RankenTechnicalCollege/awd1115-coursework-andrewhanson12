using FinalProjectV2.Data;
using FinalProjectV2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectV2.Controllers
{
    [AllowAnonymous]
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchTerm = "")
        {
            var query = _context.Events.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(e =>
                    e.Name.Contains(searchTerm) ||
                    e.Location.Contains(searchTerm));
            }

            var vm = new EventListVM
            {
                SearchTerm = searchTerm,
                Events = query
                    .OrderBy(e => e.StartDate)
                    .ToList()
            };

            return View(vm);
        }
        public IActionResult Details(int id)
        {
            var ev = _context.Events.FirstOrDefault(e => e.EventId == id);
            if (ev == null) return NotFound();

            var ticketTypes = _context.TicketTypes
                .Where(t => t.EventId == id)
                .OrderBy(t => t.Name)
                .ToList();

            var tags = (from et in _context.EventTags
                        join t in _context.Tags on et.TagId equals t.TagId
                        where et.EventId == id
                        orderby t.Name
                        select t).ToList();

            var vm = new EventDetailsVM
            {
                Event = ev,
                TicketTypes = ticketTypes,
                Tags = tags
            };

            return View(vm);
        }
    }
}


