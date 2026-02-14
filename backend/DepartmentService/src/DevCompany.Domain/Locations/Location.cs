using DepartmentService.Domain.Locations.VO;
using DepartmentService.Domain.Shared.VO;

namespace DepartmentService.Domain.Locations;

public class Location
{
    public LocationId Id { get; private set; } = null!;
    public LocationName Name { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public Timezone TimeZone { get; private set; } = null!;
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public Location(
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
}