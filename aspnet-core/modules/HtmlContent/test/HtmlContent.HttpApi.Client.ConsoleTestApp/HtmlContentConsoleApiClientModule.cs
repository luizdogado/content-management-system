using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace HtmlContent;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HtmlContentHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class HtmlContentConsoleApiClientModule : AbpModule
{

}
