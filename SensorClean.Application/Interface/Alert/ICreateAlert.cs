using SensorClean.Domain.Models;


namespace SensorClean.Application.Interface.Alert
{
    public interface ICreateAlert
    {
        AlertModel Create(AlertModel alertModel);
    }
}
