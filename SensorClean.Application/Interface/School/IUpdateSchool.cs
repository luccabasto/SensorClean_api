using SensorClean.Domain.Models;


namespace SensorClean.Application.Interface.School
{
    public interface IUpdateSchool
    {
        SchoolModel? updateSchoolByID(int id, SchoolModel school);
    }
}
