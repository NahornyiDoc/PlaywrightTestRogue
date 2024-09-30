using Core.Web;
using Interactions.Web.ReportPortal.Pages;
using Interactions.Web.SiteNavigations;

namespace Tests.Web.ReportPortal.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ReportPortalSmokeTestFixture : BaseWebTestFixture
    {
        [Test]
        public async Task DocumentationPageOpenedTest()
        {
            var page = Driver.Page;

            var navigation = new Navigation(page);

            await navigation.OpenReportPortal();

            var _reportPortalMainPage = new ReportPortalMainPage(page);

            await _reportPortalMainPage.ClickLearnButtonAsync();

            var newDocumentationPage = await _reportPortalMainPage.ClickDocumentationLinkAsync();

            var documentationPage = new DocumentationPage(newDocumentationPage);

            await documentationPage.VerifyIsDocumentationPageOpened();
        }

        [Test]

        public async Task ContactUsTest()
        {
            var page = Driver.Page;

            var navigation = new Navigation(page);

            await navigation.OpenReportPortal();

            var reportPortalMainPage = new ReportPortalMainPage(page);

            await reportPortalMainPage.ClickGetQuote();

            var contactUsPage = new ContactUsPage(page);

            await contactUsPage.EnterContactUsForm();
        }
    }
}