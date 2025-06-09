using SensorClean.Domain.Models;
using SensorClean.Application.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SensorClean.Infra.Repositories
{
    public class ReadingRepository : IReadingRepository
    {
        private readonly SensorCleanDbContext _context;

        public ReadingRepository(SensorCleanDbContext context)
        {
            _context = context;
        }

        public ReadingModel Create(ReadingModel reading)
        {
            _context.Leituras.Add(reading);
            _context.SaveChanges();
            return reading;
        }

        public IEnumerable<ReadingModel> GetAll()
        {
            return _context.Leituras.ToList();
        }

        public ReadingModel? GetById(int id)
        {
            return _context.Leituras.Find(id);
        }

        public ReadingModel? Update(int id, ReadingModel reading)
        {
            var existingReading = _context.Leituras.Find(id);
            if (existingReading == null) return null;

            var updatedReading = new ReadingModel
            {
                Id = existingReading.Id,
                IdSensor = reading.IdSensor,
                Temperature = reading.Temperature,
                Humidity = reading.Humidity,
                Timestamp = reading.Timestamp,
                Sensor = reading.Sensor,
                Alerts = reading.Alerts
            };

            _context.Entry(existingReading).CurrentValues.SetValues(updatedReading);
            _context.SaveChanges();
            return updatedReading;
        }

        public bool Remove(int id)
        {
            var reading = _context.Leituras.Find(id);
            if (reading == null) return false;

            _context.Leituras.Remove(reading);
            _context.SaveChanges();
            return true;
        }
    }
}
