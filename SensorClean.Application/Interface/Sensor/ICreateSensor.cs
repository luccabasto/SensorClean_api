using SensorClean.Domain.Models;

namespace SensorClean.Application.Interface.Sensor
{
    public interface ICreateSensor
    {
        SensorModel Create(SensorModel sensorModel);
    }
}
