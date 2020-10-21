// <copyright file="FirefoxWebDriver.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Automation.WebDriverHelper
{
    using System;
    using System.Text;
    using DataFactory.Configuration;
    using global::WebDriverHelper.Setup;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    /// <summary>
    /// The browser web driver firefox.
    /// </summary>
    public static class FirefoxWebDriver
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
        /// <returns>The webdriver options.</returns>
        public static IWebDriver CreateReusableWebDriver(IWritableOptions<ConfigurationParameters> options)
        {
            var sessionId = options?.Value.BrowsersConfiguration.SessionId;
            var url = options.Value.BrowsersConfiguration.WebDriverUrl;

            if (sessionId != null && url != null)
            {
                return new ReuseRemoteWebDriver(
                   url,
                   sessionId,
                   CreateFirefoxOptions(options));
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
        public static FirefoxDriver CreateWebDriver(IWritableOptions<ConfigurationParameters> options)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var driver = new FirefoxDriver(
            FirefoxDriverService.CreateDefaultService(options?.Value.BrowsersConfiguration.FirefoxDriverPath),
            CreateFirefoxOptions(options),
            TimeSpan.FromSeconds(options.Value.BrowsersConfiguration.CommandTimeout));

            return driver;
        }

        /// <summary>
        /// Creates the firefox options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The firefox options.</returns>
        private static FirefoxOptions CreateFirefoxOptions(IWritableOptions<ConfigurationParameters> options)
        {
            var firefoxOptions = new FirefoxOptions
            {
                Profile = CreateFirefoxProfile(options),
            };
            return firefoxOptions;
        }

        /// <summary>
        /// Creates the firefox profile.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The firefox profile.</returns>
        private static FirefoxProfile CreateFirefoxProfile(IWritableOptions<ConfigurationParameters> options)
        {
            // Configure the profile
            var firefoxProfile = new FirefoxProfile();

            // Configure the url with which the browser start
            firefoxProfile.SetPreference("browser.startup.homepage", "about:blank");
            firefoxProfile.SetPreference("startup.homepage_welcome_url", "about:blank");
            firefoxProfile.SetPreference("startup.homepage_welcome_url.additional", "about:blank");
            firefoxProfile.SetPreference("browser.startup.homepage_override.mstone", "ignore");

            firefoxProfile.SetPreference("browser.download.dir", @"C:\GIT\Downloads");
            firefoxProfile.SetPreference("browser.download.folderList", 1);
            firefoxProfile.SetPreference("browser.download.pannel.show", true);
            firefoxProfile.SetPreference("browser.download.useDownloadDir", false);

            // Set the binary path
            firefoxProfile.SetPreference(
                "webdriver.firefox.bin",
                options.Value.BrowsersConfiguration.FirefoxBinaryPath);

            return firefoxProfile;
        }
    }
}