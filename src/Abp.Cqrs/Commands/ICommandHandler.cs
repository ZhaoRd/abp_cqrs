using MediatR;

namespace Abp.Cqrs.Commands
{
    /// <summary>
    /// 定义命令处理接口
    /// </summary>
    /// <typeparam name="TCommand">命令类型</typeparam>
    /// <typeparam name="TCommandResult">命令返回类型</typeparam>
    public interface ICommandHandler<in TCommand, TCommandResult> : IRequestHandler<TCommand,TCommandResult>
        where TCommand : ICommand<TCommandResult>
    {
    }

    /// <summary>
    /// 定义命令处理接口
    /// </summary>
    /// <typeparam name="TCommand">命令类型</typeparam>
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }
}