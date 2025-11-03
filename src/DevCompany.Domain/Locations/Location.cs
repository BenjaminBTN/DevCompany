using CSharpFunctionalExtensions;
using DevCompany.Domain.Locations.VO;
using DevCompany.Domain.Shared.VO;

namespace DevCompany.Domain.Locations;

public class Location
{
    public LocationId Id { get; private set; } = null!;
    public LocationName Name { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public Timezone TimeZone { get; private set; } = null!;
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Location(
        LocationId id, 
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

    // ef core
    private Location()
    {
    }

    public static Result<Location> Create(LocationName name, Address address, Timezone timezone, bool isActive)
    {
        var id = LocationId.New();
        DateTime createdAt = DateTime.UtcNow;
        DateTime updatedAt = createdAt;

        return new Location(id, name, address, timezone, isActive, createdAt, updatedAt);
    }
}