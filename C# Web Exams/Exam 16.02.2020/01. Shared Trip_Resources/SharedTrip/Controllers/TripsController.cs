using System;
using System.Globalization;
using System.Linq;
using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        
        private readonly ITripsService tripsService;
        private readonly IUsersService usersService;

        public TripsController(ITripsService tripsService, IUsersService usersService)
        {
            this.tripsService = tripsService;
            this.usersService = usersService;
        }
        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripModel input)
        {
            if(!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Description.Length < 80)
            {
                return this.View();
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.View();
            }

            var tripId = this.tripsService.Add(input);


            return this.Redirect("/Trips/All");
        }


        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var allTrips = tripsService.GetAll();
            return this.View(allTrips);
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.GetById(id);

            return this.View(trip);

        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (this.tripsService.AddUserToTrip(this.User,tripId))
            {
                return this.Redirect("/Trips/All");
            }

            return this.Redirect($"/Trips/Details?tripId={tripId}");
        }
    }
}
