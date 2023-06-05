using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using varsity.EntityFrameworkCore;
using varsity.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace varsity.Web.Tests
{
    [DependsOn(
        typeof(varsityWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class varsityWebTestModule : AbpModule
    {
        public varsityWebTestModule(varsityEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(varsityWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(varsityWebMvcModule).Assembly);
        }
    }
}