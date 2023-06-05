using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using varsity.Authorization;

namespace varsity
{
    [DependsOn(
        typeof(varsityCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class varsityApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<varsityAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(varsityApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
