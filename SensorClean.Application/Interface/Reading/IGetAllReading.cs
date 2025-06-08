using SensorClean.Domain.Models;

namespace SensorClean.Application.Interface.Reading
{
    public interface IGetAllReading
    {
        IEnumerable<ReadingModel> Execute();
    }
}
