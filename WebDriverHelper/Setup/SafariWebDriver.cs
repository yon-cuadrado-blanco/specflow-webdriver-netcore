// <copyright file="SafariWebDriver.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Automation.WebDriverHelper
{
    using System;
    using System.Reflection;
    using DataFactory.Configuration;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// The IOS Web Driver class.
    /// </summary>
    public static class SafariWebDriver
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
        /// Creates the web driver.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The webdriver.</returns>
        public static IWebDriver CreateWebDriver(IWritableOptions<ConfigurationParameters> options)
        {
            var driver = new RemoteWebDriver(
                new Uri("http://127.0.0.1:4723/wd/hub"),
                CreateAppiumOptions(options).ToCapabilities(),
                TimeSpan.FromSeconds(120));
            return driver;
        }

        /// <summary>
        /// Creates the appium options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The appium options.</returns>
        public static AppiumOptions CreateAppiumOptions(IWritableOptions<ConfigurationParameters> options)
        {
            var appiumOptions = new AppiumOptions();
            foreach (PropertyInfo prop in options?.Value.DeviceSettings.Ios12.Capabilities.GetType().GetProperties())
            {
                var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                var value = prop.GetValue(options?.Value.DeviceSettings.Ios12.Capabilities, null);
                appiumOptions.AddAdditionalCapability(prop.Name, value);
            }

            return appiumOptions;
        }
    }
}
