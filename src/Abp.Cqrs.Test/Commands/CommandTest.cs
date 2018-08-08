using System.Threading.Tasks;
using Abp.Cqrs.Commands;
using Shouldly;
using Xunit;

namespace Abp.Cqrs.Test.Commands
{
    public class CommandTest : AbpCqrsTestBase
    {
        private readonly ICommandBus _commandBus;

        public CommandTest()
        {
            this._commandBus = this.LocalIocManager.Resolve<ICommandBus>();
        }

        [Fact]
        public async Task SendCommandTest()
        {
            1.ShouldBe(1);
            CommandHandler.Counter.ShouldBe(0);
            await this._commandBus.Send(new OneCommand());
            CommandHandler.Counter.ShouldBe(1);
            var result = await this._commandBus.Send<TwoCommand,TwoCommandResult>(new TwoCommand());
            CommandHandler.Counter.ShouldBe(2);
            result.ShouldNotBeNull();
            result.Result.ShouldBe("Hello 刘备");
            await Task.FromResult(0);
        }
    }
}