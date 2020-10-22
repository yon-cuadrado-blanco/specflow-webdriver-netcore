// <copyright file="ConfigurationParameters.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace DataFactory.Configuration
{
    using System;

    /// <summary>
    /// The configuration parameters.
    /// </summary>
    public class ConfigurationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationParameters"/> class.
        /// </summary>
        public ConfigurationParameters()
        {
            this.GeneralParameters = new GeneralParameters();

            this.BrowsersConfiguration = new BrowsersConfiguration();

            this.UrlParameters = new UrlParameters();
        }

        /// <summary>
        /// Gets or sets the general parameters.
        /// </summary>
        public GeneralParameters GeneralParameters { get; set; }

        /// <summary>
        /// Gets or sets the browser configuration.
        /// </summary>
        public BrowsersConfiguration BrowsersConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the url parameters.
        /// </summary>
        public UrlParameters UrlParameters { get; set; }

        /// <summary>
        /// Gets or sets the device settings.
        /// </summary>
        public DeviceSettings DeviceSettings { get; set; }
    }

    /// <summary>
    /// The browser configuration.
    /// </summary>
    public class BrowsersConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowsersConfiguration"/> class.
        /// </summary>
        public BrowsersConfiguration()
        {
        }

        /// <summary>
        /// Gets or sets the browser.
        /// </summary>
        public Browser Browser { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [reuse browser].
        /// </summary>
        public bool ReuseBrowser { get; set; }

        /// <summary>
        /// Gets or sets the page load timeout.
        /// </summary>
        public int PageLoadTimeout { get; set; }

        /// <summary>
        /// Gets or sets the asynchronous javascript timeout.
        /// </summary>
        public int AsynchronousJavascriptTimeout { get; set; }

        /// <summary>
        /// Gets or sets the implicit wait timeout.
        /// </summary>
        public int ImplicitWaitTimeout { get; set; }

        /// <summary>
        /// Gets or sets the chrome browser command timeout.
        /// </summary>
        public int CommandTimeout { get; set; }

        /// <summary>
        /// Gets or sets the chrome session identifier.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the chrome URL.
        /// </summary>
        public Uri WebDriverUrl { get; set; }

        /// <summary>
        /// Gets or sets the chrome driver path.
        /// </summary>
        public string ChromeDriverPath { get; set; }

        /// <summary>
        /// Gets or sets the firefox driver path.
        /// </summary>
        public string FirefoxDriverPath { get; set; }

        /// <summary>
        /// Gets or sets the ie driver path.
        /// </summary>
        public string IeDriverPath { get; set; }

        /// <summary>
        /// Gets or sets the firefox binary path.
        /// </summary>
        public string FirefoxBinaryPath { get; set; }

        /// <summary>
        /// Gets or sets the software version.
        /// </summary>
        public string AndroidSoftwareVersion { get; set; }
    }

    /// <summary>
    /// The device settings.
    /// </summary>
    public class DeviceSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceSettings"/> class.
        /// </summary>
        public DeviceSettings()
        {
            this.Android7 = new Android7();

            this.Android8 = new Android8();

            this.Ios11 = new Ios11();

            this.Ios12 = new Ios12();
        }

        /// <summary>
        /// Gets or sets the android 7.
        /// </summary>
        public Android7 Android7 { get; set; }

        /// <summary>
        /// Gets or sets the android 8.
        /// </summary>
        public Android8 Android8 { get; set; }

        /// <summary>
        /// Gets or sets the ios 11.
        /// </summary>
        public Ios11 Ios11 { get; set; }

        /// <summary>
        /// Gets or sets the ios 12.
        /// </summary>
        public Ios12 Ios12 { get; set; }
    }

    /// <summary>
    /// The android 7.
    /// </summary>
    public class Android7
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Android7"/> class.
        /// </summary>
        public Android7()
        {
            this.Capabilities = new Android7Capabilities();
        }

        /// <summary>
        /// Gets or sets the remote access.
        /// </summary>
        public Uri RemoteAccess { get; set; }

        /// <summary>
        /// Gets or sets the command timeout.
        /// </summary>
        public long CommandTimeout { get; set; }

        /// <summary>
        /// Gets or sets the capabilities.
        /// </summary>
        public Android7Capabilities Capabilities { get; set; }
    }

    /// <summary>
    /// The android 7 capabilities.
    /// </summary>
    public class Android7Capabilities
    {
        /// <summary>
        /// Gets or sets the platform name.
        /// </summary>
        public string PlatformName { get; set; }

        /// <summary>
        /// Gets or sets the the device name.
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// Gets or sets the platform version.
        /// </summary>
        public string PlatformVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the fast reset is true or false.
        /// </summary>
        public bool FastReset { get; set; }

        /// <summary>
        /// Gets or sets the browser name.
        /// </summary>
        public string BrowserName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the unicode keyboard is true or false.
        /// </summary>
        public bool UnicodeKeyboard { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the reset keyboard is true or false.
        /// </summary>
        public bool ResetKeyboard { get; set; }

        /// <summary>
        /// Gets or sets the new command timeout.
        /// </summary>
        public int NewCommandTimeout { get; set; }
    }

    /// <summary>
    /// The android 8.
    /// </summary>
    public class Android8
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Android8"/> class.
        /// </summary>
        public Android8()
        {
            this.Capabilities = new Android8Capabilities();
        }

        /// <summary>
        /// Gets or sets the remote access.
        /// </summary>
        public Uri RemoteAccess { get; set; }

        /// <summary>
        /// Gets or sets the command timeout.
        /// </summary>
        public int CommandTimeout { get; set; }

        /// <summary>
        /// Gets or sets the capabilities.
        /// </summary>
        public Android8Capabilities Capabilities { get; set; }
    }

    /// <summary>
    /// The android 8 capabilities.
    /// </summary>
    public class Android8Capabilities
    {
        /// <summary>
        /// Gets or sets the platform name.
        /// </summary>
        public string PlatformName { get; set; }

        /// <summary>
        /// Gets or sets the device name.
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// Gets or sets the automation name.
        /// </summary>
        public string AutomationName { get; set; }

        /// <summary>
        /// Gets or sets the platform version.
        /// </summary>
        public string PlatformVersion { get; set; }

        /// <summary>
        /// Gets or sets the fast reset.
        /// </summary>
        public string FastReset { get; set; }

        /// <summary>
        /// Gets or sets the browser name.
        /// </summary>
        public string BrowserName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the unicode keyboard is true or false.
        /// </summary>
        public bool UnicodeKeyboard { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the reset keyboard is true or false.
        /// </summary>
        public bool ResetKeyboard { get; set; }

        /// <summary>
        /// Gets or sets the hex command timeout.
        /// </summary>
        public int NewCommandTimeout { get; set; }

        /// <summary>
        /// Gets or sets the unlock type.
        /// </summary>
        public string UnlockType { get; set; }

        /// <summary>
        /// Gets or sets the unlock key.
        /// </summary>
        public string UnlockKey { get; set; }
    }

    /// <summary>
    /// The ios 11.
    /// </summary>
    public class Ios11
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ios11"/> class.
        /// </summary>
        public Ios11()
        {
            this.Capabilities = new Ios11Capabilities();
        }

        /// <summary>
        /// Gets or sets the remote access.
        /// </summary>
        public Uri RemoteAccess { get; set; }

        /// <summary>
        /// Gets or sets the command timeout.
        /// </summary>
        public int CommandTimeout { get; set; }

        /// <summary>
        /// Gets or sets the capabilities.
        /// </summary>
        public Ios11Capabilities Capabilities { get; set; }
    }

    /// <summary>
    /// The ios 11 capabilities.
    /// </summary>
    public class Ios11Capabilities
    {
        /// <summary>
        /// Gets or sets the platform name.
        /// </summary>
        public string PlatformName { get; set; }

        /// <summary>
        /// Gets or sets the device name.
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// Gets or sets the platform version.
        /// </summary>
        public string PlatformVersion { get; set; }

        /// <summary>
        /// Gets or sets the udid.
        /// </summary>
        public string Udid { get; set; }

        /// <summary>
        /// Gets or sets the browser name.
        /// </summary>
        public string BrowserName { get; set; }

        /// <summary>
        /// Gets or sets the automation name.
        /// </summary>
        public string AutomationName { get; set; }

        /// <summary>
        /// Gets or sets the user command timeout.
        /// </summary>
        public int NewCommandTimeout { get; set; }
    }

    /// <summary>
    /// The ios 12.
    /// </summary>
    public class Ios12
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ios12"/> class.
        /// </summary>
        public Ios12()
        {
            this.Capabilities = new Ios12Capabilities();
        }

        /// <summary>
        /// Gets or sets the remote access.
        /// </summary>
        public Uri RemoteAccess { get; set; }

        /// <summary>
        /// Gets or sets the command timeout.
        /// </summary>
        public int CommandTimeout { get; set; }

        /// <summary>
        /// Gets or sets the capabilities.
        /// </summary>
        public Ios12Capabilities Capabilities { get; set; }
    }

    /// <summary>
    /// The ios 12 capabilities.
    /// </summary>
    public class Ios12Capabilities
    {
        /// <summary>
        /// Gets or sets a value indicating whether the start wdp is true or false.
        /// </summary>
        public bool StartIwdp { get; set; }

        /// <summary>
        /// Gets or sets the new command timeout.
        /// </summary>
        public int NewCommandTimeout { get; set; }

        /// <summary>
        /// Gets or sets the platform name.
        /// </summary>
        public string PlatformName { get; set; }

        /// <summary>
        /// Gets or sets the device name.
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// Gets or sets the platform version.
        /// </summary>
        public string PlatformVersion { get; set; }

        /// <summary>
        /// Gets or sets the udid.
        /// </summary>
        public string Udid { get; set; }

        /// <summary>
        /// Gets or sets the browser name.
        /// </summary>
        public string BrowserName { get; set; }

        /// <summary>
        /// Gets or sets the automation name.
        /// </summary>
        public string AutomationName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the safari allow popups or not.
        /// </summary>
        public bool SafariAllowPopups { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the safari ignore fraud warning or not.
        /// </summary>
        public bool SafariIgnoreFraudWarning { get; set; }
    }

    /// <summary>
    /// The general parameters.
    /// </summary>
    public class GeneralParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralParameters"/> class.
        /// </summary>
        public GeneralParameters()
        {
        }

        /// <summary>
        /// Gets or sets the fiddler port.
        /// </summary>
        /// <value>
        /// The fiddler port.
        /// </value>
        public string FiddlerPort { get; set; }

        /// <summary>
        /// Gets or sets the file operations timeout.
        /// </summary>
        /// <value>
        /// The file operations timeout.
        /// </value>
        public int FileOperationsTimeout { get; set; }

        /// <summary>
        /// Gets or sets the project root folder.
        /// </summary>
        /// <value>
        /// The project root folder.
        /// </value>
        public string ProjectRootFolder { get; set; }

        /// <summary>
        /// Gets or sets the mongo database connection string.
        /// </summary>
        /// <value>
        /// The mongo database connection string.
        /// </value>
        public string MongoDbConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the mongo database database.
        /// </summary>
        /// <value>
        /// The name of the mongo database database.
        /// </value>
        public string MongoDbDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the mongo database collection.
        /// </summary>
        /// <value>
        /// The name of the mongo database collection.
        /// </value>
        public string MongoDbCollectionName { get; set; }

        /// <summary>
        /// Gets or sets the excel parameters file.
        /// </summary>
        /// <value>
        /// The excel parameters file.
        /// </value>
        public string ExcelParametersFile { get; set; }
    }

    /// <summary>
    /// The url parameters.
    /// </summary>
    public class UrlParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlParameters"/> class.
        /// </summary>
        public UrlParameters()
        {
        }

        /// <summary>
        /// Gets or sets the web table application URL.
        /// </summary>
        /// <value>
        /// The web table application URL.
        /// </value>
        public Uri WebTableAppUrl { get; set; }

        /// <summary>
        /// Gets or sets the API URL.
        /// </summary>
        /// <value>
        /// The API URL.
        /// </value>
        public Uri ApiUrl { get; set; }

        /// <summary>
        /// Gets or sets the file upload URL.
        /// </summary>
        /// <value>
        /// The file upload URL.
        /// </value>
        public Uri FileUploadAppUrl { get; set; }

        /// <summary>
        /// Gets or sets the file download URL.
        /// </summary>
        /// <value>
        /// The file download URL.
        /// </value>
        public Uri FileDownloadAppUrl { get; set; }

        /// <summary>
        /// Gets or sets the field limitations URL.
        /// </summary>
        /// <value>
        /// The field limitations URL.
        /// </value>
        public Uri FieldLimitationsUrl { get; set; }

        /// <summary>
        /// Gets or sets the registration users URL.
        /// </summary>
        /// <value>
        /// The registration users URL.
        /// </value>
        public Uri RegistrationUsersUrl { get; set; }

        /// <summary>
        /// Gets or sets the drag and drop URL.
        /// </summary>
        /// <value>
        /// The drag and drop URL.
        /// </value>
        public Uri DragAndDropUrl { get; set; }

        /// <summary>
        /// Gets or sets the web elements color URL.
        /// </summary>
        /// <value>
        /// The web elements color URL.
        /// </value>
        public Uri WebElementsColorUrl { get; set; }

        /// <summary>
        /// Gets or sets the application URL.
        /// </summary>
        /// <value>
        /// The application URL.
        /// </value>
        public Uri AppUrl { get; set; }

        /// <summary>
        /// Gets or sets the elmements height url.
        /// </summary>
        public Uri ElementsHeightUrl { get; set; }

        public Uri ShopUrl { get; set; }
    }
}
