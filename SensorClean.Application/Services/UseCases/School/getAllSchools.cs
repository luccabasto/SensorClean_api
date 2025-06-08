using SensorClean.Application.Interface.Repositories;
using SensorClean.Application.Interface.School;
using SensorClean.Domain.Models;

namespace SensorClean.Application.Services.UseCases.School
{
    public class GetAllSchools : IGetAllSchools
    {

        private readonly ISchoolRepository _schoolRepository;

        public GetAllSchools(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        /// <summary>
        /// Retorna todas as escolas registradas no repositório.
        /// </summary>
        public IEnumerable<SchoolModel> Execute() => _schoolRepository.GetAll();

        /// <summary>
        /// Alias alternativo para retorno de todas as escolas.
        /// </summary>
        public IEnumerable<SchoolModel> ListAllSchools() => Execute();
    }
}
