using System;
using System.Collections.Generic;
using System.Text;
using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        string Add(AddTripModel input);
        //(string startPoint, string endPoint, DateTime departureTime,int seats, string description, string imagePath);

        IEnumerable<Trip> GetAll();

        Trip GetById(string id);

        bool AddUserToTrip(string userId, string tripId);
    }
}
