using SensorClean.Domain.Models;
using SensorClean.Application.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SensorClean.Infra.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private static readonly List<SensorModel> _sensors = new();
        private static int _nextId = 1;

        public SensorModel Create(SensorModel sensor)
        {
            var sensorToAdd = sensor with { Id = _nextId++ };
            _sensors.Add(sensorToAdd);
            return sensorToAdd;
        }

        public IEnumerable<SensorModel> GetAll() => _sensors;

        public SensorModel? GetById(int id) => _sensors.FirstOrDefault(s => s.Id == id);

        public SensorModel? Update(int id, SensorModel sensor)
        {
            var index = _sensors.FindIndex(s => s.Id == id);
            if (index == -1) return null;

            var updatedSensor = sensor with { Id = id };
            _sensors[index] = updatedSensor;
            return updatedSensor;
        }

        public bool Remove(int id)
        {
            var sensor = _sensors.FirstOrDefault(s => s.Id == id);
            return sensor != null && _sensors.Remove(sensor);
        }
    }
}
