using DepartmentService.Application.Abstractions;
using DepartmentService.Contracts.Locations;
using DepartmentService.Contracts.Shared;

namespace DepartmentService.Application.Locations;

public record CreateLocationCommand(CreateLocationRequest Request) : ICommand;
