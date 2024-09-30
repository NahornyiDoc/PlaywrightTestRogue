using Core.Infrastructure.Configuration;
using Core.Web.WebDriver;
using NUnit.Framework;
using OCM.Core.Autofac;

namespace Core.Web
{
    public class BaseWebTestFixture
    {
        [ThreadStatic]
        public static PlaywrightDriver Driver;

        public LaunchConfiguration launchConfiguration { get; set; }
        public PlaywrightConfigurations playwrightConfigurations { get; set; }

        public BaseWebTestFixture()
        {
            launchConfiguration = AppContainer.Resolve<LaunchConfiguration>();

            playwrightConfigurations = AppContainer.Resolve<PlaywrightConfigurations>();
        }

        [SetUp]
        public async Task SetUp()
        {
            Driver = new PlaywrightDriver(launchConfiguration, playwrightConfigurations);

            await Driver.DriverInitializeAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await Driver.Context.CloseAsync();

            if (Driver?.Browser != null)
                await Driver.Browser.CloseAsync();
        }
    }
}
