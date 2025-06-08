namespace SensorClean.Domain
{
    public record SensorClean
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool IsActive { get; set; }

    public SensorClean(int id, string name, string city, string state, bool isActive)
        {
            Id = id;
            Name = name;
            City = city;
            State = state;
            IsActive = isActive;
        }

    public SensorClean(int id, string name, bool isActive)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
        }
    }
} 
