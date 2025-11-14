using DevCompany.Contracts.Shared;

namespace DevCompany.Contracts.Locations;

public record CreateLocationRequest(string Name, AddressDto Address, string Timezone);