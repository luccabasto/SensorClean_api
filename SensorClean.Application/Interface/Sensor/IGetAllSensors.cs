using SensorClean.Domain.Models;

namespace SensorClean.Application.Interface.Sensor
{
    public interface IGetAllSensors
    {
        IEnumerable<SensorModel> Execute();

    }
}
