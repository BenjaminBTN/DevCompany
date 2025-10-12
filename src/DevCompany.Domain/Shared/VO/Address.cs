using CSharpFunctionalExtensions;

namespace DevCompany.Domain.Shared.VO;

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

    public static Result<Address> Create(
        string country,
        string region,
        string city,
        string street,
        int houseNumber,
        string postalCode)
    {
        if (string.IsNullOrWhiteSpace(country))
            return Result.Failure<Address>("Country cannot be empty.");

        if (string.IsNullOrWhiteSpace(region))
            return Result.Failure<Address>("Region cannot be empty.");

        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>("City cannot be empty.");

        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<Address>("Street cannot be empty.");

        if (houseNumber < 1)
            return Result.Failure<Address>("House number cannot be less than 1.");

        if (string.IsNullOrWhiteSpace(postalCode) || postalCode.Length < POSTAL_CODE_LENGTH)
            return Result.Failure<Address>("Postal code cannot be empty or less than 6.");

        return new Address(country, region, city, street, houseNumber, postalCode);
    }
}