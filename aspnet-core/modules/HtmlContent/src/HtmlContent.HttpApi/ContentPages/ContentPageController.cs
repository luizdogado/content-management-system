using HtmlContent.ContentPages.Dtos.Input;
using HtmlContent.ContentPages.Dtos.Output;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace HtmlContent.ContentPages;

[Area(HtmlContentRemoteServiceConsts.ModuleName)]
[RemoteService(Name = HtmlContentRemoteServiceConsts.RemoteServiceName)]
public class ContentPageController : HtmlContentController, IContentPageAppService
{
    private readonly IContentPageAppService _contentPageAppService;

    public ContentPageController(IContentPageAppService contentPageAppService)
    {
        _contentPageAppService = contentPageAppService;
    }

    [HttpGet("api/html-content/content-page")]
    public async Task<PagedResultDto<ContentPageOutputDto>> GetAll(PagedContentPageInputDto inputDto)
    {
        return await _contentPageAppService.GetAll(inputDto);
    }

    [HttpGet("api/html-content/content-page/{contentId}")]
    public async Task<ContentPageOutputDto> GetCMSContent([FromRoute] int contentId)
    {
        return await _contentPageAppService.GetCMSContent(contentId);
    }

    [HttpPost("api/html-content/content-page")]
    public async Task<ContentPageOutputDto> InsertOrUpdateCMSContent(InsertOrUpdateContentInputDto inputDto)
    {
        return await _contentPageAppService.InsertOrUpdateCMSContent(inputDto);
    }
}
