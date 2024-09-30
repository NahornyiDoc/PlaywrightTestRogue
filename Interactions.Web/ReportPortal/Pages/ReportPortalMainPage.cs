using Microsoft.Playwright;

namespace Interactions.Web.ReportPortal.Pages
{
    public class ReportPortalMainPage
    {
        private IPage _page { get; set; }

        private ILocator LearnButton => _page.Locator("//button[text()='Learn']");

        private ILocator DocumentationLink => _page.Locator("//p[text()='Documentation']/ancestor::a");

        private ILocator GetQuoteButton => _page.Locator("//a[@data-gtm='get_a_quote_header']");

        public ReportPortalMainPage(IPage page)
        {
            _page = page;
        }

        public async Task ClickLearnButtonAsync()
        {
            await LearnButton.HoverAsync();
            await LearnButton.ClickAsync();
        }

        public async Task<IPage> ClickDocumentationLinkAsync()
        {
            var newPageTask = await _page.RunAndWaitForPopupAsync(async () =>
            {
                await DocumentationLink.WaitForAsync();

                await DocumentationLink.ClickAsync();
            });

            return newPageTask;
        }

        public async Task ClickGetQuote()
        {
            await GetQuoteButton.ClickAsync();
        }
    }
}
