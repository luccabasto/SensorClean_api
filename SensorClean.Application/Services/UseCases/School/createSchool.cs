using SensorClean.Domain.Models;
using SensorClean.Application.Interface.School;
using SensorClean.Application.Interface.Repositories;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;



namespace SensorClean.Application.Services.UseCases.School
{
    public class CreateSchool : ICreateSchool
    {

        private readonly ISchoolRepository _schoolRepository;

        public CreateSchool(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        /// <summary>
        /// Cria uma nova escola e armazena no repositório.
        /// </summary>
        public SchoolModel Create(SchoolModel school)
        {
            return _schoolRepository.Create(school);
        }

        /// <summary>
        /// Retorna todas as escolas do repositório (caso interface exija).
        /// </summary>
        public List<SchoolModel> List() => _schoolRepository.GetAll().ToList();
    }
}

