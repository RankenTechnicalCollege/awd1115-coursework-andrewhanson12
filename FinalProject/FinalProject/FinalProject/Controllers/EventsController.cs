using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models.ViewModels;

namespace FinalProject.Controllers
{
    public class EventsController : Controller
    {
        private readonly StarlightContext _context;

        public EventsController(StarlightContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 5, string searchTerm = "")
        {
            IQueryable<Event> query = _context.Events;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string s = searchTerm.Trim();
                query = query.Where(e => e.Title.Contains(s) || e.Location.Contains(s));
            }

            int totalCount = await query.CountAsync();

            var eventsList = await query
                .OrderBy(e => e.EventDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var vm = new EventsListViewModel
            {
                Events = eventsList,
                CurrentPage = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                SearchTerm = searchTerm
            };

            return View(vm);
        }


        public async Task<IActionResult> Details(int id, string slug)
        {
            var ev = await _context.Events
                .Include(e => e.TicketTypes)
                .Include(e => e.EventFeatures)
                    .ThenInclude(ef => ef.Feature)
                .FirstOrDefaultAsync(e => e.EventId == id);

            if (ev == null) return NotFound();

            var vm = new EventDetailsViewModel
            {
                Event = ev,
                TicketTypes = ev.TicketTypes.OrderBy(t => t.Price).ToList(),
                FeatureNames = ev.EventFeatures
                    .Where(ef => ef.Feature != null)
                    .Select(ef => ef.Feature!.Name)
                    .OrderBy(n => n)
                    .ToList()
            };

            return View(vm);
        }
    }
}

