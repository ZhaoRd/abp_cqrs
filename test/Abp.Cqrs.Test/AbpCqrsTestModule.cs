namespace Abp.Cqrs.Test
{
	using Abp.Modules;
	using Abp.Reflection.Extensions;

	[DependsOn(typeof(AbpCqrsModule))]
	public class AbpCqrsTestModule : AbpModule
	{
		public override void PreInitialize()
		{
			
		}

		public override void Initialize()
	    {
		    this.IocManager.RegisterAssemblyCqrs<AbpCqrsTestModule>();
		    this.IocManager.RegisterAssemblyByConvention(typeof(AbpCqrsTestModule).GetAssembly());
	    }
	}
}
