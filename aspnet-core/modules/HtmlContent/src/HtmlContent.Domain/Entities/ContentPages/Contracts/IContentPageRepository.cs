using HtmlContent.Dtos.ContentPage;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace HtmlContent.Entities.ContentPages.Contracts;

public interface IContentPageRepository : IRepository<ContentPage>
{
    Task<(int count, List<ContentPage> data)> GetAll(PagedContentPageDto input);
}
