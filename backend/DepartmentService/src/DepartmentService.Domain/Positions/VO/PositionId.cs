namespace DepartmentService.Domain.Positions.VO;

public class PositionId
{
    public Guid Value { get; }

    private PositionId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="PositionId" /> с новым <see cref="Guid"/>.
    /// </summary>
    /// <returns>Новый <see cref="PositionId" /> с уникальным <see cref="Guid"/>.</returns>
    public static PositionId New() => new(Guid.NewGuid());

    /// <summary>
    /// Инициализирует новый пустой экземпляр класса <see cref="PositionId" />.
    /// </summary>
    /// <returns>Новый <see cref="PositionId" /> с пустым <see cref="Guid"/>.</returns>
    public static PositionId Empty() => new(Guid.Empty);

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="PositionId" /> с заданным <see cref="Guid"/>.
    /// </summary>
    /// <param name="value">ID формата <see cref="Guid"/>.</param>
    /// <returns>Новый <see cref="PositionId" /> с заданным <see cref="Guid"/>.</returns>
    public static PositionId Create(Guid value) => new(value);
}