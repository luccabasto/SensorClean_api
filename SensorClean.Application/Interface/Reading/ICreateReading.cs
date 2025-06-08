using SensorClean.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorClean.Application.Interface.Reading
{
    public interface ICreateReading
    {
        ReadingModel Create(ReadingModel readingModel);
    }
}
