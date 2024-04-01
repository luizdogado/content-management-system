using HtmlContent.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HtmlContent;

public abstract class HtmlContentController : AbpControllerBase
{
    protected HtmlContentController()
    {
        LocalizationResource = typeof(HtmlContentResource);
    }
}
