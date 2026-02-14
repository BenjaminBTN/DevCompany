using CSharpFunctionalExtensions;
using DepartmentService.Shared;

namespace DepartmentService.Domain.Shared.VO;

public record Address
{
    public const int POSTAL_CODE_LENGTH = 6;

    public string Country { get; }
    public string Region { get; }
    public string City { get; }
    public string Street { get; }
    public int HouseNumber { get; }
    public string PostalCode { get; }

    private Address(string country, string region, string city, string street, int houseNumber, string postalCode)
    {
        Country = country;
        Region = region;
        City = city;
        Street = street;
        HouseNumber = houseNumber;
        PostalCode = postalCode;
    }

    public static Result<Address, Errors> Create(
        string country,
        string region,
        string city,
        string street,
        int houseNumber,
        string postalCode)
    {
        List<Error> errors = [];

        if (string.IsNullOrWhiteSpace(country))
            errors.Add(GeneralErrors.CannotBeEmpty(nameof(Country)));

        if (string.IsNullOrWhiteSpace(region))
            errors.Add(GeneralErrors.CannotBeEmpty(nameof(Region)));

        if (string.IsNullOrWhiteSpace(city))
            errors.Add(GeneralErrors.CannotBeEmpty(nameof(City)));

        if (string.IsNullOrWhiteSpace(street))
            errors.Add(GeneralErrors.CannotBeEmpty(nameof(Street)));

        if (houseNumber < 1)
            errors.Add(GeneralErrors.InvalidField(nameof(HouseNumber)));

        if (string.IsNullOrWhiteSpace(postalCode))
            errors.Add(GeneralErrors.CannotBeEmpty(nameof(PostalCode)));

        if (postalCode.Length < POSTAL_CODE_LENGTH)
            errors.Add(GeneralErrors.InvalidField(nameof(PostalCode)));

        if (errors.Count != 0)
            return new Errors(errors);

        return new Address(country, region, city, street, houseNumber, postalCode);
    }
}
