using CSharpFunctionalExtensions;

namespace DevCompany.Domain.Departments;

public class DepartmentLocation
{
    public Guid DepartmentId { get; private set; }
    public Guid LocationId { get; private set; }

    private DepartmentLocation(Guid departmentId, Guid locationId)
    {
        DepartmentId = departmentId;
        LocationId = locationId;
    }

    public static Result<DepartmentLocation> Create(Guid departmentId, Guid locationId)
    {
        if(locationId == Guid.Empty)
            return Result.Failure<DepartmentLocation>(nameof(LocationId) + " cannot be empty");

        return new DepartmentLocation(departmentId, locationId);    
    }
}