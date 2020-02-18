using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SharedTrip.Models;

namespace SharedTrip.ViewModels.Trips
{
    public class ParsedTripModel
    {
        public string Id { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string DepartureTime { get; set; }
        public int Seats { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
