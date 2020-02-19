using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public class TripsService :ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string Add(AddTripModel model)
        {
            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Seats = model.Seats,
                Description = model.Description,
                ImagePath = model.ImagePath,
            };
            db.Trips.Add(trip);
            db.SaveChanges();
            return trip.Id;
        }

        public IEnumerable<Trip> GetAll() 
            => this.db.Trips
                .Where(x=>x.Seats >= 1)
                .Select(x => new Trip
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime,
                Seats = x.Seats,
            })
            .ToArray();

        public Trip GetById(string id) => this.db.Trips.FirstOrDefault(x => x.Id == id);

        public bool AddUserToTrip(string userId, string tripId)
        {
            var trip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };
            var b = trip.Seats;
            if (!db.UserTrips.Any(x=>x.TripId == tripId && x.UserId == userId))
            {
                trip.Seats -= 1;
                trip.UserTrips.Add(userTrip);
                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
