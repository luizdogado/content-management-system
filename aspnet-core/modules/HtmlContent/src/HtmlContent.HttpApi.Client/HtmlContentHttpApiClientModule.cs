using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace HtmlContent;

[DependsOn(
    typeof(HtmlContentApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class HtmlContentHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(HtmlContentApplicationContractsModule).Assembly,
            HtmlContentRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<HtmlContentHttpApiClientModule>();
        });

    }
}
