using FinalProjectV2.Data;
using FinalProjectV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class TicketTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int eventId = 0)
        {
            ViewBag.EventId = eventId;

            var ticketTypesQuery = _context.TicketTypes
                .Include(t => t.Event)
                .AsQueryable();

            if (eventId > 0)
                ticketTypesQuery = ticketTypesQuery.Where(t => t.EventId == eventId);

            var ticketTypes = await ticketTypesQuery
                .OrderBy(t => t.Event!.Name)
                .ThenBy(t => t.Name)
                .ToListAsync();

            ViewBag.Events = new SelectList(
                await _context.Events.OrderBy(e => e.Name).ToListAsync(),
                "EventId",
                "Name",
                eventId
            );

            return View(ticketTypes);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int eventId = 0)
        {
            await LoadEventsDropDown(eventId);
            return View(new TicketType { EventId = eventId > 0 ? eventId : 0 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketType ticketType)
        {
            if (!await EventExists(ticketType.EventId))
                ModelState.AddModelError(nameof(TicketType.EventId), "Please select a valid event.");

            if (ModelState.IsValid)
            {
                _context.TicketTypes.Add(ticketType);
                await _context.SaveChangesAsync();
                TempData["message"] = "Ticket type created.";
                return RedirectToAction(nameof(Index), new { eventId = ticketType.EventId });
            }

            await LoadEventsDropDown(ticketType.EventId);
            return View(ticketType);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ticketType = await _context.TicketTypes.FindAsync(id);
            if (ticketType == null) return NotFound();

            await LoadEventsDropDown(ticketType.EventId);
            return View(ticketType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TicketType ticketType)
        {
            if (id != ticketType.TicketTypeId) return BadRequest();

            if (!await EventExists(ticketType.EventId))
                ModelState.AddModelError(nameof(TicketType.EventId), "Please select a valid event.");

            if (ModelState.IsValid)
            {
                _context.Update(ticketType);
                await _context.SaveChangesAsync();
                TempData["message"] = "Ticket type updated.";
                return RedirectToAction(nameof(Index), new { eventId = ticketType.EventId });
            }

            await LoadEventsDropDown(ticketType.EventId);
            return View(ticketType);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ticketType = await _context.TicketTypes
                .Include(t => t.Event)
                .FirstOrDefaultAsync(t => t.TicketTypeId == id);

            if (ticketType == null) return NotFound();
            return View(ticketType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketType = await _context.TicketTypes.FindAsync(id);
            if (ticketType == null) return NotFound();

            int eventId = ticketType.EventId;

            _context.TicketTypes.Remove(ticketType);
            await _context.SaveChangesAsync();
            TempData["message"] = "Ticket type deleted.";

            return RedirectToAction(nameof(Index), new { eventId });
        }

        private async Task LoadEventsDropDown(int selectedEventId)
        {
            ViewBag.Events = new SelectList(
                await _context.Events.OrderBy(e => e.Name).ToListAsync(),
                "EventId",
                "Name",
                selectedEventId
            );
        }

        private async Task<bool> EventExists(int eventId)
        {
            return eventId > 0 && await _context.Events.AnyAsync(e => e.EventId == eventId);
        }
    }
}

