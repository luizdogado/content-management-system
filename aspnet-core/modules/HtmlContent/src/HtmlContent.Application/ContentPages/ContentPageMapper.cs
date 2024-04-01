using AutoMapper;
using HtmlContent.ContentPages.Dtos.Input;
using HtmlContent.ContentPages.Dtos.Output;
using HtmlContent.Dtos.ContentPage;
using HtmlContent.Entities.ContentPages;

namespace HtmlContent.ContentPages;

public class ContentPageMapper : Profile
{
    public ContentPageMapper()
    {
        CreateMap<InsertOrUpdateContentInputDto, ContentPage>();
        CreateMap<ContentPage, ContentPageOutputDto>();
        CreateMap<PagedContentPageInputDto, PagedContentPageDto>();
    }
}
