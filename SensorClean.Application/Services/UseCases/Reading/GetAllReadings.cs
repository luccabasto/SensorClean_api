using SensorClean.Application.Interface.Reading;
using SensorClean.Application.Interface.Repositories;
using SensorClean.Domain.Models;


namespace SensorClean.Application.Services.UseCases.Reading
{
    public class GetAllReadings : IGetAllReading
    {
        private readonly IReadingRepository _readingRepository;

        public GetAllReadings(IReadingRepository readingRepository)
        {
            _readingRepository = readingRepository;
        }

        public IEnumerable<ReadingModel> Execute() => _readingRepository.GetAll();
    }
}
