// <copyright file="DragAndDropPage.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Automation.Pages
{
    using Automation.Core.WebDriver.Extensions;
    using Automation.WebDriverHelper;
    using OpenQA.Selenium;

    /// <summary>
    /// The drag and drop page.
    /// </summary>
    public class DragAndDropPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DragAndDropPage"/> class.
        /// </summary>
        /// <param name="webDriverContext">The web driver context.</param>
        public DragAndDropPage(WebDriverContext webDriverContext)
        {
            this.WebDriverContext = webDriverContext;
        }

        /// <summary>
        /// Gets the webdriver context.
        /// </summary>
        public WebDriverContext WebDriverContext { get; }

        /// <summary>
        /// Gets the web element High TATRAS.
        /// </summary>
        private IWebElement HighTatras => this.WebDriverContext.WebDriver.FindElement(By.XPath(".//*[contains(text(),'High Tatras') and not(contains(text(),'High Tatras '))]/../img"));

        /// <summary>
        /// Gets the web element High TATRAS.
        /// </summary>
        private IWebElement HighTatras2 => this.WebDriverContext.WebDriver.FindElement(By.XPath(".//*[contains(text(),'High Tatras 2')]"));

        /// <summary>
        /// Gets the web element trash.
        /// </summary>
        private IWebElement Trash => this.WebDriverContext.WebDriver.FindElement(By.XPath(".//*[@id='trash']"));

        /// <summary>
        /// Gets the drag and drop to position tab.
        /// </summary>
        private IWebElement DragAndDropToPositionTab => this.WebDriverContext.WebDriver.FindElement(By.XPath(".//*[@id='Accepted Elements']"));

        /// <summary>
        /// Gets the DRAGGABLE and sortable.
        /// </summary>
        private IWebElement DragMeAround => this.WebDriverContext.WebDriver.FindElement(By.XPath(".//*[@class='inside_contain']/div[@id='draggable']"));

        /// <summary>
        /// Gets the drag and drop frame.
        /// </summary>
        private IWebElement DragAndDropFrame => this.WebDriverContext.WebDriver.FindElement(By.XPath(".//*[@class='demo-frame lazyloaded']"));

        /// <summary>
        /// Drags the element and drop to another element.
        /// </summary>
        /// <param name="element1Name">Name of the element1.</param>
        /// <param name="element2Name">Name of the element2.</param>
        public void DragElementAndDropToAnotherElement(string element1Name, string element2Name)
        {
            this.WebDriverContext.WebDriver.SwitchTo().Frame(this.DragAndDropFrame);
            var element1 = this.GetFieldValue<IWebElement>(element1Name);
            var element2 = this.GetFieldValue<IWebElement>(element2Name);
            element1.DragIntoElement(element2);
            this.WebDriverContext.WebDriver.SwitchTo().DefaultContent();
        }

        /// <summary>
        /// Drags the and drop to offset.
        /// </summary>
        /// <param name="webElementName">Name of the web element.</param>
        /// <param name="positionX">The position x.</param>
        /// <param name="positionY">The position y.</param>
        public void DragAndDropToOffset(string webElementName, int positionX, int positionY)
        {
            this.WebDriverContext.WebDriver.SwitchTo().Frame(this.DragAndDropFrame);
            var element = this.GetFieldValue<IWebElement>(webElementName);
            element.DragAndDropToOffset(positionX, positionY);
            this.WebDriverContext.WebDriver.SwitchTo().DefaultContent();
        }

        /// <summary>
        /// The click on DRAGGABLE and sortable button.
        /// </summary>
        public void ClickOnDraggableAndSortableButton()
        {
            this.DragAndDropToPositionTab.Click();
        }

        /// <summary>
        /// Clicks the on accepted elements tab.
        /// </summary>
        public void ClickOnAcceptedElementsTab()
        {
            this.DragAndDropToPositionTab.Click();
        }
    }
}