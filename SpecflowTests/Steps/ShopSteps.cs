using BoDi;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using WebDriverHelper.Pages;

namespace SpecflowTests.shopSteps
{
    [Binding]
    public class ShopSteps : Steps
    {
        private readonly ShopPage shopPage;

        public ShopSteps(IContextManager contextManager)
        {
            var objectContainer = contextManager?.TestThreadContext.Get<IObjectContainer>("objectContainer");
            this.shopPage = contextManager?.TestThreadContext.Get<IObjectContainer>("objectContainer")?.Resolve<ShopPage>();
        }

        [When(@"When I type the text '(.*)'")]
        public void WhenWhenITypeTheText(string typedText)
        {
            shopPage.SetSearchOption(typedText);
        }

        [Then(@"The application shows the text '(.*)'")]
        public void ThenTheApplicationShowsTheText(string expectedText)
        {
            shopPage.GetPaginationText().Should().Be("");
        }

    }
}
