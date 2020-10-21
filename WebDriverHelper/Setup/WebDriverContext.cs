namespace Automation.WebDriverHelper
{
    using System;
    using System.Globalization;
    using System.IO;
    using DataFactory.Configuration;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Service;
    using Protractor;

    /// <summary>
    /// The front end basic context.
    /// </summary>
    public class WebDriverContext : IDisposable
    {
        /// <summary>
        /// The configuration parameters.
        /// </summary>
        private readonly IWritableOptions<ConfigurationParameters> options;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public WebDriverContext(IWritableOptions<ConfigurationParameters> options)
        {
            this.options = options;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="WebDriverContext"/> class.
        /// </summary>
        ~WebDriverContext()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets or sets the internal driver.
        /// </summary>
        /// <value>
        /// The internal driver.
        /// </value>
        public IWebDriver WebDriver { get; set; }

        /// <summary>
        /// Gets or sets the Driver.
        /// </summary>
        public NgWebDriver NgWebDriver { get; set; }

        /// <summary>
        /// Gets or sets the appium local service.
        /// </summary>
        public AppiumLocalService AppiumLocalService { get; set; }

        /// <summary>
        /// Determines whether [is web driver null].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is web driver null]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsWebDriverNull()
        {
            return this.WebDriver != null;
        }

        /// <summary>
        /// Creates the web driver.
        /// </summary>
        /// <exception cref="Exception">Unknown browser.</exception>
        public void CreateWebDriver()
        {
            switch (this.options.Value.BrowsersConfiguration.Browser)
            {
                case Browser.IE11:
                    {
                        this.WebDriver = IeWebdriver.CreateNewWebDriver(this.options);
                        break;
                    }

                case Browser.ChromeDesktop:
                    {
                        this.WebDriver = ChromeWebDriver.CreateNewWebDriver(this.options);
                        break;
                    }

                case Browser.Firefox:
                    {
                        this.WebDriver = FirefoxWebDriver.CreateNewWebDriver(this.options);
                        break;
                    }

                case Browser.ChromeAndroid9:
                    {
                        this.WebDriver = AndroidWebDriver.CreateNewWebDriver(this.options);
                        break;
                    }

                case Browser.Safari:
                    {
                        this.WebDriver = SafariWebDriver.CreateNewWebDriver(this.options);
                        break;
                    }

                default:
                    {
                        throw new Exception("Unknown browser");
                    }
            }

            this.WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(this.options.Value.BrowsersConfiguration.PageLoadTimeout);
            this.WebDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(this.options.Value.BrowsersConfiguration.AsynchronousJavascriptTimeout);
            this.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(this.options.Value.BrowsersConfiguration.ImplicitWaitTimeout);
            this.NgWebDriver = new NgWebDriver(this.WebDriver);
        }

        /// <summary>
        /// Close and dispose the browser driver if it exists.
        /// </summary>
        public void CloseBrowser()
        {
            if (this.NgWebDriver != null)
            {
                this.NgWebDriver.Quit();
                this.NgWebDriver.Dispose();
                this.NgWebDriver = null;
            }

            if (this.WebDriver != null)
            {
                this.WebDriver.Quit();
                this.WebDriver.Dispose();
                this.WebDriver = null;
            }
        }

        /// <summary>
        /// The make web screenshot.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <param name="contextPath">The context Path.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string MakeWebScreenshot(string scenario, string contextPath)
        {
            var screenshot = ((ITakesScreenshot)this.NgWebDriver).GetScreenshot();
            var screenshotName = $"{scenario}.jpeg";

            var fullPathFile = contextPath + @"\" + screenshotName;

            if (fullPathFile.Length > 259)
            {
                fullPathFile = fullPathFile.Substring(0, fullPathFile.Length - (fullPathFile.Length - 260 + 6)) + ".jpeg";
            }

            screenshot.SaveAsFile(fullPathFile, ScreenshotImageFormat.Jpeg);

            return fullPathFile;
        }

        /// <summary>
        /// Goes to URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        public void GoToUrl(Uri url)
        {
            this.NgWebDriver.Navigate().GoToUrl(url, false);
        }

        /// <summary>
        /// Takes the screenshot.
        /// </summary>
        public void TakeScreenshot()
        {
            if (this.WebDriver != null)
            {
                // Create an empty temp folder to store the screenshots
                var tempFolder = Path.Combine(
                                     Path.GetTempPath(),
                                     "SpecflowExecutionResults" + DateTime.Now.ToString("yyyy_MM_dd", new CultureInfo("es-ES", false)));

                Directory.CreateDirectory(tempFolder);
                var ss = ((ITakesScreenshot)this.NgWebDriver?.WrappedDriver).GetScreenshot();

                var screenshotFileName = "screenshot" + DateTime.Now.ToString("yyyyMMddHHmmss", new CultureInfo("es-ES", false)) +
                    "_" + Guid.NewGuid() + ".jpeg";

                var screenshotFileNameAndPath = Path.Combine(tempFolder, screenshotFileName);

                ss.SaveAsFile(screenshotFileNameAndPath, OpenQA.Selenium.ScreenshotImageFormat.Png);
                Console.WriteLine("file:///" + screenshotFileNameAndPath);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose function.
        /// </summary>
        /// <param name="disposing">The disposing variable.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.NgWebDriver?.Quit();
                    this.WebDriver?.Quit();
                }
            }

            // dispose unmanaged resources
            this.disposed = true;
        }
    }
}