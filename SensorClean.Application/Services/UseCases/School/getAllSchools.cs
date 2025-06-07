using SensorClean.Domain.Models;


namespace SensorClean.Application.Services.UseCases.School
{
    public class gettAllSchools
    {
        private readonly List<SchoolModel> _schools = new();

        public List<SchoolModel> ListAllSchools() => _schools;

    }
}
