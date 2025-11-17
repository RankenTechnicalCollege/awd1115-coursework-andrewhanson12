using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TripsLog.Models;

namespace TripsLog.Controllers
{
    public class HomeController : Controller
    {
        private TripContext _context;

        public HomeController(TripContext ctx)
        {
            _context = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "My Trip Log";
            ViewBag.SubHeader = "";

            ViewBag.Message = TempData["Message"];

            var trips = _context.Trips.OrderBy(t => t.StartDate).ToList();
            return View(trips);
        }
        [HttpGet]
        public IActionResult AddStep1()
        {
            ViewBag.Title = "My Trip Log";
            ViewBag.SubHeader = "Add Trip Destination and Dates";
            return View();
        }

        [HttpPost]
        public IActionResult AddStep1(string destination, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(destination))
                ModelState.AddModelError("destination", "Destination is required");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = "My Trip Log";
                ViewBag.SubHeader = "Add Trip Destination and Dates";
                return View();
            }

            TempData["Destination"] = destination;
            TempData["StartDate"] = startDate.ToString("o");
            TempData["EndDate"] = endDate.ToString("o");
            TempData.Keep();

            return RedirectToAction("AddStep2");
        }
        [HttpGet]
        public IActionResult AddStep2()
        {
            ViewBag.Title = "My Trip Log";
            ViewBag.SubHeader = $"Add Info for {TempData["Destination"]}";
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public IActionResult AddStep2(string accommodation, string? accommodationPhone, string? accommodationEmail)
        {
            if (string.IsNullOrEmpty(accommodation))
                ModelState.AddModelError("accommodation", "Accommodation is required");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = "My Trip Log";
                ViewBag.SubHeader = $"Add Info for {TempData["Destination"]}";
                TempData.Keep();
                return View();
            }

            TempData["Accommodation"] = accommodation;
            TempData["AccommodationPhone"] = accommodationPhone;
            TempData["AccommodationEmail"] = accommodationEmail;
            TempData.Keep();

            return RedirectToAction("AddStep3");
        }
        [HttpGet]
        public IActionResult AddStep3()
        {
            ViewBag.Title = "My Trip Log";
            ViewBag.SubHeader = $"Add Things To Do in {TempData["Destination"]}";
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public IActionResult AddStep3(string? activity1, string? activity2, string? activity3, string button)
        {
            if (button == "Cancel")
            {
                TempData.Clear();
                return RedirectToAction("Index");
            }

            var trip = new Trip
            {
                Destination = TempData["Destination"].ToString()!,
                StartDate = DateTime.Parse(TempData["StartDate"].ToString()!),
                EndDate = DateTime.Parse(TempData["EndDate"].ToString()!),

                Accommodation = TempData["Accommodation"].ToString()!,
                AccommodationPhone = TempData["AccommodationPhone"]?.ToString(),
                AccommodationEmail = TempData["AccommodationEmail"]?.ToString(),

                Activity1 = activity1,
                Activity2 = activity2,
                Activity3 = activity3
            };

            _context.Trips.Add(trip);
            _context.SaveChanges();

            TempData.Clear();
            TempData["Message"] = $"Trip to {trip.Destination} added.";

            return RedirectToAction("Index");
        }
        public IActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index");
        }
    }
}
