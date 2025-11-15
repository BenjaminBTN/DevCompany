namespace DevCompany.Contracts.Shared;

public record AddressDto(
    string Country,
    string Region,
    string City,
    string Street,
    int HouseNumber,
    string PostalCode);