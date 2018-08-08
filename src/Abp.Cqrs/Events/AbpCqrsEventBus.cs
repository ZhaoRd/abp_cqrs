using System.Threading.Tasks;
using MediatR;

namespace Abp.Cqrs.Events
{
    public class AbpCqrsEventBus : IAbpCqrsEventBus
    {
        private readonly IMediator _mediator;

        public AbpCqrsEventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Publish<TEvent>(TEvent @event) where TEvent : IAbpCqrsEvent
        {
            return _mediator.Publish(@event);
        }
    }
}