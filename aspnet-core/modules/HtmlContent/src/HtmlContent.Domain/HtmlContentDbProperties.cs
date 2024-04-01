namespace HtmlContent;

public static class HtmlContentDbProperties
{
    public static string DbTablePrefix { get; set; } = "HtmlContent";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "HtmlContent";
}
