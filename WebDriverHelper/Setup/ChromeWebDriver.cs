// <copyright file="ChromeWebDriver.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Automation.WebDriverHelper
{
    using System;
    using DataFactory.Configuration;
    using global::WebDriverHelper.Setup;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    /// <summary>
    /// The browser web driver chrome.
    /// </summary>
    public static class ChromeWebDriver
    {
        /// <summary>
        /// Creates the new web driver.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The webdriver.</returns>
        public static IWebDriver CreateNewWebDriver(IWritableOptions<ConfigurationParameters> options)
        {
            return CreateWebDriver(options);
        }

        /// <summary>
        /// Creates the reusable web driver.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The webdriver.</returns>
        public static IWebDriver CreateReusableWebDriver(IWritableOptions<ConfigurationParameters> options)
        {
            var sessionId = options?.Value.BrowsersConfiguration.SessionId;
            var url = options.Value.BrowsersConfiguration.WebDriverUrl;

            if (sessionId != null && url != null)
            {
                return new ReuseRemoteWebDriver(
                   url,
                   sessionId,
                   CreateChromeOptions());
            }

            var driver = CreateWebDriver(options);
            options.Update(opt => opt.BrowsersConfiguration.SessionId = driver.SessionId.ToString());
            options.Update(opt => opt.BrowsersConfiguration.WebDriverUrl = ReuseRemoteWebDriver.GetExecutorURLFromDriver(driver));
            return driver;
        }

        /// <summary>
        /// Creates the web driver.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The webdriver.</returns>
        public static ChromeDriver CreateWebDriver(IWritableOptions<ConfigurationParameters> options)
        {
            var driver = new ChromeDriver(
            ChromeDriverService.CreateDefaultService(options?.Value.BrowsersConfiguration.ChromeDriverPath),
            CreateChromeOptions(),
            TimeSpan.FromSeconds(options.Value.BrowsersConfiguration.CommandTimeout));
            options.Value.BrowsersConfiguration.SessionId = driver.SessionId.ToString();
            options.Value.BrowsersConfiguration.WebDriverUrl = ReuseRemoteWebDriver.GetExecutorURLFromDriver(driver);

            return driver;
        }

        /// <summary>
        /// Creates the chrome options.
        /// </summary>
        /// <returns>The chrome options.</returns>
        private static ChromeOptions CreateChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", "DownloadPath");
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArguments("disable-infobars");

            return chromeOptions;
        }
    }
}