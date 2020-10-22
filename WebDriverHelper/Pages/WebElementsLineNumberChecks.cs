// <copyright file="WebElementsLineNumberChecks.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace WebDriverHelper.Pages
{
    using Automation.WebDriverHelper;
    using OpenQA.Selenium;
    using WebDriverHelper.Extensions;

    /// <summary>
    /// The webelements line number checks.
    /// </summary>
    public class WebElementsLineNumberChecks
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebElementsLineNumberChecks"/> class.
        /// </summary>
        /// <param name="webDriverContext">The webdriver context.</param>
        public WebElementsLineNumberChecks(WebDriverContext webDriverContext)
        {
            this.WebDriverContext = webDriverContext;
        }

        /// <summary>
        /// Gets the webdriver context.
        /// </summary>
        public WebDriverContext WebDriverContext { get; }

        private IWebElement FirstParagraph => this.WebDriverContext.WebDriver.FindElement(By.XPath("(.//*[@class='large-10 columns'])[1]"));

        /// <summary>
        /// The get first paragraph line number.
        /// </summary>
        /// <returns>The number of lines of the first paragraph.</returns>
        public int GetFirstParagraphLineNumber()
        {
            return this.FirstParagraph.GetElementLineNumbers();
        }
    }
}
