using SensorClean.Application.Interface.Repositories;
using SensorClean.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorClean.Infra.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly List<SchoolModel> _schools = new();
        private int _idCounter = 1;

        public SchoolModel Create(SchoolModel school)
        {
            var newSchool = new SchoolModel(
                id: _idCounter++,
                name: school.Name,
                email: school.Email,
                createdAt: DateTime.UtcNow,
                isActive: true
            );
            _schools.Add(newSchool);
            return newSchool;
        }
        public SchoolModel? GetById(int id)
        {
            return _schools.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<SchoolModel> GetAll()
        {
            return _schools;
        }

        public bool Remove(int id)
        {
            var school = GetById(id);
            if (school == null) return false;
            _schools.Remove(school);
            return true;
        }

        public SchoolModel? Update(int id, SchoolModel school)
        {
            var existingSchool = GetById(id);
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
            return existingSchool;
        }
    }
}
