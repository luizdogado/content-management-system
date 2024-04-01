using Volo.Abp.Modularity;

namespace HtmlContent;

[DependsOn(
    typeof(HtmlContentApplicationModule),
    typeof(HtmlContentDomainTestModule)
    )]
public class HtmlContentApplicationTestModule : AbpModule
{

}
