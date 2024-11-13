using GPRSClient;
using GPRSClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PackagesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly ILogger<PackagesController> _logger;
        private readonly IAccomodationService _accomodationService;

        public PackagesController(ILogger<PackagesController> logger, IAccomodationService accomodationService)
        {
            _logger = logger;
            _accomodationService = accomodationService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            var response = _accomodationService.CreateAccommodationSearchRequest();
            PingTest test= new PingTest();
            var r = await test.Main(response);
            return Ok(r);
        }

        //[HttpGet]
        //public async Task<ActionResult<string>> SearchAsync([FromBody] PackagesSearchRequest request)
        //{
        //    //generate separate requests for the messenger
        //    var accomodationRequest = new Accomoda
        //    return Ok(r);
        //}
    }
}
