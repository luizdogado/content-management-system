using HtmlContent.ContentPages.Dtos.Input;
using HtmlContent.Entities.ContentPages;
using HtmlContent.Entities.ContentPages.Contracts;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace HtmlContent.ContentPages;

public abstract class ContentPageAppServiceTests<TStartupModule> : HtmlContentApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IContentPageAppService _appService;
    private readonly IContentPageRepository _contentPageRepository;

    public ContentPageAppServiceTests()
    {
        _appService = GetRequiredService<IContentPageAppService>();
        _contentPageRepository = GetRequiredService<IContentPageRepository>();
    }

    [Fact]
    public async Task ShouldInsertContent()
    {
        var contentDto = new InsertOrUpdateContentInputDto()
        {
            Name = "Teste",
            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
        };

        var content = await _appService.InsertOrUpdateCMSContent(contentDto);

        content.ShouldNotBeNull();

        Assert.Equal("Teste", content.Name);
        Assert.Equal("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", content.Content);
    }

    [Fact]
    public async Task ShouldUpdateContent()
    {
        var contentDb =  await _contentPageRepository.InsertAsync(new()
            {
                Name = "Content Test",
                Content = "Ut eu sem integer vitae justo eget magna. Tempus quam pellentesque nec nam aliquam sem et. Rhoncus est pellentesque elit ullamcorper dignissim cras tincidunt. Ultrices vitae auctor eu augue ut. Vulputate eu scelerisque felis imperdiet proin fermentum. Nibh nisl condimentum id venenatis a condimentum vitae sapien pellentesque. Nunc sed blandit libero volutpat sed cras ornare arcu. Auctor neque vitae tempus quam pellentesque nec. At ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget. Dolor sit amet consectetur adipiscing elit. Facilisis magna etiam tempor orci. Quam viverra orci sagittis eu. Consectetur adipiscing elit duis tristique sollicitudin nibh. Mi ipsum faucibus vitae aliquet nec ullamcorper. Tempor orci dapibus ultrices in iaculis nunc sed augue. Posuere lorem ipsum dolor sit. Nam aliquam sem et tortor consequat. Venenatis cras sed felis eget velit aliquet."
            },
            autoSave: true
        );

        var contentDto = new InsertOrUpdateContentInputDto()
        {
            Id = contentDb.Id,
            Name = "Teste",
            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
        };

        var content = await _appService.InsertOrUpdateCMSContent(contentDto);

        content.ShouldNotBeNull();

        Assert.Equal("Teste", content.Name);
        Assert.Equal("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", content.Content);
    }

    [Fact]
    public async Task ShouldNotUpdateContent()
    {
        var contentDb = await _contentPageRepository.InsertAsync(new()
        {
            Name = "Content Test",
            Content = "Ut eu sem integer vitae justo eget magna. Tempus quam pellentesque nec nam aliquam sem et. Rhoncus est pellentesque elit ullamcorper dignissim cras tincidunt. Ultrices vitae auctor eu augue ut. Vulputate eu scelerisque felis imperdiet proin fermentum. Nibh nisl condimentum id venenatis a condimentum vitae sapien pellentesque. Nunc sed blandit libero volutpat sed cras ornare arcu. Auctor neque vitae tempus quam pellentesque nec. At ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget. Dolor sit amet consectetur adipiscing elit. Facilisis magna etiam tempor orci. Quam viverra orci sagittis eu. Consectetur adipiscing elit duis tristique sollicitudin nibh. Mi ipsum faucibus vitae aliquet nec ullamcorper. Tempor orci dapibus ultrices in iaculis nunc sed augue. Posuere lorem ipsum dolor sit. Nam aliquam sem et tortor consequat. Venenatis cras sed felis eget velit aliquet."
        },
            autoSave: true
        );

        var contentDto = new InsertOrUpdateContentInputDto()
        {
            Id = contentDb.Id,
            Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad ",
            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
        };

        await Assert.ThrowsAnyAsync<Exception>(async() =>await _appService.InsertOrUpdateCMSContent(contentDto));
    }

    [Fact]
    public async Task ShouldNotInsertContent()
    {
        var contentDto = new InsertOrUpdateContentInputDto()
        {
            Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad ",
            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
        };

        await Assert.ThrowsAnyAsync<Exception>(async () => await _appService.InsertOrUpdateCMSContent(contentDto));
    }


    [Fact]
    public async Task ShouldGetContent()
    {
        var contentDb = await _contentPageRepository.InsertAsync(new()
            {
                Name = "Content Test",
                Content = "Ut eu sem integer vitae justo eget magna. Tempus quam pellentesque nec nam aliquam sem et. Rhoncus est pellentesque elit ullamcorper dignissim cras tincidunt. Ultrices vitae auctor eu augue ut. Vulputate eu scelerisque felis imperdiet proin fermentum. Nibh nisl condimentum id venenatis a condimentum vitae sapien pellentesque. Nunc sed blandit libero volutpat sed cras ornare arcu. Auctor neque vitae tempus quam pellentesque nec. At ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget. Dolor sit amet consectetur adipiscing elit. Facilisis magna etiam tempor orci. Quam viverra orci sagittis eu. Consectetur adipiscing elit duis tristique sollicitudin nibh. Mi ipsum faucibus vitae aliquet nec ullamcorper. Tempor orci dapibus ultrices in iaculis nunc sed augue. Posuere lorem ipsum dolor sit. Nam aliquam sem et tortor consequat. Venenatis cras sed felis eget velit aliquet."
            }, autoSave: true
        );

        var content = await _appService.GetCMSContent(contentDb.Id);

        content.ShouldNotBeNull();
    }

    [Fact]
    public async Task ShouldNotGetContent()
    {
        await Assert.ThrowsAnyAsync<Exception>(async () => await _appService.GetCMSContent(10293098));
    }


    [Fact]
    public async Task ShouldGetListContent()
    {
        List<ContentPage> contentPages =
        [
            new()
            {
                Name = "Content Test 1",
                Content = "Ut eu sem integer vitae justo eget magna. Tempus quam pellentesque nec nam aliquam sem et. Rhoncus est pellentesque elit ullamcorper dignissim cras tincidunt. Ultrices vitae auctor eu augue ut. Vulputate eu scelerisque felis imperdiet proin fermentum. Nibh nisl condimentum id venenatis a condimentum vitae sapien pellentesque. Nunc sed blandit libero volutpat"
            },
            new()
            {
                Name = "Content Test 2",
                Content = "Ut eu sem integer vitae justo eget magna. Tempus quam pellentesque nec nam aliquam sem et. Rhoncus est pellentesque elit ullamcorper dignissim cras tincidunt. Ultrices vitae auctor eu augue ut. Vulputate eu scelerisque felis imperdiet proin fermentum. Nibh nisl condimentum id venenatis a condimentum vitae sapien pellentesque. Nunc sed blandit libero volutpat"
            },
            new()
            {
                Name = "Content Test 3",
                Content = "Ut eu sem integer vitae justo eget magna. Tempus quam pellentesque nec nam aliquam sem et. Rhoncus est pellentesque elit ullamcorper dignissim cras tincidunt. Ultrices vitae auctor eu augue ut. Vulputate eu scelerisque felis imperdiet proin fermentum. Nibh nisl condimentum id venenatis a condimentum vitae sapien pellentesque. Nunc sed blandit libero volutpat"
            },
        ];

        await _contentPageRepository.InsertManyAsync(contentPages);

        var contents = await _appService.GetAll(new());
        contents.Items.ShouldNotBeNull();
    }
}
