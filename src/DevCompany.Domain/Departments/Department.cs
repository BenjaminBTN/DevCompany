using CSharpFunctionalExtensions;
using DevCompany.Domain.Departments.VO;

namespace DevCompany.Domain.Departments;

public class Department
{
    private List<DepartmentLocation> _departmentLocations = [];
    private List<DepartmentPosition> _departmentPositions = [];

    public DepartmentId Id { get; private set; } = null!;
    public DepartmentName Name { get; private set; } = null!;
    public string Identifier { get; private set; } = string.Empty;
    public Guid? ParentId { get; private set; }
    public DepartmentPath Path { get; private set; } = null!;
    public short Depth { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;
    public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;

    private Department(
        DepartmentId id,
        DepartmentName name,
        string identifier,
        Guid? parentId,
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
        _departmentLocations = locationIds.Select(li => DepartmentLocation.Create(Id.Value, li).Value).ToList();
        _departmentPositions = positionIds.Select(pi => DepartmentPosition.Create(Id.Value, pi).Value).ToList();
    }

    // ef core
    private Department()
    {
    }

    public static Result<Department> Create(
        DepartmentName name,
        string identifier,
        Guid? parentId,
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