using Microsoft.Playwright;
using static Core.Web.WebDriver.PlaywrightDriver;


namespace Interactions.Web.SiteNavigations
{
    public class Navigation
    {
        private IPage _page;

        public Navigation(IPage page)
        {
            _page = page;
        }
        public async Task OpenReportPortal()
        {
            await _page.GotoAsync("https://reportportal.io/", new PageGotoOptions
            {
                Timeout = 60000,
                WaitUntil = WaitUntilState.Load
            });
        }
    }
}
