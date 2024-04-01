using HtmlContent.Dtos.ContentPage;
using HtmlContent.Entities.ContentPages;
using HtmlContent.Entities.ContentPages.Contracts;
using HtmlContent.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace HtmlContent.Repositories.ContentPages;

public class ContentPageRepository : EfCoreRepository<HtmlContentDbContext, ContentPage>, IContentPageRepository
{
    public ContentPageRepository(IDbContextProvider<HtmlContentDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<(int count, List<ContentPage> data)> GetAll(PagedContentPageDto input)
    {
        var query = await GetQueryableAsync();
        var count = query.Count();
        query.OrderBy(input.Sorting).Skip(input.SkipCount).Take(input.MaxResult);
        return (count, await query.ToListAsync());
    }
}
