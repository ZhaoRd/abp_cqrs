using MediatR;

namespace Abp.Cqrs.Events
{
    /// <summary>
    /// 定义事件处理接口
    /// </summary>
    /// <typeparam name="TEvent">
    /// 事件类型
    /// </typeparam>
    public interface IAbpCqrsEventHandler<in TEvent> : INotificationHandler<TEvent>
        where TEvent : IAbpCqrsEvent
    {
    }
}