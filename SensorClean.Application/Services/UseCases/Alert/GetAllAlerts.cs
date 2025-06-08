using SensorClean.Application.Interface.Repositories;
using SensorClean.Domain.Models;

namespace SensorClean.Application.Services.UseCases.Alert
{
    public class GetAllAlerts
    {
        private readonly IAlertRepository _alertRepository;
        public GetAllAlerts(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }
        public IEnumerable<AlertModel> Execute()
        {
            return _alertRepository.GetAll();
        }
    }
}
