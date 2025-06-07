using Microsoft.AspNetCore.Mvc;
using SensorClean.Application.Interface.School;
using SensorClean.Domain.Models;

namespace SensorClean.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchool _service;

        public SchoolController(ISchool service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllSchools());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var school = _service.GetSchoolById(id);
            return school is not null ? Ok(school) : NotFound();
        }

        [HttpPost]
        public IActionResult Post(SchoolModel school)
        {
            var created = _service.Create(school);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, SchoolModel school)
        {
            var updated = _service.UpdateSchoolById(id, school);
            return updated is not null ? Ok(updated) : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return (bool)_service.RemoveSchoolById(id) ? Ok() : NotFound();
        }
    }
}
