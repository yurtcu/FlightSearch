using AirlineService;
using FlightSearchAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightSearchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightSearchController : ControllerBase
    {
        private static readonly string[] AirPorts = new[]
        {
            "Ýstanbul (IST)", 
            "Sabiha Gökçen (SAW)",
            "Ankara (ESB)",
            "Ýzmir (ADB)",
            "Adana (ADA)",
            "Antalya (ANT)",
            "Ordu-Giresun (OGU)",
            "Van (VAN)"
        };

        private readonly ILogger<FlightSearchController> _logger;

        public FlightSearchController(ILogger<FlightSearchController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IEnumerable<string> GetAirports()
        {
            return AirPorts;
        }

        [HttpPost]
        public FlightSearchResponse SearchFlights(FlightSearchRequest req)
        {
            var ret = new FlightSearchResponse();

            try
            {
                var airlineWS = new AirSearchClient();
                var searchReq = new SearchRequest {
                    DepartureDate = req.DepartureDate.GetValueOrDefault().ToDateTime(new TimeOnly(0, 0, 0)),
                    Origin = req.Origin,
                    Destination = req.Destinition
                };

                var results = airlineWS.AvailabilitySearchAsync(searchReq).Result;
                ret.DepartureFlights = results.FlightOptions;

                if (req.ReturnDate.HasValue)
                {
                    searchReq.DepartureDate = req.ReturnDate.Value.ToDateTime(new TimeOnly(0, 0, 0));
                    searchReq.Origin = req.Destinition;
                    searchReq.Destination = req.Origin;

                    var returnResults = airlineWS.AvailabilitySearchAsync(searchReq).Result;
                    ret.ReturnFlights = returnResults.FlightOptions;
                }

                return ret;
            }
            catch
            {
                throw;
            }
        }
    }
}
