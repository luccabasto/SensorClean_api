using SensorClean.Application.Interface.School;
using SensorClean.Domain.Models;

namespace SensorClean.Application.Services.UseCases.School
{
    public class UpdateSchool : IUpdateSchool
    {

        private readonly List<SchoolModel> _schools = new();
        public SchoolModel? updateSchoolByID(int id, SchoolModel school)
        {
            var indexSchool = _schools.FindIndex(e => e.Id == id);
            if (indexSchool == -1) return null;

            var updaedSchool = school with { Id = id };
            _schools[indexSchool] = updaedSchool;
            return updaedSchool;
        }

        public SchoolModel? UpdateSchoolById(int id, SchoolModel school)
        {
            throw new NotImplementedException();
        }
    }
}
