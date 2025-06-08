using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SensorClean.Application.Interface.School;
using SensorClean.Domain.Models;

namespace SensorClean.WebAPI.Controllers
{

    /// <summary>
    /// Controller responsável por gerenciar as operações relacionadas às escolas.
    /// </summary>
    /// <returns> Operações Èscolas </returns>
    
    [ApiController]
    [Route("api/[controller]")]
    public class SchooolController : ControllerBase
    {

        private readonly IGetAllSchools _getAllSchools;
        private readonly IGetSchoolById _getSchoolById;
        private readonly ICreateSchool _createSchool;
        private readonly IUpdateSchool _updateSchool;
        private readonly IRemoveSchool _deleteSchool;

        public SchooolController(
            IGetAllSchools getAllSchools,
            IGetSchoolById getSchoolById,
            ICreateSchool createSchool,
            IUpdateSchool updateSchool,
            IRemoveSchool deleteSchool
            )
        {
            _getAllSchools = getAllSchools;
            _getSchoolById = getSchoolById;
            _createSchool = createSchool;
            _updateSchool = updateSchool;
            _deleteSchool = deleteSchool;
        }

        /// <summary>
        /// Retorna uma lista de todas as escolas.
        /// </summary>
        /// <returns>Lista de escolas.</returns>
        
        [HttpGet]
        public IActionResult GetAllSchools() => Ok(_getAllSchools.ListAllSchools());

        /// <summary>
        /// Retorna uma escola específica pelo ID.
        /// </summary>
        /// <returns> Escola por ID.</returns>
        /// <param name="id"> Identificador da escola.</param>
        /// <returns>Dados da escola ou NotFound se não encontrada.</returns>
        
        [HttpGet("{id:int}")]
        public IActionResult GetSchoolById(int id)
        {
            var result = _getSchoolById.getSchoolByID(id);
            return result is not null ? Ok(result) : NotFound($"Escola com ID {id} não encontrada.");
        }

        /// <summary>
        /// Cria uma nova escola.
        /// </summary>
        /// <param name="school">Dados de uma nova escola.</param>
        /// <return>Escola criada com status 201</return>
        
        [HttpPost]
        public IActionResult Create([FromBody] SchoolModel school)
        {
            var created = _createSchool.Create(school);
            return CreatedAtAction(nameof(GetSchoolById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza uma escola existente pelo ID.
        /// </summary>
        /// <param name="id">Identificador da escola a ser atualizada.</param>
        /// <returns>Escola atualizada ou Notfound.</returns>
        
        [HttpPut("{id:int}")]
        public IActionResult UpdateSchoolByID(int id, [FromBody] SchoolModel school)
        {
            var updated = _updateSchool.UpdateSchoolByID(id, school);
            return updated is not null ? Ok(updated) : NotFound($"Escola com ID {id} não encontrada.");
        }

        /// <summary>
        /// Remove uma escola pelo ID.
        /// </summary>
        /// <param name="id">ID da escola.</param>
        /// <returns>Status 200 se a operação for um sucesso, ou NotFound</returns>
        
        [HttpDelete("{id:int}")]
        public IActionResult RemoveSchoolByID(int id)
        {
            var result = _deleteSchool.removeSchoolByID(id);
            return result ? Ok($"Escola com ID {id} removida com sucesso.") : NotFound($"Escola com ID {id} não encontrada.");
        }
    }
}
