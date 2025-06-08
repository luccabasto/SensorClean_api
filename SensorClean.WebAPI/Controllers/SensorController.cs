using Microsoft.AspNetCore.Mvc;
using SensorClean.Application.Interface.Sensor;
using SensorClean.Domain.Models;

namespace SensorClean.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly ICreateSensor _createSensor;
        private readonly IGetAllSensors _getAllSensors;

        public SensorController(ICreateSensor createSensor, IGetAllSensors getAllSensors)
        {
            _createSensor = createSensor;
            _getAllSensors = getAllSensors;
        }

        // GET api/sensor
        [HttpGet]
        public IActionResult GetAllSensors() => Ok(_getAllSensors.Execute());

        // POST api/sensor
        [HttpPost]
        public IActionResult Create([FromBody] SensorModel sensor)
        {
            var created = _createSensor.Create(sensor);
            return CreatedAtAction(nameof(GetAllSensors), new { id = created.Id }, created);
        }
    }
}
