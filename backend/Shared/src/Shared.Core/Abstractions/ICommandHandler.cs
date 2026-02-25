using CSharpFunctionalExtensions;
using Shared.Kernel;

namespace Shared.Core.Abstractions;

public interface ICommandHandler<TResponse, TCommand> where TCommand : ICommand
{
    Task<Result<TResponse, Errors>> Handle(TCommand command, CancellationToken cancellationToken);
}
