using CSharpFunctionalExtensions;
using DepartmentService.Shared;

namespace DepartmentService.Application.Abstractions;

public interface ICommandHandler<TResponse, TCommand> where TCommand : ICommand
{
    Task<Result<TResponse, Errors>> Handle(TCommand command, CancellationToken cancellationToken);
}
