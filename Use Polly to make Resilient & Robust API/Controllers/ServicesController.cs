using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Polly;
using RestSharp;
using Use_Polly_to_make_Resilient___Robust_API.services;

namespace Use_Polly_to_make_Resilient___Robust_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;
        private readonly NorrisServices _norrisServices;

        public ServicesController(ILogger<ServicesController> logger, NorrisServices norrisServices)
        {
            _logger = logger;
            _norrisServices = norrisServices;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {

            var amountToWait = TimeSpan.FromSeconds(5);
            var retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(5, _ => amountToWait, (exception, retryCount, context) =>
                {
                    Console.WriteLine($"Error: {exception.Message} - Retry: {retryCount}");
                });




            var response = await retryPolicy.ExecuteAsync( async () => await _norrisServices.NorrisServicesAsync());



                return Ok(response);
         

        }
    }
}
