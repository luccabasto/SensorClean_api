using SensorClean.Domain.Models;
using SensorClean.Application.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SensorClean.Infra.Repositories
{
    public class AlertRepository : IAlertRepository
    {
        private static readonly List<AlertModel> _alerts = new();
        private static int _nextId = 1;

        public AlertModel Create(AlertModel alert)
        {
            var alertToAdd = alert with { Id = _nextId++ };
            _alerts.Add(alertToAdd);
            return alertToAdd;
        }

        public IEnumerable<AlertModel> GetAll() => _alerts;

        public AlertModel? GetById(int id) => _alerts.FirstOrDefault(a => a.Id == id);

        public AlertModel? Update(int id, AlertModel alert)
        {
            var index = _alerts.FindIndex(a => a.Id == id);
            if (index == -1) return null;

            var updatedAlert = alert with { Id = id };
            _alerts[index] = updatedAlert;
            return updatedAlert;
        }

        public bool Remove(int id)
        {
            var alert = _alerts.FirstOrDefault(a => a.Id == id);
            return alert != null && _alerts.Remove(alert);
        }
    }
}
