// <copyright file="WebElementColorsCheckPage.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Automation.Pages
{
    using System;
    using System.Globalization;
    using Automation.Core.WebDriver.Extensions;
    using Automation.WebDriverHelper;
    using DataFactory.Configuration;
    using global::WebDriverHelper.Extensions;
    using OpenQA.Selenium;

    /// <summary>
    /// The WebElement Checks page.
    /// </summary>
    public class WebElementColorsCheckPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebElementColorsCheckPage"/> class.
        /// </summary>
        /// <param name="webDriverContext">The web driver context.</param>
        public WebElementColorsCheckPage(WebDriverContext webDriverContext)
        {
            this.WebDriverContext = webDriverContext;
        }

        /// <summary>
        /// Gets the webdriver context.
        /// </summary>
        public WebDriverContext WebDriverContext { get; }

        /// <summary>
        /// Gets the foo button.
        /// </summary>
        private IWebElement FooButton => this.WebDriverContext.WebDriver.FindElement(By.XPath(".//*[@id='form_submit']"));

        /// <summary>
        /// Gets the color of the button background.
        /// </summary>
        /// <returns>The background color of the blue element.</returns>
        public string GetButtonBackgroundColor()
        {
            var color = this.FooButton.GetBackgroundColor().ToColor().GetHexColor();
            return GetColor(color);
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The color converted.</returns>
        /// <exception cref="Exception">Unexpected Case.</exception>
        private static string GetColor(string color)
        {
            switch (color.ToUpper(new CultureInfo("es-ES", false)))
            {
                case Constants.RedHexValue:
                    {
                        return "RED";
                    }

                case Constants.BlueHexValue:
                    {
                        return "BLUE";
                    }

                default:
                    throw new Exception("Unexpected Case");
            }
        }
    }
}