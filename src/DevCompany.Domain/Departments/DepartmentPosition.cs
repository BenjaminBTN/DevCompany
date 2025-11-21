using CSharpFunctionalExtensions;
using DevCompany.Domain.Departments.VO;
using DevCompany.Domain.Positions.VO;
using DevCompany.Shared;

namespace DevCompany.Domain.Departments;

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

    public static Result<DepartmentPosition, Error> Create(DepartmentId departmentId, Guid positionId)
    {
        if (positionId == Guid.Empty)
            return GeneralErrors.CannotBeEmpty(nameof(PositionId));

        var id = DepartmentPositionId.New();

        return new DepartmentPosition(id, departmentId, positionId);
    }
}
