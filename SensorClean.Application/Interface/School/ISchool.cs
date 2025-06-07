using SensorClean.Domain.Models;

namespace SensorClean.Application.Interface.School
{
    public interface ISchool
    {
        IEnumerable<SchoolModel> GetAllSchools();
        SchoolModel? GetSchoolById(int id);
        SchoolModel? Create(SchoolModel school);
        SchoolModel? UpdateSchoolById(int id, SchoolModel school);
        bool? RemoveSchoolById(int id);
    }
}
