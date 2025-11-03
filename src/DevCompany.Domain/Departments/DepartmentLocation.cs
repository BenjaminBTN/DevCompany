using CSharpFunctionalExtensions;
using DevCompany.Domain.Departments.VO;

namespace DevCompany.Domain.Departments;

public class DepartmentLocation
{
    public DepartmentLocationId Id { get; set; } = null!;
    public Guid DepartmentId { get; private set; }
    public Guid LocationId { get; private set; }

    private DepartmentLocation(DepartmentLocationId id, Guid departmentId, Guid locationId)
    {
        Id = id;
        DepartmentId = departmentId;
        LocationId = locationId;
    }

    // ef core
    private DepartmentLocation()
    {
    }

    public static Result<DepartmentLocation> Create(Guid departmentId, Guid locationId)
    {
        if (departmentId == Guid.Empty)
            return Result.Failure<DepartmentLocation>(nameof(DepartmentId) + " cannot be empty");

        if (locationId == Guid.Empty)
            return Result.Failure<DepartmentLocation>(nameof(LocationId) + " cannot be empty");

        var id = DepartmentLocationId.New();

        return new DepartmentLocation(id, departmentId, locationId);    
    }
}