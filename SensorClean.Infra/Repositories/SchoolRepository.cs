using SensorClean.Application.Interface.Repositories;
using SensorClean.Domain.Models;


namespace SensorClean.Infra.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SensorCleanDbContext _context;

        public SchoolRepository(SensorCleanDbContext context)
        {
            _context = context;
        }

        public SchoolModel Create(SchoolModel school)
        {
            _context.Escolas.Add(school);
            _context.SaveChanges();
            return school;
        }

        public SchoolModel? GetById(int id)
        {
            return _context.Escolas.Find(id);
        }

        public IEnumerable<SchoolModel> GetAll()
        {
            return _context.Escolas.ToList();
        }

        public bool Remove(int id)
        {
            var school = _context.Escolas.Find(id);
            if (school == null) return false;
            _context.Escolas.Remove(school);
            _context.SaveChanges();
            return true;
        }

        public SchoolModel? Update(int id, SchoolModel school)
        {
            var existingSchool = _context.Escolas.Find(id);
            if (existingSchool == null) return null;

            existingSchool.Name = school.Name;
            existingSchool.Email = school.Email;
            existingSchool.City = school.City;
            existingSchool.State = school.State;
            existingSchool.Country = school.Country;
            existingSchool.Address = school.Address;
            existingSchool.PostalCode = school.PostalCode;
            existingSchool.Phone = school.Phone;
            existingSchool.Website = school.Website;
            existingSchool.IsActive = school.IsActive;

            _context.SaveChanges();
            return existingSchool;
        }
    }
}
