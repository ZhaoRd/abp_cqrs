using System.Threading.Tasks;
using Abp.Dependency;

namespace Abp.Cqrs.Commands
{
    /// <summary>
    /// 定义命令总线接口
    /// </summary>
    public interface ICommandBus : ITransientDependency
    {
        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="command">
        /// 命令
        /// </param>
        /// <typeparam name="TCommand">
        /// 命令类型
        /// </typeparam>
        /// <returns></returns>
        Task Send<TCommand>(TCommand command)
            where TCommand : ICommand;

        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="command">
        /// 命令
        /// </param>
        /// <typeparam name="TCommand">
        /// 命令类型
        /// </typeparam>
        /// <typeparam name="TCommandResult">
        /// 命令返回类型
        /// </typeparam>
        /// <returns></returns>
        Task<TCommandResult> Send<TCommand, TCommandResult>(
            TCommand command)
            where TCommand:ICommand<TCommandResult>;
    }
}