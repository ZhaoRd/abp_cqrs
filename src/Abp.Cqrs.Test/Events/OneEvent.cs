using System.Threading;
using System.Threading.Tasks;
using Abp.Cqrs.Events;
using Shouldly;

namespace Abp.Cqrs.Test.Events
{
    public class OneEvent: AbpCqrsEvent
    {
        public string Name { get; set; }

        public OneEvent()
        {
            this.Name = "关羽";
        }
    }

    public class OneEventHandler : IAbpCqrsEventHandler<OneEvent>
    {
        public static int Counter { get; private set; }

        public async Task Handle(OneEvent notification, CancellationToken cancellationToken)
        {
            Counter++;
            
            notification.Name.ShouldBe("关羽");

            await Task.FromResult(0);
        }
    }
}