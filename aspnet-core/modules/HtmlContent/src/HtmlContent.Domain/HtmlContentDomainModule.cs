using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace HtmlContent;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(HtmlContentDomainSharedModule)
)]
public class HtmlContentDomainModule : AbpModule
{

}
