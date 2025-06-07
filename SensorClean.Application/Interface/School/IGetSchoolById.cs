using SensorClean.Domain.Models;

namespace SensorClean.Application.Interface.School
{
    public interface IGetSchoolById
    {
        SchoolModel? getSchoolByID(int id);
    }
}
