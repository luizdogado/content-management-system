using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace HtmlContent;

[DependsOn(
    typeof(HtmlContentDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class HtmlContentApplicationContractsModule : AbpModule
{

}
