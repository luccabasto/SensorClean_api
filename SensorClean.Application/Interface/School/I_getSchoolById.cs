using SensorClean.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorClean.Application.Interface.School
{
    public interface ISchoolService
    {
        IEnumerable<SchoolModel> GetAll();
        SchoolModel? GetById(int id);
        SchoolModel Create(SchoolModel school);
        SchoolModel? Update(int id, SchoolModel school);
        bool Delete(int id);
    }
}
