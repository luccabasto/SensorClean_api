using SensorClean.Domain.Models;


namespace SensorClean.Application.Interface.Repositories
{
    public interface ISchoolRepository
    {
        SchoolModel Create(SchoolModel school);
        SchoolModel? GetById(int id);
        IEnumerable<SchoolModel> GetAll();
        bool Remove(int id);
        SchoolModel? Update(int id, SchoolModel school);
    }
}
