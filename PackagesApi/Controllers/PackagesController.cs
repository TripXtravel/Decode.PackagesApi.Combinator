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

        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            var request = accomodationService.CreateAccommodationSearchRequest();
            PingTest test = new PingTest();
            var r = await test.Main(request);

            var mockResponse = accomodationService.CreateAccommodationSearchResult();
            return Ok(mockResponse);
        }
        [HttpPost]
        public async Task<ActionResult<PackagesSearchResponse>> SearchAsync([FromBody] PackagesSearchRequest request)
        {
            //generate separate requests for the messenger
            var accomodations = accomodationService.Search(request.Accomodation.First());
            var flights = flightsService.Search(request.Transport.First());
            var response = new PackagesSearchResponse();

            response.Flights = flights.Results.ToList();
            response.Hotels = accomodations.Results.ToList();

            foreach (var hotel in response.Hotels)
            {
                foreach(var flight in response.Flights)
                {
                    response.Packages.Add(new Packages
                    {
                        Id = Guid.NewGuid(),
                        FlightId = flight.ResultId,
                        Hotelid = hotel.ResultId
                    });
                }
            }

            return Ok(response);
        }
    }
}
