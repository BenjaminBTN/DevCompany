using CSharpFunctionalExtensions;
using DevCompany.Domain.Departments.VO;

namespace DevCompany.Domain.Departments;

public class DepartmentPosition
{
    public DepartmentPositionId Id { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Guid PositionId { get; private set; }

    private DepartmentPosition(DepartmentPositionId id, Guid departmentId, Guid positionId)
    {
        Id = id;
        DepartmentId = departmentId;
        PositionId = positionId;
    }

    public static Result<DepartmentPosition> Create(Guid departmentId, Guid positionId)
    {
        if(departmentId == Guid.Empty)
            return Result.Failure<DepartmentPosition>(nameof(DepartmentId) + " cannot be empty");

        if(positionId == Guid.Empty)
            return Result.Failure<DepartmentPosition>(nameof(PositionId) + " cannot be empty");

        var id = DepartmentPositionId.New();

        return new DepartmentPosition(id, departmentId, positionId);
    }
}