using HOT4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HOT4.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly CustomerContext _context;

        public AppointmentsController(CustomerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appts = await _context.Appointments
                .Include(a => a.Customer)
                .OrderBy(a => a.StartDate)
                .ToListAsync();
            return View(appts);
        }

        public IActionResult Create()
        {
            LoadCustomers();
            return View(new Appointment { StartDate = DateTime.Now.AddHours(1) });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            ValidateAppointment(appointment);

            if (!ModelState.IsValid)
            {
                LoadCustomers();
                return View(appointment);
            }

            _context.Add(appointment);
            await _context.SaveChangesAsync();
            TempData["message"] = "Appointment created successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var appt = await _context.Appointments.FindAsync(id);
            if (appt == null) return NotFound();

            LoadCustomers();
            return View(appt);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Appointment appointment)
        {
            if (id != appointment.Id) return BadRequest();

            ValidateAppointment(appointment);
            if (!ModelState.IsValid)
            {
                LoadCustomers();
                return View(appointment);
            }

            _context.Update(appointment);
            await _context.SaveChangesAsync();
            TempData["message"] = "Appointment updated successfully.";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var appt = await _context.Appointments
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appt == null) return NotFound();
            return View(appt);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appt = await _context.Appointments.FindAsync(id);
            if (appt != null)
            {
                _context.Appointments.Remove(appt);
                await _context.SaveChangesAsync();
                TempData["message"] = "Appointment deleted successfully.";
            }
            return RedirectToAction(nameof(Index));
        }

        private void LoadCustomers()
        {
            ViewBag.CustomerId = new SelectList(_context.Customers.OrderBy(c => c.Username), "Id", "Username");
        }
        private void ValidateAppointment(Appointment appt)
        {
            if (appt.StartDate <= DateTime.Now)
            {
                ModelState.AddModelError(nameof(Appointment.StartDate),
                "Appointment must be scheduled in the future.");
            }
            if (appt.StartDate.Minute != 0)
            {
                ModelState.AddModelError(nameof(Appointment.StartDate),
                "Start time must be on the exact hour (e.g., 08:00AM).");
            }
            bool exists = _context.Appointments
            .Any(a => a.StartDate == appt.StartDate && a.Id != appt.Id);
            if (exists)
            {
                ModelState.AddModelError(nameof(Appointment.StartDate),
                "That exact date/time is already booked.");
            }
        }
    }
}
