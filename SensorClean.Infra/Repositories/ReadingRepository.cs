using SensorClean.Domain.Models;
using SensorClean.Application.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SensorClean.Infra.Repositories
{
    public class ReadingRepository : IReadingRepository
    {
        private static readonly List<ReadingModel> _readings = new();
        private static int _nextId = 1;

        public ReadingModel Create(ReadingModel reading)
        {
            var readingToAdd = reading with { Id = _nextId++ };
            _readings.Add(readingToAdd);
            return readingToAdd;
        }

        public IEnumerable<ReadingModel> GetAll() => _readings;

        public ReadingModel? GetById(int id) => _readings.FirstOrDefault(r => r.Id == id);

        public ReadingModel? Update(int id, ReadingModel reading)
        {
            var index = _readings.FindIndex(r => r.Id == id);
            if (index == -1) return null;

            var updatedReading = reading with { Id = id };
            _readings[index] = updatedReading;
            return updatedReading;
        }

        public bool Remove(int id)
        {
            var reading = _readings.FirstOrDefault(r => r.Id == id);
            return reading != null && _readings.Remove(reading);
        }
    }
}
