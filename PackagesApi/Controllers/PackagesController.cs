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
        [HttpGet]
        public async Task<ActionResult<PackagesSearchResponse>> SearchAsync([FromBody] PackagesSearchRequest request)
        {
            //generate separate requests for the messenger
            accomodationService.Search(request.Accomodation.First());
            flightsService.Search(request.Transport.First());
            var response = new PackagesSearchResponse();
            return Ok(response);
        }
    }
}
