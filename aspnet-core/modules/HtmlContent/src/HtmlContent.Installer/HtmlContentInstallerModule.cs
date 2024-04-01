using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace HtmlContent;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class HtmlContentInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<HtmlContentInstallerModule>();
        });
    }
}
