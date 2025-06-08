using SensorClean.Application.Interface.Repositories;
using SensorClean.Application.Interface.Sensor;
using SensorClean.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorClean.Application.Services.UseCases.Sensor
{
    public class GetAllSensors : IGetAllSensors
    {
        private readonly ISensorRepository _sensorRepository;

        public GetAllSensors(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        public IEnumerable<SensorModel> Execute() => _sensorRepository.GetAll();
    }
}
