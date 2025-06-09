using System.ComponentModel.DataAnnotations.Schema;

namespace SensorClean.Domain.Models
{
    public record SchoolModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        [NotMapped]
        public string? Country { get; set; }

        [NotMapped]
        public string? Address { get; set; }

        [NotMapped]
        public string? PostalCode { get; set; }

        [NotMapped]
        public string? Phone { get; set; }
        [NotMapped]
        public string? Website { get; set; }
        [NotMapped]
        public DateTime CreatedAt { get; set; }

        public string IsActive { get; set; }

        public ICollection<SensorModel>? Sensor { get; set; }

        public SchoolModel() { }
        public SchoolModel(string name, string email, int id, string isActive)
        {
            Id = id; 
            Name = name;
            Email = email;
            CreatedAt = DateTime.UtcNow;
            IsActive = isActive;
        }
        public SchoolModel(int id, string name, string email, string? city, string? state, string? country, string? address, string? postalCode, string? phone, string? website, DateTime createdAt, string isActive)
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

        public SchoolModel(int id, string name, string email, string city, string state, string isActive)
        {
            Id = id;
            Name = name;
            City = city;
            State = state;
            IsActive = isActive;
        }

        public SchoolModel(int id, string name, string email, DateTime createdAt, string isActive, string? city, string? state)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = createdAt;
            IsActive = isActive;
            State = state;
        }

        public SchoolModel(int? id, string name, string email, DateTime createdAt, string isActive, string? city, string? state, string? country, string? address, string? postalCode, string? phone, string? website)
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

    }
}
