namespace SensorClean.Domain.Models
{
    public record AlertModel
    {

        public int Id { get; init; }
        public int ReadingId { get; init; }        // Chave estrangeira para Leitura
        public string Type { get; init; }          // Ex: "Calor Extremo"
        public string Mensager { get; init; }      // Texto explicativo
        public string Level { get; init; }         // Ex: "Alto", "Crítico"
        public string Status { get; init; }        // Ex: "Emitido", "Visualizado", "Resolvido"
        public DateTime Timestamp { get; init; }
        public ReadingModel Reading { get; init; } // Navegação para a Leitura
    }

}
