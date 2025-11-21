using CSharpFunctionalExtensions;
using DevCompany.Domain.Departments.VO;
using DevCompany.Shared;

namespace DevCompany.Domain.Departments;

public class Department
{
    private List<DepartmentLocation> _locations = [];
    private List<DepartmentPosition> _positions = [];

    public DepartmentId Id { get; private set; } = null!;
    public DepartmentName Name { get; private set; } = null!;
    public string Identifier { get; private set; } = string.Empty;
    public DepartmentId? ParentId { get; private set; }
    public DepartmentPath Path { get; private set; } = null!;
    public short Depth { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public IReadOnlyList<DepartmentLocation> Locations => _locations;
    public IReadOnlyList<DepartmentPosition> Positions => _positions;

    private Department(
        DepartmentId id,
        DepartmentName name,
        string identifier,
        DepartmentId? parentId,
        DepartmentPath path,
        short depth,
        bool isActive,
        DateTime createdAt,
        DateTime updatedAt,
        IEnumerable<Guid> locationIds,
        IEnumerable<Guid> positionIds)
    {
        Id = id;
        Name = name;
        Identifier = identifier;
        ParentId = parentId;
        Path = path;
        Depth = depth;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        _locations = locationIds.Select(li => DepartmentLocation.Create(Id, li).Value).ToList();
        _positions = positionIds.Select(pi => DepartmentPosition.Create(Id, pi).Value).ToList();
    }

    // ef core
    private Department()
    {
    }

    public static Result<Department, Errors> Create(
        DepartmentName name,
        string identifier,
        DepartmentId? parentId,
        DepartmentPath path,
        short depth,
        bool isActive,
        IEnumerable<Guid> locationIds,
        IEnumerable<Guid> positionIds)
    {
        List<Error> errors = [];

        if (string.IsNullOrWhiteSpace(identifier))
            errors.Add(GeneralErrors.CannotBeEmpty(nameof(Identifier)));

        if (depth < 0)
            errors.Add(GeneralErrors.InvalidField(nameof(Depth)));

        if (errors.Count != 0)
            return new Errors(errors);

        var id = DepartmentId.New();
        DateTime createdAt = DateTime.UtcNow;
        DateTime updatedAt = createdAt;

        return new Department(
            id, name, identifier, parentId, path, depth, isActive, createdAt, updatedAt, locationIds, positionIds);
    }
}
