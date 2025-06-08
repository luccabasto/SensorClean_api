using SensorClean.Domain.Models;


namespace SensorClean.Application.Interface.School
{
    public interface IUpdateSchool
    {
        SchoolModel? UpdateSchoolByID(int id, SchoolModel school);
    }
}
