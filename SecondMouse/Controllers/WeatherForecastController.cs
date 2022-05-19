using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondMouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("testGet")]
        [HttpGet]
        public IActionResult GetActionResult()
        {
            try
            {
                var rng = new Random();
                var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new OkObjectResult("get error");
            }
        }

        [Route("testPut")]
        [HttpPut]
        public IActionResult PutActionResult()
        {
            try
            {
                return new OkObjectResult("put");
            }
            catch (Exception ex)
            {
                return new OkObjectResult("put error");
            }
        }

        [Route("testPost")]
        [HttpPost]
        public IActionResult PostActionResult()
        {
            try
            {
                return new OkObjectResult("post");
            }
            catch (Exception ex)
            {
                return new OkObjectResult("post error");
            }
        }

        [Route("testDelete")]
        [HttpDelete]
        public IActionResult DeleteActionResult()
        {
            try
            {
                return new OkObjectResult("delete");
            }
            catch (Exception ex)
            {
                return new OkObjectResult("delete error");
            }
        }
    }
}
