using HtmlContent.Localization;
using Volo.Abp.Application.Services;

namespace HtmlContent;

public abstract class HtmlContentAppService : ApplicationService
{
    protected HtmlContentAppService()
    {
        LocalizationResource = typeof(HtmlContentResource);
        ObjectMapperContext = typeof(HtmlContentApplicationModule);
    }
}
