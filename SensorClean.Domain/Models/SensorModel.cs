
namespace SensorClean.Domain.Models
{
    public record  SensorModel
    {
        public int Id { get; init; }
        public int IdSchool { get; init; }
        public string Localization { get; init; } // Ex: "Sala 4"
        public bool IsActive { get; init; }
        public string TypeSensor { get; init; }  // Ex: "temperatura", "umidade"
        public string? Description { get; init; }
    }
}
