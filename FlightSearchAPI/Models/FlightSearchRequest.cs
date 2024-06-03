namespace FlightSearchAPI.Models
{
    public class FlightSearchRequest
    {
        public string? Origin { get; set; }
        public string? Destinition { get; set; }
        public DateOnly? DepartureDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
    }
}
