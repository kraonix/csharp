using Microsoft.AspNetCore.Mvc;

namespace MySwaggerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[]
        {
            new { Id = 1, Forecast = "Sunny", Temperature = 32 },
            new { Id = 2, Forecast = "Cloudy", Temperature = 28 },
            new { Id = 3, Forecast = "Rainy", Temperature = 24 }
        });
    }
}