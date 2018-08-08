using MediatR;

namespace Abp.Cqrs.Events
{
    public interface IAbpCqrsEvent : INotification,IMessage
    {
    }
}