using SensorClean.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorClean.Application.Interface.School
{
    public interface ICreateSchool
    {
        SchoolModel Create(SchoolModel school);
    }
}
