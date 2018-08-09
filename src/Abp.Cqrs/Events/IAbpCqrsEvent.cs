using MediatR;

namespace Abp.Cqrs.Events
{
    /// <summary>
    /// 定义cqrs事件接口
    /// </summary>
    public interface IAbpCqrsEvent : INotification,IMessage
    {
    }
}