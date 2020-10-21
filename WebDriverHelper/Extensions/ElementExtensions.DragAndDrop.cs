namespace Automation.Core.WebDriver.Extensions
{
    using System;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    /// <summary>
    /// The element extensions.
    /// </summary>
    public static partial class ElementExtensions
    {
        /// <summary>
        /// Drags the and drop to offset.
        /// </summary>
        /// <param name="webElement">The web element.</param>
        /// <param name="positionX">The position x.</param>
        /// <param name="positionY">The position y.</param>
        /// <exception cref="Exception">Element Not Moved.</exception>
        public static void DragAndDropToOffset(this IWebElement webElement, int positionX, int positionY)
        {
            var action = new Actions(webElement.GetWebDriver());
            action.DragAndDropToOffset(webElement, positionX, positionY).Build().Perform();
        }

        /// <summary>
        /// Drags the into element.
        /// </summary>
        /// <param name="webElement">The web element.</param>
        /// <param name="targetWebElement">The target web element.</param>
        /// <exception cref="Exception">Element Not Moved.</exception>
        public static void DragIntoElement(this IWebElement webElement, IWebElement targetWebElement)
        {
            var action = new Actions(webElement.GetWebDriver());
            var webElementLocationBeforeMoving = webElement?.Location;
            action.DragAndDrop(webElement, targetWebElement).Build().Perform();

            Thread.Sleep(1000);

            var webElementLocationAfterMoving = webElement.Location;

            if (webElementLocationBeforeMoving == webElementLocationAfterMoving)
            {
                throw new Exception("Element Not Moved");
            }
        }

        /// <summary>
        /// Drags the and drop in three actions.
        /// </summary>
        /// <param name="webElement">The web element.</param>
        /// <param name="targetWebElement">The target web element.</param>
        /// <exception cref="Exception">Element Not Moved.</exception>
        public static void DragAndDropInThreeActions(this IWebElement webElement, IWebElement targetWebElement)
        {
            var driver = GetWebDriver(webElement);
            var action = new Actions(driver);
            var webElementLocationBeforeMoving = webElement?.Location;

            action.ClickAndHold(webElement).Build().Perform();
            action.MoveToElement(targetWebElement).Build().Perform();
            action.Release(targetWebElement).Build().Perform();

            var webElementLocationAfterMoving = webElement.Location;

            if (webElementLocationBeforeMoving == webElementLocationAfterMoving)
            {
                throw new Exception("Element Not Moved");
            }
        }
    }
}
