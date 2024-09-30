using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace Interactions.Web.ReportPortal.Pages
{
    public class ContactUsPage
    {
        private IPage _page { get; set; }

        private ILocator FirsNameInput => _page.GetByLabel("First name");

        private ILocator LastNameInput => _page.GetByLabel("Last name");

        private ILocator EmailInput => _page.GetByLabel("Email");

        private ILocator CompanyNameInput => _page.GetByLabel("Company name");

        private ILocator SubscribeNewsletterCheckbox => _page.Locator("//*[@id='wouldLikeToReceiveAds']/../div[@class='custom-checkbox__checkmark']");

        private ILocator TermsAgreeCheckbox => _page.Locator("//*[@id='termsAgree']/../div[@class='custom-checkbox__checkmark']");

        private ILocator SubmitButton => _page.GetByRole(AriaRole.Button, new() { Name = "Send request" });

        public ContactUsPage(IPage page)
        {
            _page = page;
        }

        public async Task FillInputAsync(ILocator input, string value)
        {
            await input.FillAsync(value);
        }

        public async Task CheckSubscribeNewsletterCheckbox()
        {
            await SubscribeNewsletterCheckbox.CheckAsync();
        }

        public async Task CheckTermsAgreeCheckbox()
        {
            await TermsAgreeCheckbox.CheckAsync();
        }

        public async Task ClickSubmitButton()
        {
            await SubmitButton.ClickAsync();
        }

        public async Task EnterContactUsForm()
        {
            await FillInputAsync(FirsNameInput, "John");
            await FillInputAsync(LastNameInput, "Wik");
            await FillInputAsync(EmailInput, "Asdafsfa@gmail.com");
            await FillInputAsync(CompanyNameInput, "Boogeyman");

            await CheckSubscribeNewsletterCheckbox();
            await CheckTermsAgreeCheckbox();

            await ClickSubmitButton();
        }
    }
}
