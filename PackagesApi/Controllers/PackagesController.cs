using GPRSClient;
using Microsoft.AspNetCore.Mvc;

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
    }
}
