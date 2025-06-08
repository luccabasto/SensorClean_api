using SensorClean.Application.Interface.Alert;
using SensorClean.Application.Interface.Repositories;
using SensorClean.Domain.Models;


namespace SensorClean.Application.Services.UseCases.Alert
{
    public class CreateAlert : ICreateAlert
    {
        private readonly IAlertRepository _alertRepository;
        public CreateAlert(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }
        public AlertModel Create(AlertModel alertModel)
        {
            return _alertRepository.Create(alertModel);
        }
    }
}
