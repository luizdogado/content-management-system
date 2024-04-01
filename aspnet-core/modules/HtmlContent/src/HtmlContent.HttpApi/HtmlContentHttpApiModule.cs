using Localization.Resources.AbpUi;
using HtmlContent.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace HtmlContent;

[DependsOn(
    typeof(HtmlContentApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class HtmlContentHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(HtmlContentHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<HtmlContentResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
