using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace HtmlContent.EntityFrameworkCore;

[ConnectionStringName(HtmlContentDbProperties.ConnectionStringName)]
public interface IHtmlContentDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
