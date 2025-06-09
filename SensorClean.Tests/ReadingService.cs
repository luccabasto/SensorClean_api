using Xunit;
using Moq;
using SensorClean.Application.Services.UseCases.Reading;
using SensorClean.Domain.Models;
using SensorClean.Application.Interface.Repositories;
using System.Collections.Generic;
using System;

public class ReadingServiceTests
{
    [Fact]
    public void GetAllReadings_ReturnsList()
    {
        var mockRepo = new Mock<IReadingRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(new List<ReadingModel>
        {
            new ReadingModel { Id = 1, IdSensor = 1, Temperature = 35.1m, Humidity = 80m, Timestamp = DateTime.Now }
        });
        var useCase = new GetAllReadings(mockRepo.Object);

        var result = useCase.Execute();

        Assert.Single(result);
    }

    [Fact]
    public void CreateReading_ReturnsCreatedReading()
    {
        var reading = new ReadingModel { IdSensor = 1, Temperature = 34.0m, Humidity = 78m, Timestamp = DateTime.Now };
        var mockRepo = new Mock<IReadingRepository>();
        mockRepo.Setup(r => r.Create(It.IsAny<ReadingModel>())).Returns(reading);

        var useCase = new CreateReading(mockRepo.Object);
        var created = useCase.Create(reading);

        Assert.Equal(34.0m, created.Temperature);
    }
}
