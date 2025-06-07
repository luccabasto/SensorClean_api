using SensorClean.Application.Interface.School;
using SensorClean.Domain.Models;

namespace SensorClean.Application.Services.UseCases.School
{
    public class RemoveSchool : IRemoveSchool
    {
        private readonly List<SchoolModel> _schools = new();
        public SchoolModel? getSchoolByID(int id) => _schools.FirstOrDefault(e => e.Id == id);


        public bool revomeSchoolByID(int id)
        {
            var school = getSchoolByID(id);
            return school is not null && _schools.Remove(school);
        }

        public bool removeSchoolByID(int id)
        {
            var school = _schools.FirstOrDefault(e => e.Id == id);
            return school is not null && _schools.Remove(school);
        }
    }
}
