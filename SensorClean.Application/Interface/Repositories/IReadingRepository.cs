using SensorClean.Domain.Models;

namespace SensorClean.Application.Interface.Repositories
{
    public interface IReadingRepository
    {
        ReadingModel Create(ReadingModel reading);
        IEnumerable<ReadingModel> GetAll();
        ReadingModel? GetById(int id);
        ReadingModel? Update(int id, ReadingModel reading);
        bool Remove(int id);
    }
}
