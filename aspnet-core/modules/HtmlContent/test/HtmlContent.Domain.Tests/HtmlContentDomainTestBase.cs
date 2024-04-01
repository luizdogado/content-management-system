using Volo.Abp.Modularity;

namespace HtmlContent;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class HtmlContentDomainTestBase<TStartupModule> : HtmlContentTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
