using System.Threading.Tasks;
using Abp.Dependency;

namespace Abp.Cqrs.Commands
{
    public interface ICommandBus : ITransientDependency
    {
        Task Send<TCommand>(TCommand command)
            where TCommand : ICommand;

        Task<TCommandResult> Send<TCommand, TCommandResult>(
            TCommand command)
            where TCommand:ICommand<TCommandResult>;
    }
}