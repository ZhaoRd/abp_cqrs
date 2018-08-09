using System.Threading.Tasks;
using MediatR;

namespace Abp.Cqrs.Events
{
    /// <summary>
    /// cqrs 事件总线
    /// </summary>
    public class AbpCqrsEventBus : IAbpCqrsEventBus
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 初始化<see cref="AbpCqrsEventBus"/>实例
        /// </summary>
        /// <param name="mediator">
        /// <see cref="IMediator"/>
        /// </param>
        public AbpCqrsEventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="event">事件</param>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <returns></returns>
        public Task Publish<TEvent>(TEvent @event) where TEvent : IAbpCqrsEvent
        {
            return _mediator.Publish(@event);
        }
    }
}