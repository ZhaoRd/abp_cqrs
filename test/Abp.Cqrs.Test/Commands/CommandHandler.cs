using System.Threading;
using System.Threading.Tasks;
using Abp.Cqrs.Commands;
using MediatR;
using Shouldly;

namespace Abp.Cqrs.Test.Commands
{
    public class CommandHandler
    {
        public static int Counter { get; set; }
        
    }

    public class TwoCommandHandler : ICommandHandler<TwoCommand, TwoCommandResult>
    {
        
        public async Task<TwoCommandResult> Handle(TwoCommand request, CancellationToken cancellationToken)
        {
            request.Name.ShouldBe("刘备");
            CommandHandler.Counter++;
            return await Task.FromResult(new TwoCommandResult()
            {
                Result = $"Hello {request.Name}"
            });
        }
    }

    public class OneCommandHandler : ICommandHandler<OneCommand>
    {

        public async Task<Unit> Handle(OneCommand request, CancellationToken cancellationToken)
        {
            request.Name.ShouldBe("诸葛亮");
            CommandHandler.Counter++;
            return await Unit.Task;
        }

    }
}