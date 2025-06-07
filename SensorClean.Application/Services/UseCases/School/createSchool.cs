using SensorClean.Domain.Models;

namespace SensorClean.Application.Services.UseCases.School
{
    public class createSchool
    {
        private readonly List<SchoolModel> _schools = new();
        public SchoolModel Create(SchoolModel school)
        {
            var createdSchool = new SchoolModel(
                 id: _schools.Count + 1,
                 name: school.Name,
                 email: school.Email,
                 createdAt: DateTime.UtcNow,
                 isActive: true
               );

            _schools.Add(createdSchool);
            return createdSchool;
        }
        public List<SchoolModel> List() => _schools;

    }
}
