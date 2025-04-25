using Microsoft.AspNetCore.Mvc;

namespace bc_test_timesheetcs.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Employee : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<Employee> _logger;

        public Employee(ILogger<Employee> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEmpolyee")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date1 = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}