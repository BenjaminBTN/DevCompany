using CSharpFunctionalExtensions;
using DepartmentService.Domain.Positions.VO;
using DepartmentService.Domain.Shared.Constants;
using DepartmentService.Shared;

namespace DepartmentService.Domain.Positions;

public class Position
{
    public PositionId Id { get; private set; } = null!;
    public PositionName Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Position(
        PositionId id,
        PositionName name,
        string? description,
        bool isActive,
        DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Description = description;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    // ef core
    private Position()
    {
    }

    public static Result<Position, Errors> Create(PositionName name, string? description, bool isActive)
    {
        if (description?.Length > LengthConstants.LENGTH_1000)
            return GeneralErrors.InvalidField(nameof(Description)).ToErrors();

        var id = PositionId.New();
        DateTime createdAt = DateTime.UtcNow;
        DateTime updatedAt = createdAt;

        return new Position(id, name, description, isActive, createdAt, updatedAt);
    }
}
