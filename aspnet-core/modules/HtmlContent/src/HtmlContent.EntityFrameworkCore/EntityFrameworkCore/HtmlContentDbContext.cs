using HtmlContent.Entities.ContentPages;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace HtmlContent.EntityFrameworkCore;

[ConnectionStringName(HtmlContentDbProperties.ConnectionStringName)]
public class HtmlContentDbContext : AbpDbContext<HtmlContentDbContext>, IHtmlContentDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<ContentPage> ContantPage { get; set; }

    public HtmlContentDbContext(DbContextOptions<HtmlContentDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureHtmlContent();
    }
}
