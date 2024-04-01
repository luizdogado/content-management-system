using HtmlContent.ContentPages.Dtos.Input;
using HtmlContent.ContentPages.Dtos.Output;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HtmlContent.ContentPages;

public interface IContentPageAppService : IApplicationService
{
    Task<PagedResultDto<ContentPageOutputDto>> GetAll(PagedContentPageInputDto inputDto);
    Task<ContentPageOutputDto> GetCMSContent([FromRoute] int contentId);
    Task<ContentPageOutputDto> InsertOrUpdateCMSContent(InsertOrUpdateContentInputDto inputDto);
}