using FluentAssertions;
using Microsoft.Playwright;

namespace Interactions.Web.ReportPortal.Pages
{
    public class DocumentationPage
    {
        private IPage _page { get; set; }

        private ILocator Heading => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "What is ReportPortal?" });

        public DocumentationPage(IPage page)
        {
            _page = page;
        }

        public async Task VerifyIsDocumentationPageOpened()
        {
            await Heading.WaitForAsync();

            var isHeadingVisible = await Heading.IsVisibleAsync();

            isHeadingVisible.Should().BeTrue("");
        }
    }
}
