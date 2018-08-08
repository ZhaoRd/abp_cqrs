using System.Threading.Tasks;
using MediatR;

namespace Abp.Cqrs.Commands
{
    public class CommandBus:ICommandBus
    {
        private readonly IMediator _mediator;

        public CommandBus(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task Send<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            await this._mediator.Send(command);
        }

        public async Task<TCommandResult> Send<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommand<TCommandResult>
        {
            return await this._mediator.Send(command);
        }
    }
}