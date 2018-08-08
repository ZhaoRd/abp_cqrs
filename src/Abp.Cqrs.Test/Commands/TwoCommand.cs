using Abp.Cqrs.Commands;

namespace Abp.Cqrs.Test.Commands
{
    public class TwoCommand : Command<TwoCommandResult>
    {
        public string Name { get; }

        public TwoCommand()
        {
            this.Name = "刘备";
        }
    }

    public class TwoCommandResult
    {
        public string Result { get; set; }
    }

}