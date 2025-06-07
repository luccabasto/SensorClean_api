using SensorClean.Application.Interface.School;
using SensorClean.Domain.Models;

namespace SensorClean.Application.Services.UseCases.School
{
    public class updateSchoolById : ISchool
    {

        private readonly List<SchoolModel> _schools = new();

        public SchoolModel? Create(SchoolModel school)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SchoolModel> GetAllSchools()
        {
            throw new NotImplementedException();
        }

        public SchoolModel? GetSchoolById(int id)
        {
            throw new NotImplementedException();
        }

        public bool? RemoveSchoolById(int id)
        {
            throw new NotImplementedException();
        }

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
