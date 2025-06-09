
namespace SensorClean.Domain.Models
{
    public record ReadingModel
    {
        public int Id { get; init; }
        public int IdSensor { get; init; }         // Chave estrangeira para Sensor
        public decimal Temperature { get; init; }  // Valor em Celsius
        public decimal Humidity { get; init; }      // Valor em porcentagem
        public DateTime Timestamp { get; init; }
        public SensorModel Sensor { get; init; }   // Navegação para o Sensor

        public ICollection<AlertModel> Alerts { get; init; }
    }
}
