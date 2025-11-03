namespace DevCompany.Domain.Locations.VO;

public record LocationId
{
    public Guid Value { get; }

    private LocationId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="LocationId" /> с новым <see cref="Guid"/>.
    /// </summary>
    /// <returns>Новый <see cref="LocationId" /> с уникальным <see cref="Guid"/>.</returns>
    public static LocationId New() => new(Guid.NewGuid());

    /// <summary>
    /// Инициализирует новый пустой экземпляр класса <see cref="LocationId" />.
    /// </summary>
    /// <returns>Новый <see cref="LocationId" /> с пустым <see cref="Guid"/>.</returns>
    public static LocationId Empty() => new(Guid.Empty);

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="LocationId" /> с заданным <see cref="Guid"/>.
    /// </summary>
    /// <param name="value">ID формата <see cref="Guid"/>.</param>
    /// <returns>Новый <see cref="LocationId" /> с заданным <see cref="Guid"/>.</returns>
    public static LocationId Create(Guid value) => new(value);
}