using MediatR;

namespace Abp.Cqrs.Commands
{
    public interface ICommand<out TCommandResult> : IRequest<TCommandResult>,IMessage
    {
        
    }

    public interface ICommand : ICommand<Unit>,IRequest
    {
    }
}