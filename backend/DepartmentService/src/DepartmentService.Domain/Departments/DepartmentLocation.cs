using CSharpFunctionalExtensions;
using DepartmentService.Domain.Departments.VO;
using DepartmentService.Domain.Locations.VO;
using DepartmentService.Shared;

namespace DepartmentService.Domain.Departments;

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

    public static Result<DepartmentLocation, Errors> Create(DepartmentId departmentId, Guid locationId)
    {
        if (locationId == Guid.Empty)
           return GeneralErrors.CannotBeEmpty(nameof(LocationId)).ToErrors();

        var id = DepartmentLocationId.New();

        return new DepartmentLocation(id, departmentId, locationId);    
    }
}
