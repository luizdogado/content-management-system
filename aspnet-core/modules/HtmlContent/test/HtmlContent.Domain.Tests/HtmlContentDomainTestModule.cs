using Volo.Abp.Modularity;

namespace HtmlContent;

[DependsOn(
    typeof(HtmlContentDomainModule),
    typeof(HtmlContentTestBaseModule)
)]
public class HtmlContentDomainTestModule : AbpModule
{

}
