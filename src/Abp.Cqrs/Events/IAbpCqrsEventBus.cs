using System.Threading.Tasks;
using Abp.Dependency;

namespace Abp.Cqrs.Events
{
    /// <summary>
    /// 定义cqrs事件总线接口
    /// </summary>
    public interface IAbpCqrsEventBus:ITransientDependency
    {
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="event">事件</param>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <returns></returns>
        Task Publish<TEvent>(TEvent @event) where TEvent : IAbpCqrsEvent;
    }
}