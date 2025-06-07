using SensorClean.Application.Interface.School;
using SensorClean.Domain.Models;


namespace SensorClean.Application.Services.UseCases.School
{
    public class GetSchoolById : IGetSchoolById
    {
        private readonly List<SchoolModel> _schools = new();

        public SchoolModel? getSchoolByID(int id) => _schools.FirstOrDefault(e => e.Id == id);

       

    }
}
