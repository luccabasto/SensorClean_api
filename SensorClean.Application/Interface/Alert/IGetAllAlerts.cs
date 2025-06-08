using SensorClean.Domain.Models;


namespace SensorClean.Application.Interface.Alert
{
    public interface IGetAllAlerts
    {
        IEnumerable<AlertModel> Execute();
    }
}
