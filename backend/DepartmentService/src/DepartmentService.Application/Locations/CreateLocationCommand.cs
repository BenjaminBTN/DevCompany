using DepartmentService.Contracts.Locations;
using Shared.Core.Abstractions;

namespace DepartmentService.Application.Locations;

public record CreateLocationCommand(CreateLocationRequest Request) : ICommand;
