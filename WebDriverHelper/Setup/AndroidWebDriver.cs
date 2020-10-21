//-------------------------------------------------------------------------------------------------
// <copyright file="AndroidWebDriver.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>
//-------------------------------------------------------------------------------------------------

namespace Automation.WebDriverHelper
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using DataFactory.Configuration;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Service;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Android webDriver.
    /// </summary>
    public static class AndroidWebDriver
    {
        /// <summary>
        /// The start appium.
        /// </summary>
        /// <returns>The appium process.</returns>
        public static Process StartAppium()
        {
            Process process = new System.Diagnostics.Process();
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                FileName = @"C:\Users\jontxo\AppData\Roaming\npm\appium.cmd",
            };
            process.StartInfo = startInfo;
            process.Start();
            return process;
        }

        /// <summary>
        /// Create and appium local service.
        /// </summary>
        /// <returns>An appium local service.</returns>
        public static AppiumLocalService CreateAppiumLocalService()
        {
            return new AppiumServiceBuilder().UsingPort(4723).Build();
        }

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
            foreach (PropertyInfo prop in options?.Value.DeviceSettings.Android8.Capabilities.GetType().GetProperties())
            {
                var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                var value = prop.GetValue(options?.Value.DeviceSettings.Android8.Capabilities, null);
                appiumOptions.AddAdditionalCapability(prop.Name, value);
            }

            return appiumOptions;
        }
    }
}