using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ContentManagementSystem;

[Dependency(ReplaceServices = true)]
public class ContentManagementSystemBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ContentManagementSystem";
}
