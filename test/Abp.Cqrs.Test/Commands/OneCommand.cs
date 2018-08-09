using Abp.Cqrs.Commands;

namespace Abp.Cqrs.Test.Commands
{
    public class OneCommand : Command
    {
        public string Name { get; }

        public OneCommand()
        {
            this.Name = "诸葛亮";
        }
    }
}