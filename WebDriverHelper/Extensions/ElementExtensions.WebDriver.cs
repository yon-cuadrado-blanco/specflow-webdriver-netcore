namespace Automation.Core.WebDriver.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    /// <summary>
    /// The element extensions class.
    /// </summary>
    public static partial class ElementExtensions
    {
        /// <summary>
        /// The get webdriver function.
        /// </summary>
        /// <param name="webElement">The webelement.</param>
        /// <returns>The webdriver element.</returns>
        public static IWebDriver GetWebDriver(this IWebElement webElement)
        {
            var realElement = webElement is IWrapsElement element ? element.WrappedElement : webElement;
            return ((IWrapsDriver)realElement)?.WrappedDriver;
        }

        /// <summary>
        /// The execute javascript function.
        /// </summary>
        /// <param name="webDriver">The webdriver.</param>
        /// <param name="script">The script.</param>
        /// <param name="args">The args.</param>
        /// <returns>The result of the execution of the script.</returns>
        public static dynamic ExecuteJavaScript(this IWebDriver webDriver, string script, params object[] args)
        {
            var javascriptExecutor = (IJavaScriptExecutor)webDriver;
            return javascriptExecutor?.ExecuteScript(script, args);
        }
    }
}
