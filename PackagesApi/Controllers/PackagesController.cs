using Cmp.Services.Transport.V1;
using GPRSClient;
using GPRSClient.Models;
using GPRSClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PackagesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly ILogger<PackagesController> _logger;
        private readonly IAccomodationService accomodationService;
        private readonly IFlightsService flightsService;

        public PackagesController(ILogger<PackagesController> logger, IAccomodationService accomodationService, IFlightsService flightsService)
        {
            _logger = logger;
            this.accomodationService = accomodationService;
            this.flightsService = flightsService;
        }

        [HttpPost("search")]
        public async Task<ActionResult<PackagesSearchResponse>> SearchAsync([FromBody] PackagesSearchRequest request)
        {
            var accomodations = accomodationService.Search(request);
            var flights = flightsService.Search(request);
            var response = new PackagesSearchResponse();

            response.Flights = flights.Results.ToList();
            response.Hotels = accomodations.Results.ToList();

            var hotelId = 1;
            var flightId = 1;

            foreach (var hotel in response.Hotels)
            {
                foreach (var flight in response.Flights)
                {
                    response.Packages.Add(new Packages
                    {
                        Id = Guid.NewGuid(),
                        FlightId = flightId,
                        Hotelid = hotelId
                    });

                    flightId++;
                }
                hotelId++;
                flightId = 1;
            }

            return Ok(response);
        }
    }
}
