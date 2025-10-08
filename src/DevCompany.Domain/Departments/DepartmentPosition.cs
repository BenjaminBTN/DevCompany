using CSharpFunctionalExtensions;

namespace DevCompany.Domain.Departments;

public class DepartmentPosition
{
    public Guid DepartmentId { get; private set; }
    public Guid PositionId { get; private set; }

    private DepartmentPosition(Guid departmentId, Guid positionId)
    {
        DepartmentId = departmentId;
        PositionId = positionId;
    }

    public static Result<DepartmentPosition> Create(Guid departmentId, Guid positionId)
    {
        if(departmentId == Guid.Empty)
            return Result.Failure<DepartmentPosition>(nameof(DepartmentId) + " cannot be empty");

        if(positionId == Guid.Empty)
            return Result.Failure<DepartmentPosition>(nameof(PositionId) + " cannot be empty");

        return new DepartmentPosition(departmentId, positionId);
    }
}