using CSharpFunctionalExtensions;
using DevCompany.Domain.Departments.VO;
using DevCompany.Domain.Locations.VO;

namespace DevCompany.Domain.Departments;

public class DepartmentLocation
{
    public DepartmentLocationId Id { get; set; } = null!;
    public DepartmentId DepartmentId { get; private set; } = null!;
    public LocationId LocationId { get; private set; } = null!;

    private DepartmentLocation(DepartmentLocationId id, DepartmentId departmentId, Guid locationId)
    {
        Id = id;
        DepartmentId = departmentId;
        LocationId = LocationId.Create(locationId);
    }

    // ef core
    private DepartmentLocation()
    {
    }

    public static Result<DepartmentLocation> Create(DepartmentId departmentId, Guid locationId)
    {
        if (locationId == Guid.Empty)
            return Result.Failure<DepartmentLocation>(nameof(LocationId) + " cannot be empty");

        var id = DepartmentLocationId.New();

        return new DepartmentLocation(id, departmentId, locationId);    
    }
}