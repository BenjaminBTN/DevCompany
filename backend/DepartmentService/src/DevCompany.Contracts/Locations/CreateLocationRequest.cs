using DepartmentService.Contracts.Shared;

namespace DepartmentService.Contracts.Locations;

public record CreateLocationRequest(string Name, AddressDto Address, string Timezone);