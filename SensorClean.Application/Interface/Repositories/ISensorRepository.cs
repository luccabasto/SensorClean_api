using SensorClean.Domain.Models;
using System.Collections.Generic;

namespace SensorClean.Application.Interface.Repositories
{
    public interface ISensorRepository
    {
        SensorModel Create(SensorModel sensor);
        IEnumerable<SensorModel> GetAll();
        SensorModel? GetById(int id);
        SensorModel? Update(int id, SensorModel sensor);
        bool Remove(int id);
    }
}
