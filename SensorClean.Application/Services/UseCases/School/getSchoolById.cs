using SensorClean.Application.Interface.Repositories;
using SensorClean.Application.Interface.School;
using SensorClean.Domain.Models;


namespace SensorClean.Application.Services.UseCases.School
{
    public class GetSchoolById : IGetSchoolById
    {
        
        /// <summary>
        /// Simula a busca de uma escola pelo ID.
        /// </summary>
        private readonly ISchoolRepository _schoolRepository;
        public GetSchoolById(ISchoolRepository schoolRepository)
        {
            this._schoolRepository = schoolRepository;
        }
        public SchoolModel? Execute(int id) => _schoolRepository.GetById(id);

        public SchoolModel? getSchoolByID(int id)
        {
            return _schoolRepository.GetById(id);
        }
    }
}
