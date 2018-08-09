using System;
using MediatR;

namespace Abp.Cqrs.Commands
{
    /// <summary>
    /// 无返回结果命令基类
    /// </summary>
    [Serializable]
    public abstract class Command:Command<Unit>,ICommand
    {
    }

    /// <summary>
    /// 有返回结果命令基类
    /// </summary>
    /// <typeparam name="TCommandResult">
    /// 命令返回结果类型
    /// </typeparam>
    [Serializable]
    public abstract class Command<TCommandResult> : Message,ICommand<TCommandResult>
    {
        
    }
}