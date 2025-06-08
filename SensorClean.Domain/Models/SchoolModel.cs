namespace SensorClean.Domain.Models
{
    public record SchoolModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

<<<<<<< Updated upstream
=======
        public ICollection<SensorModel>? Sensor { get; set; }

>>>>>>> Stashed changes
        public SchoolModel() { }
        public SchoolModel(string name, string email, int id)
        {
            Id = id; 
            Name = name;
            Email = email;
            CreatedAt = DateTime.UtcNow;
            IsActive = false;
        }
        public SchoolModel(int id, string name, string email, string? city, string? state, string? country, string? address, string? postalCode, string? phone, string? website, DateTime createdAt, bool isActive)
        {
            Id = id;
            Name = name;
            Email = email;
            City = city;
            State = state;
            Country = country;
            Address = address;
            PostalCode = postalCode;
            Phone = phone;
            Website = website;
            CreatedAt = createdAt;
            IsActive = isActive;
        }

        public SchoolModel(int id, string name, string email, string city, string state)
        {
            Id = id;
            Name = name;
            City = city;
            State = state;
            IsActive = true;
        }

        public SchoolModel(int id, string name, string email, DateTime createdAt, bool isActive, string? city, string? state)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = createdAt;
            IsActive = isActive;
            State = state;
        }

        public SchoolModel(int? id, string name, string email, DateTime createdAt, bool isActive, string? city, string? state, string? country, string? address, string? postalCode, string? phone, string? website)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = createdAt;
            IsActive = isActive;
            City = city;
            State = state;
            Country = country;
            Address = address;
            PostalCode = postalCode;
            Phone = phone;
            Website = website;
        }

        public void Activate()
        {
            IsActive = true;
        }

    }
}
