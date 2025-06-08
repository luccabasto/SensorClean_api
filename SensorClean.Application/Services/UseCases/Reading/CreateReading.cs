using SensorClean.Application.Interface.Reading;
using SensorClean.Application.Interface.Repositories;
using SensorClean.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorClean.Application.Services.UseCases.Reading
{
    public class CreateReading : ICreateReading
    {

        private readonly IReadingRepository _readingRepository;

        private CreateReading(IReadingRepository readingRepository)
        {
            _readingRepository = readingRepository;
        }

        public ReadingModel Create(ReadingModel readingModel)
        {
            return _readingRepository.Create(readingModel);
        }
    }
}
