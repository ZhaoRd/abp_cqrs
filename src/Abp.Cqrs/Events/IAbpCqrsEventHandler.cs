using MediatR;

namespace Abp.Cqrs.Events
{
    public interface IAbpCqrsEventHandler<in TEvent> : INotificationHandler<TEvent>
        where TEvent : IAbpCqrsEvent
    {
    }
}