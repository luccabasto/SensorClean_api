using Microsoft.AspNetCore.Mvc;
using SensorClean.Application.Interface.Alert;
using SensorClean.Domain.Models;

namespace SensorClean.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        private readonly ICreateAlert _createAlert;
        private readonly IGetAllAlerts _getAllAlerts;

        public AlertController(ICreateAlert createAlert, IGetAllAlerts getAllAlerts)
        {
            _createAlert = createAlert;
            _getAllAlerts = getAllAlerts;
        }

        // GET api/alert
        [HttpGet]
        public IActionResult GetAllAlerts() => Ok(_getAllAlerts.Execute());

        // POST api/alert
        [HttpPost]
        public IActionResult Create([FromBody] AlertModel alert)
        {
            var created = _createAlert.Create(alert);
            return CreatedAtAction(nameof(GetAllAlerts), new { id = created.Id }, created);
        }
    }
}
