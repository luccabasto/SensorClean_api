using SensorClean.Domain.Models;
using SensorClean.Application.Interface.School;
using SensorClean.Application.Interface.Repositories;



namespace SensorClean.Application.Services.UseCases.School
{
    public class CreateSchool : ICreateSchool
    {

        /// <summary>
        /// Cria uma nova escola.
        /// </summary>
        private readonly List<SchoolModel> _schools = new();
        public SchoolModel Create(SchoolModel school)
        {
            var createdSchool = new SchoolModel(
                 id: _schools.Count + 1,
                 name: school.Name,
                 email: school.Email,
                 createdAt: DateTime.UtcNow,
                 isActive: true
               );

            _schools.Add(createdSchool);
            return createdSchool;
       }


        /// <summary>
        /// Simulando um repositório de escolas.
        /// </summary>
        private readonly ISchoolRepository _schoolRepository;
        public CreateSchool(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        public SchoolModel Execute(SchoolModel school) => _schoolRepository.Create(school);
        public List<SchoolModel> List() => _schools;
    }
}

