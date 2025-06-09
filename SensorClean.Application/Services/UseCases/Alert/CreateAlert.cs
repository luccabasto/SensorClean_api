using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;
using SensorClean.Application.Interface.Alert;
using SensorClean.Application.Interface.Repositories;
using SensorClean.Domain.Models;
using Microsoft.ML;

namespace SensorClean.Application.Services.UseCases.Alert
{
    public class CreateAlert : ICreateAlert
    {
        private readonly IAlertRepository _alertRepository;

        public CreateAlert(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        public AlertModel Create(AlertModel alertModel)
        {
            var mlContext = new MLContext();
            float temperatura = 0;
            if (alertModel is not null && alertModel.Mensager != null)
            {
                float.TryParse(alertModel.Mensager.Replace("°C", "").Trim(), out temperatura);
            }
            float risco = temperatura > 35 ? 0.9f : 0.1f;

            var updatedAlertModel = new AlertModel
            {
                Id = alertModel.Id,
                ReadingId = alertModel.ReadingId,
                Type = alertModel.Type,
                Mensager = $"{alertModel.Mensager} | Risco previsto: {risco * 100}%",
                Level = alertModel.Level,
                Status = alertModel.Status,
                Timestamp = alertModel.Timestamp,
                Reading = alertModel.Reading
            };

            var alertaCriado = _alertRepository.Create(updatedAlertModel);

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnectionAsync().Result)
            using (var channel = connection.CreateChannelAsync().Result)
            {
                channel.QueueDeclareAsync(queue: "alertas", durable: false, exclusive: false, autoDelete: false, arguments: null);

                string message = JsonConvert.SerializeObject(alertaCriado);
                var body = Encoding.UTF8.GetBytes(message);

                var basicProperties = new BasicProperties
                {
                    Persistent = false
                };

                channel.BasicPublishAsync(
                    exchange: "",
                    routingKey: "alertas",
                    mandatory: false,
                    basicProperties: basicProperties,
                    body: body
                );
            }

            return alertaCriado;
        }
    }
}
