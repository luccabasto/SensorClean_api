using SensorClean.Application.Interface.Repositories;
using SensorClean.Application.Interface.School;
using SensorClean.Domain.Models;

namespace SensorClean.Application.Services.UseCases.School
{
    public class UpdateSchool : IUpdateSchool
    {


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
