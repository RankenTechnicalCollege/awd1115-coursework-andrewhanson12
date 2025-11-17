using Microsoft.EntityFrameworkCore;

namespace TripsLog.Models.Data
{
    public class TripLogRepository
    {
        private TripContext _context;
        public TripLogRepository(TripContext ctx)
        {
            _context = ctx;
        }
        public List<Trip> GetTrips()
        {
            return _context.Trips
                .Include(t => t.Destination)
                .Include(t => t.Accommodation)
                .Include(t => t.TripActivities)
                    .ThenInclude(ta => ta.Activity)
                .OrderBy(t => t.StartDate)
                .ToList();
        }

        public Trip? GetTrip(int id)
        {
            return _context.Trips
                .Include(t => t.TripActivities)
                .FirstOrDefault(t => t.TripId == id);
        }

        public void AddTrip(Trip trip, int[] activityIds)
        {
            trip.TripActivities = activityIds
                .Select(aid => new TripActivity { ActivityId = aid, Trip = trip })
                .ToList();

            _context.Trips.Add(trip);
            _context.SaveChanges();
        }

        public void DeleteTrip(int id)
        {
            var trip = _context.Trips.Find(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                _context.SaveChanges();
            }
        }
        public List<Destination> GetDestinations() =>
            _context.Destinations.OrderBy(d => d.Name).ToList();

        public void AddDestination(Destination dest)
        {
            _context.Destinations.Add(dest);
            _context.SaveChanges();
        }
        public bool DeleteDestination(int id)
        {
            bool inUse = _context.Trips.Any(t => t.DestinationId == id);
            if (inUse) return false;

            var dest = _context.Destinations.Find(id);
            if (dest != null)
            {
                _context.Destinations.Remove(dest);
                _context.SaveChanges();
            }
            return true;
        }
        public List<Accommodation> GetAccommodations() =>
            _context.Accommodations.OrderBy(a => a.Name).ToList();
        public void AddAccommodation(Accommodation a)
        {
            _context.Accommodations.Add(a);
            _context.SaveChanges();
        }
        public bool DeleteAccommodation(int id)
        {
            bool inUse = _context.Trips.Any(t => t.AccommodationId == id);
            if (inUse) return false;

            var a = _context.Accommodations.Find(id);
            if (a != null)
            {
                _context.Accommodations.Remove(a);
                _context.SaveChanges();
            }
            return true;
        }
        public List<Activity> GetActivities() =>
            _context.Activities.OrderBy(a => a.Name).ToList();
        public void AddActivity(Activity a)
        {
            _context.Activities.Add(a);
            _context.SaveChanges();
        }
        public bool DeleteActivity(int id)
        {
            bool inUse = _context.TripActivities.Any(ta => ta.ActivityId == id);
            if (inUse) return false;

            var a = _context.Activities.Find(id);
            if (a != null)
            {
                _context.Activities.Remove(a);
                _context.SaveChanges();
            }
            return true;
        }
    }
}
