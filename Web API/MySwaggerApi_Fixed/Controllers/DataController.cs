using Microsoft.AspNetCore.Mvc;

namespace MySwaggerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        public static List<string> Data { get; set; } = new List<string>
        {
            "Data Item 1",
            "Data Item 2",
            "Data Item 3"
        };

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

        [HttpPost]
        public IActionResult AddString(string newString)
        {
            Data.Add(newString);
            return Ok(new { Message = "String added successfully", Data});
        }

        // DELETE by index
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Data.Count)
            {
                return NotFound("Invalid index");
            }

            var removedItem = Data[index];
            Data.RemoveAt(index);

            return Ok(new
            {
                Message = "Item deleted successfully",
                Removed = removedItem,
                Data
            });
        }
    }
}
