using Microsoft.AspNetCore.Mvc;
using SensorClean.Application.Interface.Reading;
using SensorClean.Application.Services.UseCases.Reading;
using SensorClean.Domain.Models;

namespace SensorClean.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadingController : ControllerBase
    {
        private readonly ICreateReading _createReading;
        private readonly IGetAllReading _getAllReadings;

        public ReadingController(ICreateReading createReading, IGetAllReading getAllReadings)
        {
            _createReading = createReading;
            _getAllReadings = getAllReadings;
        }

        // GET api/reading
        [HttpGet]
        public IActionResult GetAllReadings() => Ok(_getAllReadings.Execute());

        // POST api/reading
        [HttpPost]
        public IActionResult Create([FromBody] ReadingModel reading)
        {
            var created = _createReading.Create(reading);
            return CreatedAtAction(nameof(GetAllReadings), new { id = created.Id }, created);
        }
    }
}
