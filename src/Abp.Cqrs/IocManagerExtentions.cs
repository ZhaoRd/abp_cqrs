using Abp.Dependency;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using MediatR;

namespace Abp.Cqrs
{
    /// <summary>
    /// IocManager扩展类
    /// </summary>
    public static class IocManagerExtentions
    {
        /// <summary>
        /// 注册cqrs处理类
        /// </summary>
        /// <param name="iocmanager">
        /// <see cref="IocManager"/>
        /// </param>
        /// <typeparam name="TModule">
        /// 处理类所在模块类
        /// </typeparam>
        public static void RegisterAssemblyCqrs<TModule>(this IIocManager iocmanager)
            where TModule:AbpModule
        {
            
            var container = iocmanager.IocContainer;
            
            // 注册命令处理类
            container.Register(
                Classes.FromAssemblyContaining<TModule>()
                    .BasedOn(typeof(IRequestHandler<,>))
                    .WithServiceAllInterfaces()
            );
            
            // 注册事件处理类
            container.Register(
                Classes.FromAssemblyContaining<TModule>()
                    .BasedOn(typeof(INotificationHandler<>))
                    .WithServiceAllInterfaces()
            );
            
        }
    }
}