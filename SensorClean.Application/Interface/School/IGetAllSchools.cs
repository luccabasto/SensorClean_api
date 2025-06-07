using SensorClean.Domain.Models;


namespace SensorClean.Application.Interface.School
{
    public interface IGetAllSchools
    {
        IEnumerable<SchoolModel> ListAllSchools();
    }
}
