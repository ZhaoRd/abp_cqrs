using System;
using System.Collections.Generic;
using System.Linq;
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
}
