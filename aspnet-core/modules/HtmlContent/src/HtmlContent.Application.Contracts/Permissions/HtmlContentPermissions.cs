using Volo.Abp.Reflection;

namespace HtmlContent.Permissions;

public class HtmlContentPermissions
{
    public const string GroupName = "HtmlContent";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(HtmlContentPermissions));
    }
}
