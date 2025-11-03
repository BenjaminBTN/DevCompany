using CSharpFunctionalExtensions;
using DevCompany.Domain.Locations.VO;
using DevCompany.Domain.Shared.VO;

namespace DevCompany.Domain.Locations;

public class Location
{
    private Location(
        Guid id, 
        LocationName name, 
        Address address, 
        Timezone timeZone, 
        bool isActive, 
        DateTime createdAt, 
        DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Address = address;
        TimeZone = timeZone;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Guid Id { get; private set; }
    public LocationName Name { get; private set; }
    public Address Address { get; private set; }
    public Timezone TimeZone { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static Result<Location> Create(LocationName name, Address address, Timezone timezone, bool isActive)
    {
        var id = Guid.NewGuid();
        DateTime createdAt = DateTime.UtcNow;
        DateTime updatedAt = createdAt;

        return new Location(id, name, address, timezone, isActive, createdAt, updatedAt);
    }
}