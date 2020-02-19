namespace SharedTrip.Models
{
    public class UserTrip
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public string TripId { get; set; }

        public Trip Trip { get; set; }


        //•	Has UserId – a string
        //•	Has User – a User object
        //•	Has TripId– a string
        //•	Has Trip – a Trip object

    }
}
