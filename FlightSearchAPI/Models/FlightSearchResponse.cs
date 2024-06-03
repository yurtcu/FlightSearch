using AirlineService;

namespace FlightSearchAPI.Models
{
    public class FlightSearchResponse
    {
        public FlightOption[] DepartureFlights { get; set; }
        public FlightOption[] ReturnFlights { get; set; }
    }
}
