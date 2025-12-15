using FinalProjectV2.Data;
using FinalProjectV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _context.Events
                .OrderBy(e => e.StartDate)
                .ToListAsync();

            return View(events);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Edit", new Event());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event e)
        {
            if (!ModelState.IsValid) return View("Edit", e);

            _context.Events.Add(e);
            await _context.SaveChangesAsync();
            TempData["message"] = "Event created.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var e = await _context.Events.FindAsync(id);
            if (e == null) return NotFound();
            return View(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Event e)
        {
            if (!ModelState.IsValid) return View(e);

            _context.Events.Update(e);
            await _context.SaveChangesAsync();
            TempData["message"] = "Event updated.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var e = await _context.Events.FindAsync(id);
            if (e == null) return NotFound();
            return View(e);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var e = await _context.Events.FindAsync(id);
            if (e == null) return NotFound();

            _context.Events.Remove(e);
            await _context.SaveChangesAsync();
            TempData["message"] = "Event deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}

