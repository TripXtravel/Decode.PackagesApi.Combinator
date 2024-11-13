using GPRSClient;
using Microsoft.AspNetCore.Mvc;
using PackagesApi.Combinator.Models;

namespace PackagesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly ILogger<PackagesController> _logger;

        public PackagesController(ILogger<PackagesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            PingTest test= new PingTest();
            var r = await test.Main();
            return Ok(r);
        }

        [HttpGet]
        public async Task<ActionResult<string>> SearchAsync([FromBody] PackagesSearchRequest request)
        {
            //generate separate requests for the messenger
            var accomodationRequest = new Accomoda
            return Ok(r);
        }
    }
}
