using SensorClean.Domain.Models;
using SensorClean.Application.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SensorClean.Infra.Repositories
{
    public class AlertRepository : IAlertRepository
    {
        private readonly SensorCleanDbContext _context;

        public AlertRepository(SensorCleanDbContext context)
        {
            _context = context;
        }

        public AlertModel Create(AlertModel alert)
        {
            _context.Alertas.Add(alert);
            _context.SaveChanges();
            return alert;
        }

        public IEnumerable<AlertModel> GetAll()
        {
            return _context.Alertas.ToList();
        }

        public AlertModel? GetById(int id)
        {
            return _context.Alertas.Find(id);
        }

        public AlertModel? Update(int id, AlertModel alert)
        {
            var existingAlert = _context.Alertas.Find(id);
            if (existingAlert == null) return null;

            var updatedAlert = new AlertModel
            {
                Id = existingAlert.Id,
                ReadingId = alert.ReadingId,
                Type = alert.Type,
                Mensager = alert.Mensager,
                Level = alert.Level,
                Status = alert.Status,
                Timestamp = alert.Timestamp,
                Reading = alert.Reading
            };

            _context.Entry(existingAlert).CurrentValues.SetValues(updatedAlert);
            _context.SaveChanges();
            return updatedAlert;
        }

        public bool Remove(int id)
        {
            var alert = _context.Alertas.Find(id);
            if (alert == null) return false;

            _context.Alertas.Remove(alert);
            _context.SaveChanges();
            return true;
        }
    }
}
