namespace DepartmentService.Domain.Departments.VO;

public class DepartmentPositionId
{
    public Guid Value { get; }

    private DepartmentPositionId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DepartmentPositionId" /> с новым <see cref="Guid"/>.
    /// </summary>
    /// <returns>Новый <see cref="DepartmentPositionId" /> с уникальным <see cref="Guid"/>.</returns>
    public static DepartmentPositionId New() => new(Guid.NewGuid());

    /// <summary>
    /// Инициализирует новый пустой экземпляр класса <see cref="DepartmentPositionId" />.
    /// </summary>
    /// <returns>Новый <see cref="DepartmentPositionId" /> с пустым <see cref="Guid"/>.</returns>
    public static DepartmentPositionId Empty() => new(Guid.Empty);

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DepartmentPositionId" /> с заданным <see cref="Guid"/>.
    /// </summary>
    /// <param name="value">ID формата <see cref="Guid"/>.</param>
    /// <returns>Новый <see cref="DepartmentPositionId" /> с заданным <see cref="Guid"/>.</returns>
    public static DepartmentPositionId Create(Guid value) => new(value);
}