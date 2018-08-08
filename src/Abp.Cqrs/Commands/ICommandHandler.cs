using MediatR;

namespace Abp.Cqrs.Commands
{
    public interface ICommandHandler<in TCommand, TCommandResult> : IRequestHandler<TCommand,TCommandResult>
        where TCommand : ICommand<TCommandResult>
    {
    }

    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }
}