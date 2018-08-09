using System.Threading.Tasks;
using MediatR;

namespace Abp.Cqrs.Commands
{
    /// <summary>
    /// 命令总线
    /// </summary>
    public class CommandBus:ICommandBus
    {
        /// <summary>
        /// <see cref="IMediator"/>
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// 初始化<see cref="CommandBus"/> 实例
        /// </summary>
        /// <param name="mediator"></param>
        public CommandBus(IMediator mediator)
        {
            this._mediator = mediator;
        }

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
        public async Task Send<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            await this._mediator.Send(command);
        }

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
        public async Task<TCommandResult> Send<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommand<TCommandResult>
        {
            return await this._mediator.Send(command);
        }
    }
}