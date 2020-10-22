using Automation.WebDriverHelper;
using OpenQA.Selenium;

namespace WebDriverHelper.Pages
{
    public class ShopPage
    {

        public ShopPage(WebDriverContext webDriverContext)
        {
            this.WebDriverContext = webDriverContext;
        }

        /// <summary>
        /// Gets the webdriver context.
        /// </summary>
        public WebDriverContext WebDriverContext { get; }

        private IWebElement searchhBar => this.WebDriverContext.WebDriver.FindElement(By.XPath(".//*[@id='search_query_top']"));
        private IWebElement pagination => this.WebDriverContext.WebDriver.FindElement(By.XPath(".//*[@id='pagination']"));

        public void SetSearchOption(string option)
        {
            this.searchhBar.SendKeys(option);
        }


        public string GetPaginationText()
        {
            return this.pagination.Text;
        }
    }
}
