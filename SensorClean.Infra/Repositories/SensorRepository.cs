using SensorClean.Domain.Models;
using SensorClean.Application.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SensorClean.Infra.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly SensorCleanDbContext _context;

        public SensorRepository(SensorCleanDbContext context)
        {
            _context = context;
        }

        public SensorModel Create(SensorModel sensor)
        {
            _context.Sensores.Add(sensor);
            _context.SaveChanges();
            return sensor;
        }

        public IEnumerable<SensorModel> GetAll()
        {
            return _context.Sensores.ToList();
        }

        public SensorModel? GetById(int id)
        {
            return _context.Sensores.Find(id);
        }

        public SensorModel? Update(int id, SensorModel sensor)
        {
            var existingSensor = _context.Sensores.Find(id);
            if (existingSensor == null) return null;

            var updatedSensor = new SensorModel
            {
                Id = existingSensor.Id,
                IdSchool = sensor.IdSchool,
                Localization = sensor.Localization,
                IsActive = sensor.IsActive,
                TypeSensor = sensor.TypeSensor,
                Description = sensor.Description,
                School = existingSensor.School,
                Reading = existingSensor.Reading
            };

            _context.Entry(existingSensor).CurrentValues.SetValues(updatedSensor);
            _context.SaveChanges();
            return updatedSensor;
        }

        public bool Remove(int id)
        {
            var sensor = _context.Sensores.Find(id);
            if (sensor == null) return false;

            _context.Sensores.Remove(sensor);
            _context.SaveChanges();
            return true;
        }
    }
}
