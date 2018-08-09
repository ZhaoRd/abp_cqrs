using MediatR;

namespace Abp.Cqrs.Commands
{
    /// <summary>
    /// 定于命令接口
    /// </summary>
    /// <typeparam name="TCommandResult">
    /// 命令返回类型
    /// </typeparam>
    public interface ICommand<out TCommandResult> : IRequest<TCommandResult>,IMessage
    {
        
    }

    /// <summary>
    /// 定义命令接口
    /// </summary>
    public interface ICommand : ICommand<Unit>,IRequest
    {
    }
}