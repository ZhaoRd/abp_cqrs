using System;
using MediatR;

namespace Abp.Cqrs.Commands
{
    [Serializable]
    public abstract class Command:Command<Unit>,ICommand
    {
    }

    [Serializable]
    public abstract class Command<TCommandResult> : Message,ICommand<TCommandResult>
    {
        
    }
}