// <copyright file="IEWebDriver.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Automation.WebDriverHelper
{
    using System;
    using System.Diagnostics;
    using DataFactory.Configuration;
    using global::WebDriverHelper.Setup;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;

    /// <summary>
    /// The browser web driver IE.
    /// </summary>
    public static class IeWebdriver
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
            CloseIEWebDriver();
            var sessionId = options?.Value.BrowsersConfiguration.SessionId;
            var url = options?.Value.BrowsersConfiguration.WebDriverUrl;

            if (sessionId != null && url != null)
            {
                return new ReuseRemoteWebDriver(
                   url,
                   sessionId,
                   CreateIeOPtions());
            }

            var driver = CreateWebDriver(options);
            options.Value.BrowsersConfiguration.SessionId = driver.SessionId.ToString();
            options.Value.BrowsersConfiguration.WebDriverUrl = ReuseRemoteWebDriver.GetExecutorURLFromDriver(driver);
            return driver;
        }

        /// <summary>
        /// Creates the web driver.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The webdriver.</returns>
        public static InternetExplorerDriver CreateWebDriver(IWritableOptions<ConfigurationParameters> options)
        {
            CloseIEWebDriver();
            var driver = new InternetExplorerDriver(
            InternetExplorerDriverService.CreateDefaultService(options?.Value.BrowsersConfiguration.IeDriverPath),
            CreateIeOPtions(),
            TimeSpan.FromSeconds(options.Value.BrowsersConfiguration.CommandTimeout));

            return driver;
        }

        /// <summary>
        /// Creates the internet explorer options.
        /// </summary>
        /// <returns>The internet explorer options.</returns>
        private static InternetExplorerOptions CreateIeOPtions()
        {
            // Configure the profile
            return new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true,
                ForceCreateProcessApi = true,
                EnsureCleanSession = true,
                RequireWindowFocus = true,
                EnablePersistentHover = false,
                BrowserCommandLineArguments = "-private",
            };
        }

        private static void CloseIEWebDriver()
        {
            foreach (var proc in Process.GetProcessesByName("IEDriverServer"))
            {
                proc.Kill();
            }
        }
    }
}