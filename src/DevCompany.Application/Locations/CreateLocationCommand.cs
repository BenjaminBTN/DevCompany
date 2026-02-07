using DevCompany.Application.Abstractions;
using DevCompany.Contracts.Locations;
using DevCompany.Contracts.Shared;

namespace DevCompany.Application.Locations;

public record CreateLocationCommand(CreateLocationRequest Request) : ICommand;
