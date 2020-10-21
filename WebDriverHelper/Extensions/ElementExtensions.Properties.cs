namespace WebDriverHelper.Extensions
{
    using System;
    using System.Globalization;
    using Automation.Core.WebDriver.Extensions;
    using OpenQA.Selenium;

    /// <summary>
    /// The element extions class.
    /// </summary>
    public static partial class ElementExtensions
    {
        /// <summary>
        /// The get background color.
        /// </summary>
        /// <param name="element">The webelement.</param>
        /// <returns>The background color.</returns>
        public static string GetBackgroundColor(this IWebElement element)
        {
            return element.GetWebDriver().ExecuteJavaScript("return window.getComputedStyle(arguments[0], null).getPropertyValue('background-color')", element);
        }

        /// <summary>
        /// The get the elemennt line numbers.
        /// </summary>
        /// <param name="element">The webelement.</param>
        /// <returns>The line numbers of the webelement.</returns>
        public static int GetElementLineNumbers(this IWebElement element)
        {
            const string lineHeightProperty = "var lineHeightProperty = window.getComputedStyle? window.getComputedStyle(arguments[0],null).getPropertyValue('line-height') : arguments[0].style.lineHeight; ";
            const string lineHeightCalculated = "clone = arguments[0].cloneNode(); " +
             "clone.innerHTML = '<br>';" +
             "clone.style.visibility = 'hidden';" +
             "arguments[0].appendChild(clone); " +
             "singleLineHeight = clone.offsetHeight;" +
             "clone.innerHTML = '<br><br>';" +
             "doubleLineHeight = clone.offsetHeight; " +
             "arguments[0].removeChild(clone);" +
             "var lineHeightCalculated = doubleLineHeight - singleLineHeight; ";
            const string lineHeight = lineHeightProperty + lineHeightCalculated + "var lineHeight = isNaN(lineHeightProperty) ? lineHeightCalculated: lineHeightProperty; ";
            const string offsetHeight = "offsetHeight = arguments[0].offsetHeight; ";
            const string marginTop = " marginTop = parseInt(window.getComputedStyle ? window.getComputedStyle(arguments[0], null).getPropertyValue('margin-top') : arguments[0].style.margingTop); ";
            const string marginBottom = " marginBottom = parseInt(window.getComputedStyle ? window.getComputedStyle(arguments[0], null).getPropertyValue('margin-bottom') : arguments[0].style.margingBottom); ";
            const string elementHeight = offsetHeight + marginTop + marginBottom + " elementHeight = offsetHeight + marginTop + marginBottom;";
            const string script = elementHeight + lineHeight + "return elementHeight / lineHeight; ";
            var lineNumber = element.GetWebDriver().ExecuteJavaScript(script, element);
            return Convert.ToInt32(lineNumber, new CultureInfo("es-ES"));
        }
    }
}
