using CSharpFunctionalExtensions;
using DevCompany.Domain.Positions.VO;

namespace DevCompany.Domain.Positions;

public class Position
{
    private Position(
        Guid id,
        PositionName name,
        string? descripton,
        bool isActive,
        DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Descripton = descripton;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Guid Id { get; private set; }
    public PositionName Name { get; private set; }
    public string? Descripton { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static Result<Position> Create(PositionName name, string? description, bool isActive)
    {
        if (description?.Length > 1000)
            return Result.Failure<Position>("Description cannot be more than 1000");

        var id = Guid.NewGuid();
        DateTime createdAt = DateTime.Now;
        DateTime updatedAt = createdAt;

        return new Position(id, name, description, isActive, createdAt, updatedAt);
    }
}
