using HtmlContent.Entities.ContentPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace HtmlContent.EntityFrameworkCore;

public static class HtmlContentDbContextModelCreatingExtensions
{
    public static void ConfigureHtmlContent(
        this ModelBuilder builder,
        Action<HtmlContentModelBuilderConfigurationOptions> optionsAction = null)
    {
        Check.NotNull(builder, nameof(builder));

        var options = new HtmlContentModelBuilderConfigurationOptions(
            HtmlContentDbProperties.DbTablePrefix,
            HtmlContentDbProperties.DbSchema
        );

        optionsAction?.Invoke(options);
        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(HtmlContentDbProperties.DbTablePrefix + "Questions", HtmlContentDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        builder.Entity<ContentPage>(b =>
        {
            b.ToTable(options.TablePrefix + "ContentPage", options.Schema);
            b.ConfigureByConvention();
            b.ApplyObjectExtensionMappings();
        });
    }
}
