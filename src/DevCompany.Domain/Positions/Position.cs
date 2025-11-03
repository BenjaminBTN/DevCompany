using CSharpFunctionalExtensions;
using DevCompany.Domain.Constants;
using DevCompany.Domain.Positions.VO;

namespace DevCompany.Domain.Positions;

public class Position
{
    public Guid Id { get; private set; }
    public PositionName Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Position(
        Guid id,
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

    public static Result<Position> Create(PositionName name, string? description, bool isActive)
    {
        if (description?.Length > LengthConstants.LENGTH_1000)
            return Result.Failure<Position>("Description cannot be more than 1000");

        var id = Guid.NewGuid();
        DateTime createdAt = DateTime.UtcNow;
        DateTime updatedAt = createdAt;

        return new Position(id, name, description, isActive, createdAt, updatedAt);
    }
}