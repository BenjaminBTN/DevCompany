namespace DepartmentService.Domain.Departments.VO;

public class DepartmentLocationId
{
    public Guid Value { get; }

    private DepartmentLocationId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DepartmentLocationId" /> с новым <see cref="Guid"/>.
    /// </summary>
    /// <returns>Новый <see cref="DepartmentLocationId" /> с уникальным <see cref="Guid"/>.</returns>
    public static DepartmentLocationId New() => new(Guid.NewGuid());

    /// <summary>
    /// Инициализирует новый пустой экземпляр класса <see cref="DepartmentLocationId" />.
    /// </summary>
    /// <returns>Новый <see cref="DepartmentLocationId" /> с пустым <see cref="Guid"/>.</returns>
    public static DepartmentLocationId Empty() => new(Guid.Empty);

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DepartmentLocationId" /> с заданным <see cref="Guid"/>.
    /// </summary>
    /// <param name="value">ID формата <see cref="Guid"/>.</param>
    /// <returns>Новый <see cref="DepaDepartmentLocationIdrtmentId" /> с заданным <see cref="Guid"/>.</returns>
    public static DepartmentLocationId Create(Guid value) => new(value);
}