using HtmlContent.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace HtmlContent.Permissions;

public class HtmlContentPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HtmlContentPermissions.GroupName, L("Permission:HtmlContent"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HtmlContentResource>(name);
    }
}
