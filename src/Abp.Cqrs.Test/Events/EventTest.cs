using System.Threading.Tasks;
using Abp.Cqrs.Events;
using Shouldly;
using Xunit;

namespace Abp.Cqrs.Test.Events
{
    public class EventTest: AbpCqrsTestBase
    {
        private readonly IAbpCqrsEventBus _eventBus;

        public EventTest()
        {
            this._eventBus = this.LocalIocManager.Resolve<IAbpCqrsEventBus>();
        }

        [Fact]
        public async Task SendEventTest()
        {
            1.ShouldBe(1);
            OneEventHandler.Counter.ShouldBe(0);
            await this._eventBus.Publish(new OneEvent());
            OneEventHandler.Counter.ShouldBe(1);
            await Task.FromResult(0);
        }
        
    }
}