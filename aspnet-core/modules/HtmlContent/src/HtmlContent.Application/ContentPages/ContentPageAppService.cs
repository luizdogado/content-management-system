using HtmlContent.ContentPages.Dtos.Input;
using HtmlContent.ContentPages.Dtos.Output;
using HtmlContent.Dtos.ContentPage;
using HtmlContent.Entities.ContentPages;
using HtmlContent.Entities.ContentPages.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HtmlContent.ContentPages;

public class ContentPageAppService : HtmlContentAppService, IContentPageAppService
{
    private readonly IContentPageRepository _contentPageRepository;

    public ContentPageAppService(IContentPageRepository contentPageRepository)
    {
        _contentPageRepository = contentPageRepository;
    }

    [HttpPost("api/html-content/content-page")]
    public async Task<ContentPageOutputDto> InsertOrUpdateCMSContent(InsertOrUpdateContentInputDto inputDto)
    {
        var content = await _contentPageRepository.FirstOrDefaultAsync(ent => ent.Id == inputDto.Id);

        if (content is null)
            content = await _contentPageRepository.InsertAsync(ObjectMapper.Map<InsertOrUpdateContentInputDto, ContentPage>(inputDto));
        else
        {
            content = await _contentPageRepository.UpdateAsync(ObjectMapper.Map(inputDto, content));
        }

        return ObjectMapper.Map<ContentPage, ContentPageOutputDto>(content);
    }

    [HttpGet("api/html-content/content-page/{contentId}")]
    public async Task<ContentPageOutputDto> GetCMSContent([FromRoute] int contentId)
    {
        return ObjectMapper.Map<ContentPage, ContentPageOutputDto>(await _contentPageRepository.GetAsync(ent => ent.Id == contentId));
    }

    [HttpGet("api/html-content/content-page")]
    public async Task<PagedResultDto<ContentPageOutputDto>> GetAll(PagedContentPageInputDto inputDto)
    {
        var (count, data) = await _contentPageRepository.GetAll(ObjectMapper.Map<PagedContentPageInputDto, PagedContentPageDto>(inputDto));

        return new (count, ObjectMapper.Map<List<ContentPage>, List<ContentPageOutputDto>>(data));
    }
}
