using CSharpFunctionalExtensions;
using DepartmentService.Domain.Departments.VO;
using DepartmentService.Domain.Positions.VO;
using DepartmentService.Shared;

namespace DepartmentService.Domain.Departments;

public class DepartmentPosition
{
    public DepartmentPositionId Id { get; private set; } = null!;
    public DepartmentId DepartmentId { get; private set; } = null!;
    public PositionId PositionId { get; private set; } = null!;

    private DepartmentPosition(DepartmentPositionId id, DepartmentId departmentId, Guid positionId)
    {
        Id = id;
        DepartmentId = departmentId;
        PositionId = PositionId.Create(positionId);
    }

    // ef core
    private DepartmentPosition()
    {
    }

    public static Result<DepartmentPosition, Errors> Create(DepartmentId departmentId, Guid positionId)
    {
        if (positionId == Guid.Empty)
            return GeneralErrors.CannotBeEmpty(nameof(PositionId)).ToErrors();

        var id = DepartmentPositionId.New();

        return new DepartmentPosition(id, departmentId, positionId);
    }
}
