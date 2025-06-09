using Xunit;
using Moq;
using SensorClean.Application.Services.UseCases.Sensor;
using SensorClean.Domain.Models;
using SensorClean.Application.Interface.Repositories;
using System.Collections.Generic;

public class SensorServiceTests
{
    [Fact]
    public void GetAllSensors_ReturnsList()
    {
        var mockRepo = new Mock<ISensorRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(new List<SensorModel>
        {
            new SensorModel { Id = 1, IdSchool = 1, TypeSensor = "temperatura", Localization = "Sala 1", IsActive = "S" }
        });
        var useCase = new GetAllSensors(mockRepo.Object);

        var result = useCase.Execute();

        Assert.Single(result);
    }

    [Fact]
    public void CreateSensor_ReturnsCreatedSensor()
    {
        var sensor = new SensorModel { IdSchool = 1, TypeSensor = "temperatura", Localization = "Sala 2", IsActive = "S" };
        var mockRepo = new Mock<ISensorRepository>();
        mockRepo.Setup(r => r.Create(It.IsAny<SensorModel>())).Returns(sensor);

        var useCase = new CreateSensor(mockRepo.Object);
        var created = useCase.Create(sensor);

        Assert.Equal("Sala 2", created.Localization);
    }
}
