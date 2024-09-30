using Core.Infrastructure.Configuration;
using Microsoft.Playwright;

namespace Core.Web.WebDriver
{
    public class PlaywrightDriver
    {
        public LaunchConfiguration LaunchConfiguration;

        public PlaywrightConfigurations PlayWriteConfigurations;

        public IBrowser Browser;

        public IBrowserContext Context;

        public IPage Page;

        public PlaywrightDriver(LaunchConfiguration launchConfiguration, PlaywrightConfigurations playWriteConfigurations)
        {
            PlayWriteConfigurations = playWriteConfigurations;

            LaunchConfiguration = launchConfiguration;
        }

        public async Task DriverInitializeAsync()
        {
            Browser = await InitializeBrowserAsync();
            Context = await CreateBrowserContextAsync();
            Page = await CreatePageAsync();
        }

        public async Task<IBrowser> InitializeBrowserAsync()
        {
            return await PlayWriteConfigurations.GetBrowserAsync();
        }

        public async Task<IBrowserContext> CreateBrowserContextAsync()
        {
            return await Browser.NewContextAsync();
        }

        public async Task<IPage> CreatePageAsync()
        {
            return await Context.NewPageAsync();
        }
    }
}
