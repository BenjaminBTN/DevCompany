using CSharpFunctionalExtensions;
using DevCompany.Domain.Departments.VO;

namespace DevCompany.Domain.Departments;

public class Department
{
    private List<DepartmentLocation> _locations = [];
    private List<DepartmentPosition> _positions = [];
    private List<Department> _childrens = [];

    public DepartmentId Id { get; private set; } = null!;
    public DepartmentName Name { get; private set; } = null!;
    public string Identifier { get; private set; } = string.Empty;
    public DepartmentId? ParentId { get; private set; }
    public Department Parent { get; private set; } = null!;
    public DepartmentPath Path { get; private set; } = null!;
    public short Depth { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public IReadOnlyList<DepartmentLocation> Locations => _locations;
    public IReadOnlyList<DepartmentPosition> Positions => _positions;
    public IReadOnlyList<Department> Childrens => _childrens;

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

    public static Result<Department> Create(
        DepartmentName name,
        string identifier,
        DepartmentId? parentId,
        DepartmentPath path,
        short depth,
        bool isActive,
        IEnumerable<Guid> locationIds,
        IEnumerable<Guid> positionIds)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            return Result.Failure<Department>("Identifier cannot be empty.");

        if (depth < 0)
            return Result.Failure<Department>("Depth cannot be less then zero.");

        var id = DepartmentId.New();
        DateTime createdAt = DateTime.UtcNow;
        DateTime updatedAt = createdAt;

        return new Department(
            id, name, identifier, parentId, path, depth, isActive, createdAt, updatedAt, locationIds, positionIds);
    }
}