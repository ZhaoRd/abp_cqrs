using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor.Installer;
using MediatR;

namespace Abp.Cqrs
{
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpCqrsModule:AbpModule
    {
        public override void PreInitialize()
        {
            var container = this.IocManager.IocContainer;
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Kernel.AddHandlersFilter(new ContravariantFilter());
            
            container.Register(Component.For<IMediator>().ImplementedBy<Mediator>().LifestylePerThread());
            
            container.Register(Component.For<ServiceFactory>().UsingFactoryMethod<ServiceFactory>(k => (type =>
            {
                var enumerableType = type
                    .GetInterfaces()
                    .Concat(new [] {type})
                    .FirstOrDefault(t =>  t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                return enumerableType != null ? k.ResolveAll(enumerableType.GetGenericArguments()[0]) : k.Resolve(type);
            })));
            
            /*this.IocManager.IocContainer.Register(Component.For<SingleInstanceFactory>().UsingFactoryMethod<SingleInstanceFactory>(k => t => k.Resolve(t)));
            this.IocManager.IocContainer.Register(Component.For<MultiInstanceFactory>().UsingFactoryMethod<MultiInstanceFactory>(k => t => (IEnumerable<object>)k.ResolveAll(t)));*/

            
            /*

            this.IocManager.IocContainer.Register(Component.For<SingleInstanceFactory>().UsingFactoryMethod<SingleInstanceFactory>(k => t => k.Resolve(t)));
            this.IocManager.IocContainer.Register(Component.For<MultiInstanceFactory>().UsingFactoryMethod<MultiInstanceFactory>(k => t => (IEnumerable<object>)k.ResolveAll(t)));
            
            this.IocManager.IocContainer.Register(Component.For(typeof(IPipelineBehavior<,>)).ImplementedBy(typeof(RequestPreProcessorBehavior<,>)).NamedAutomatically("PreProcessorBehavior"));
            this.IocManager.IocContainer.Register(Component.For(typeof(IPipelineBehavior<,>)).ImplementedBy(typeof(RequestPostProcessorBehavior<,>)).NamedAutomatically("PostProcessorBehavior"));
            this.IocManager.IocContainer.Register(Component.For(typeof(IPipelineBehavior<,>)).ImplementedBy(typeof(GenericPipelineBehavior<,>)).NamedAutomatically("Pipeline"));
            this.IocManager.IocContainer.Register(Component.For(typeof(IRequestPreProcessor<>)).ImplementedBy(typeof(GenericRequestPreProcessor<>)).NamedAutomatically("PreProcessor"));
            this.IocManager.IocContainer.Register(Component.For(typeof(IRequestPostProcessor<,>)).ImplementedBy(typeof(GenericRequestPostProcessor<,>)).NamedAutomatically("PostProcessor"));*/
        }

        public override void Initialize()
        {
            var assembly = typeof(AbpCqrsModule).GetAssembly();
            this.IocManager.RegisterAssemblyByConvention(assembly);

            
            this.IocManager.RegisterAssemblyCqrs<AbpCqrsModule>();

            
        }

        public override void PostInitialize()
        {
            
        }
    }

    public static class IocManagerExtentions
    {
        public static void RegisterAssemblyCqrs<TModule>(this IIocManager iocmanager)
            where TModule:AbpModule
        {
            
            var container = iocmanager.IocContainer;
            container.Register(
                Classes.FromAssemblyContaining<TModule>()
                    .BasedOn(typeof(IRequestHandler<,>))
                    .WithServiceAllInterfaces()
            );
            
            container.Register(
                Classes.FromAssemblyContaining<TModule>()
                    .BasedOn(typeof(INotificationHandler<>))
                    .WithServiceAllInterfaces()
            );
            
        }
    }

}
