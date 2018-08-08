using System.Threading.Tasks;
using Abp.Dependency;

namespace Abp.Cqrs.Events
{
    public interface IAbpCqrsEventBus:ITransientDependency
    {
        Task Publish<TEvent>(TEvent @event) where TEvent : IAbpCqrsEvent;
    }
}