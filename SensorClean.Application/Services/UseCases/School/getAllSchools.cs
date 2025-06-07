using SensorClean.Application.Interface.School;
using SensorClean.Domain.Models;

namespace SensorClean.Application.Services.UseCases.School
{
    public class GetAllSchools : IGetAllSchools
    {
        private readonly List<SchoolModel> _schools = new();

        public List<SchoolModel> ListAllSchools() => _schools;

        IEnumerable<SchoolModel> IGetAllSchools.ListAllSchools()
        {
            return ListAllSchools();
        }
    }
}
