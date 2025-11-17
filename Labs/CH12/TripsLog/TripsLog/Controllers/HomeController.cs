using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using ModelsActivity = TripsLog.Models.Activity;
using TripsLog.Models;
using TripsLog.Models.Data;

namespace TripsLog.Controllers
{
    public class HomeController : Controller
    {
        private TripLogRepository _repo;

        public HomeController(TripLogRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            ViewBag.SubHeader = "View Trips";
            var trips = _repo.GetTrips();
            return View(trips);
        }
        [HttpGet]
        public IActionResult AddStep1()
        {
            ViewBag.SubHeader = "Add Trip Destination and Dates";
            ViewBag.Destinations = new SelectList(_repo.GetDestinations(), "DestinationId", "Name");
            ViewBag.Accommodations = new SelectList(_repo.GetAccommodations(), "AccommodationId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddStep1(int destinationId, int accommodationId, DateTime startDate, DateTime endDate)
        {
            if (destinationId == 0)
                ModelState.AddModelError("DestinationId", "Please select a destination.");
            if (accommodationId == 0)
                ModelState.AddModelError("AccommodationId", "Please select an accommodation.");

            if (!ModelState.IsValid)
            {
                ViewBag.SubHeader = "Add Trip Destination and Dates";
                ViewBag.Destinations = new SelectList(_repo.GetDestinations(), "DestinationId", "Name");
                ViewBag.Accommodations = new SelectList(_repo.GetAccommodations(), "AccommodationId", "Name");
                return View();
            }
            TempData["DestinationId"] = destinationId;
            TempData["AccommodationId"] = accommodationId;
            TempData["StartDate"] = startDate.ToString("o");
            TempData["EndDate"] = endDate.ToString("o");
            TempData.Keep();

            return RedirectToAction("AddStep2");
        }
        [HttpGet]
        public IActionResult AddStep2()
        {
            int destId = Convert.ToInt32(TempData["DestinationId"]);
            var destination = _repo.GetDestinations().First(d => d.DestinationId == destId);

            ViewBag.SubHeader = $"Add Things To Do in {destination.Name}";
            ViewBag.Activities = new MultiSelectList(_repo.GetActivities(), "ActivityId", "Name");

            TempData.Keep();
            return View();
        }
        [HttpPost]
        public IActionResult AddStep2(int[] activityIds, string button)
        {
            if (button == "Cancel")
            {
                TempData.Clear();
                return RedirectToAction("Index");
            }

            int destId = Convert.ToInt32(TempData["DestinationId"]);
            int accomId = Convert.ToInt32(TempData["AccommodationId"]);
            DateTime start = DateTime.Parse(TempData["StartDate"].ToString()!);
            DateTime end = DateTime.Parse(TempData["EndDate"].ToString()!);

            var trip = new Trip
            {
                DestinationId = destId,
                AccommodationId = accomId,
                StartDate = start,
                EndDate = end
            };

            _repo.AddTrip(trip, activityIds);
            TempData.Clear();
            TempData["Message"] = "Trip added.";

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteTrip(int id)
        {
            _repo.DeleteTrip(id);
            TempData["Message"] = "Trip deleted.";
            return RedirectToAction("Index");
        }
        public IActionResult ManageDestinations()
        {
            ViewBag.SubHeader = "Manage Destinations";
            ViewBag.Error = TempData["Error"];
            var dests = _repo.GetDestinations();
            return View(dests);
        }
        [HttpPost]
        public IActionResult AddDestination(string name)
        {
            if (!string.IsNullOrEmpty(name))
                _repo.AddDestination(new Destination { Name = name });

            return RedirectToAction("ManageDestinations");
        }
        [HttpPost]
        public IActionResult DeleteDestination(int id)
        {
            bool ok = _repo.DeleteDestination(id);
            if (!ok)
                TempData["Error"] = "Cannot delete destination that is used by a trip.";
            return RedirectToAction("ManageDestinations");
        }
        public IActionResult ManageAccommodations()
        {
            ViewBag.SubHeader = "Manage Accommodations";
            ViewBag.Error = TempData["Error"];
            var accs = _repo.GetAccommodations();
            return View(accs);
        }
        [HttpPost]
        public IActionResult AddAccommodation(string name, string phone, string email)
        {
            if (!string.IsNullOrEmpty(name))
                _repo.AddAccommodation(new Accommodation { Name = name, Phone = phone, Email = email });
            return RedirectToAction("ManageAccommodations");
        }
        [HttpPost]
        public IActionResult DeleteAccommodation(int id)
        {
            bool ok = _repo.DeleteAccommodation(id);
            if (!ok)
                TempData["Error"] = "Cannot delete accommodation that is used by a trip.";
            return RedirectToAction("ManageAccommodations");
        }
        public IActionResult ManageActivities()
        {
            ViewBag.SubHeader = "Manage Activities";
            ViewBag.Error = TempData["Error"];
            var acts = _repo.GetActivities();
            return View(acts);
        }
        [HttpPost]
        public IActionResult AddActivity(string name)
        {
            if (!string.IsNullOrEmpty(name))
                _repo.AddActivity(new ModelsActivity { Name = name });
            return RedirectToAction("ManageActivities");
        }
        [HttpPost]
        public IActionResult DeleteActivity(int id)
        {
            bool ok = _repo.DeleteActivity(id);
            if (!ok)
                TempData["Error"] = "Cannot delete activity that is used by a trip.";
            return RedirectToAction("ManageActivities");
        }
    }
}
