using SensorClean.Application.Interface.Repositories;
using SensorClean.Application.Interface.School;
using SensorClean.Domain.Models;

namespace SensorClean.Application.Services.UseCases.School
{
    public class UpdateSchool : IUpdateSchool
    {

        private readonly List<SchoolModel> _schools = new();
        public SchoolModel? UpdateSchoolByID(int id, SchoolModel school)
        {
            var indexSchool = _schools.FindIndex(e => e.Id == id);
            if (indexSchool == -1) return null;

            var updaedSchool = school with { Id = id };
            _schools[indexSchool] = updaedSchool;
            return updaedSchool;
        }


        /// <summary>
        /// Simula a atualização de uma escola pelo ID.
        /// </summary>
        private readonly ISchoolRepository _schoolRepository;
        public UpdateSchool(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        public SchoolModel? updateSchoolByID(int id, SchoolModel school)
        {
            return _schoolRepository.Update(id, school);
        }
    }
}
