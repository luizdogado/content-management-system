using ContentManagementSystem.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ContentManagementSystem.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ContentManagementSystemEntityFrameworkCoreModule),
    typeof(ContentManagementSystemApplicationContractsModule)
    )]
public class ContentManagementSystemDbMigratorModule : AbpModule
{
}
