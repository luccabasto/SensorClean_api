using Xunit;
using Moq;
using SensorClean.Application.Services.UseCases.School;
using SensorClean.Domain.Models;
using SensorClean.Application.Interface.Repositories;
using System.Collections.Generic;

public class SchoolServiceTests
{
    [Fact]
    public void GetAllSchools_ReturnsList()
    {
        var mockRepo = new Mock<ISchoolRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(new List<SchoolModel>
        {
            new SchoolModel { Id = 1, Name = "Teste", City = "SP", State = "SP", IsActive = "S" }
        });
        var useCase = new GetAllSchools(mockRepo.Object);

        var result = useCase.Execute();

        Assert.Single(result);
    }

    [Fact]
    public void CreateSchool_ReturnsCreatedSchool()
    {
        var school = new SchoolModel { Name = "Nova", City = "SP", State = "SP", IsActive = "S" };
        var mockRepo = new Mock<ISchoolRepository>();
        mockRepo.Setup(r => r.Create(It.IsAny<SchoolModel>())).Returns(school);

        var useCase = new CreateSchool(mockRepo.Object);
        var created = useCase.Create(school);

        Assert.Equal("Nova", created.Name);
    }

    [Fact]
    public void UpdateSchool_ReturnsUpdatedSchool()
    {
        var school = new SchoolModel { Id = 1, Name = "Nova", City = "SP", State = "SP", IsActive = "S" };
        var mockRepo = new Mock<ISchoolRepository>();
        mockRepo.Setup(r => r.Update(1, school)).Returns(school);

        var useCase = new UpdateSchool(mockRepo.Object);
        var updated = useCase.updateSchoolByID(1, school);

        Assert.Equal(1, updated.Id);
    }
}
