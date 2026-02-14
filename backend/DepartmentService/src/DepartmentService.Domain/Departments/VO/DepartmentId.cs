namespace DepartmentService.Domain.Departments.VO;

public record DepartmentId
{
    public Guid Value { get; }

    private DepartmentId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DepartmentId" /> с новым <see cref="Guid"/>.
    /// </summary>
    /// <returns>Новый <see cref="DepartmentId" /> с уникальным <see cref="Guid"/>.</returns>
    public static DepartmentId New() => new(Guid.NewGuid());

    /// <summary>
    /// Инициализирует новый пустой экземпляр класса <see cref="DepartmentId" />.
    /// </summary>
    /// <returns>Новый <see cref="DepartmentId" /> с пустым <see cref="Guid"/>.</returns>
    public static DepartmentId Empty() => new(Guid.Empty);

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DepartmentId" /> с заданным <see cref="Guid"/>.
    /// </summary>
    /// <param name="value">ID формата <see cref="Guid"/>.</param>
    /// <returns>Новый <see cref="DepartmentId" /> с заданным <see cref="Guid"/>.</returns>
    public static DepartmentId Create(Guid value) => new(value);
}