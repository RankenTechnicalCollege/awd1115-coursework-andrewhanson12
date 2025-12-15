using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventsController : Controller
    {
        private readonly StarlightContext _context;

        public EventsController(StarlightContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var eventsList = await _context.Events
                .OrderBy(e => e.EventDate)
                .ToListAsync();

            return View(eventsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Event());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event ev)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(ev);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{ev.Title} was added.";
                return RedirectToAction(nameof(Index));
            }

            return View(ev);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, string slug)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Event ev)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Update(ev);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{ev.Title} was updated.";
                return RedirectToAction(nameof(Index));
            }
            return View(ev);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, string slug)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Event ev)
        {
            var entity = await _context.Events.FindAsync(ev.EventId);
            if (entity == null) return NotFound();

            string title = entity.Title;

            _context.Events.Remove(entity);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"{title} was deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}

