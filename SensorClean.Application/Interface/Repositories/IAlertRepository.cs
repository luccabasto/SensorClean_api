using SensorClean.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorClean.Application.Interface.Repositories
{
    public interface IAlertRepository
    {
        AlertModel Create(AlertModel alert);
        IEnumerable<AlertModel> GetAll();
        AlertModel? GetById(int id);
        AlertModel? Update(int id, AlertModel alert);
        bool Remove(int id);
    }
}
