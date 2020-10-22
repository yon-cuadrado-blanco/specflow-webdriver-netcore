//-------------------------------------------------------------------------------------------------
// <copyright file="Hooks.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>
//-------------------------------------------------------------------------------------------------

namespace Specflow.GlobalFunctions
{
    using System;
    using System.Linq;
    using Automation.WebDriverHelper;
    using BoDi;
    using Castle.Core.Internal;
    using DataFactory.Configuration;
    using DataFactory.Configuration.Configuration;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Appium.Service;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Infrastructure;

    /// <summary>
    /// The Specflow Hooks.
    /// </summary>
    [Binding]
    [TestClass]
    public class Hooks : Steps
    {
        /// <summary>
        /// The object container.
        /// </summary>
        private IObjectContainer objectContainer;

        /// <summary>
        /// The context manager.
        /// </summary>
        private readonly IContextManager contextManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hooks"/> class.
        /// </summary>
        /// <param name="ContextManager"></param>
        /// <param name="TestContext"></param>
        public Hooks(IContextManager ContextManager, TestContext TestContext)
        {
            this.contextManager = ContextManager;
            this.TestContext = TestContext;
        }

        /// <summary>
        /// Gets or sets appium local service.
        /// </summary>
        public static AppiumLocalService AppiumLocalService { get; set; }

        /// <summary>
        /// Gets or sets the webdriver.
        /// </summary>
        public static WebDriverContext WebDriverContextStatic { get; set; }

        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Gets the web driver.
        /// </summary>
        /// <param name="contextManager">The object container.</param>
        /// <param name="options">The options.</param>
        /// <returns>The webdrivercontext object.</returns>
        public static WebDriverContext GetWebDriver(IContextManager contextManager, IWritableOptions<ConfigurationParameters> options)
        {
            var objectContainer = contextManager?.TestThreadContext.Get<IObjectContainer>("objectContainer");
            WebDriverContext webDriverContext = null;
            if (objectContainer.IsRegistered<WebDriverContext>())
            {
                webDriverContext = objectContainer.Resolve<WebDriverContext>();
            }

            if (options?.Value.BrowsersConfiguration.Browser == Browser.ChromeAndroid9)
            {
                AppiumLocalService = AndroidWebDriver.CreateAppiumLocalService();
                AppiumLocalService.Start();
            }
                
            if (webDriverContext?.WebDriver == null)
            {
                if (!objectContainer.IsRegistered<WebDriverContext>())
                {
                    objectContainer.RegisterTypeAs<WebDriverContext, WebDriverContext>();
                }
                objectContainer.Resolve<WebDriverContext>().CreateWebDriver();
                webDriverContext = objectContainer.Resolve<WebDriverContext>();
            }

            return webDriverContext;
        }

        /// <summary>
        /// The load configuration parameters.
        /// </summary>
        [BeforeTestRun]
        public static void LoadConfigurationParameters()
        {
            
        }

        /// <summary>
        /// Stop appium process.
        /// </summary>
        [AfterTestRun]
        public static void AfterTestRun(TestThreadContext TestThreadContext)
        {
            var objectContainer = TestThreadContext?.Get<IObjectContainer>("objectContainer");
            if (objectContainer.IsRegistered<WebDriverContext>())
            {
                objectContainer.Resolve<WebDriverContext>().CloseBrowser();
            }

            AppiumLocalService?.Dispose();
        }

        /// <summary>
        /// The execute final steps.
        /// </summary>
        [AfterScenario]
        public void CloseOrResetBrowser()
        {
            try
            {
                var scenarioContext = this.ScenarioContext;
                if (this.objectContainer.IsRegistered<WebDriverContext>() || WebDriverContextStatic != null)
                {
                    var webdriverContext = WebDriverContextStatic ?? this.objectContainer.Resolve<WebDriverContext>();

                    if (scenarioContext != null && !webdriverContext.IsWebDriverNull())
                    {
                        var scenarioTestContext = scenarioContext.ScenarioContainer.Resolve<TestContext>() as TestContext;

                        if (scenarioContext.TestError != null)
                        {
                            // Take a screenshot.
                            var screenshotPathFile = webdriverContext.MakeWebScreenshot(scenarioContext.ScenarioInfo.Title, this.TestContext.ResultsDirectory);
                            scenarioTestContext.AddResultFile(screenshotPathFile);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                System.Console.WriteLine(error);
                System.Diagnostics.Trace.WriteLine(error);
                System.Diagnostics.Debug.WriteLine(error);
            }
        }

        /// <summary>
        /// The load container function.
        /// </summary>
        [BeforeScenario]
        public void LoadContainer()
        {            
            if (this.contextManager.TestThreadContext.IsNullOrEmpty())
            {
                this.objectContainer = this.CreateContainer();
                this.contextManager.TestThreadContext.Add( "objectContainer",  this.objectContainer);
            }
            else
            {
                this.objectContainer = this.contextManager.TestThreadContext.Get<IObjectContainer>("objectContainer");
            }
            var configurationParameters = this.objectContainer.Resolve<IWritableOptions<ConfigurationParameters>>();
            if (!configurationParameters.Value.BrowsersConfiguration.ReuseBrowser && this.objectContainer.IsRegistered<WebDriverContext>())
            {
                this.objectContainer.Resolve<WebDriverContext>().CloseBrowser();
            }
        }

        /// <summary>
        /// The take screenshot.
        /// </summary>
        [AfterStep]
        public void TakeScreenshot()
        {
            if (this.ScenarioContext.ScenarioInfo.Tags.Contains("WebDriver"))
            {
                this.objectContainer.Resolve<WebDriverContext>().TakeScreenshot();
            }
        }

        /// <summary>
        /// The After feature function.
        /// </summary>
        /// <param name="contextManager"></param>
        [AfterFeature]
        public static void AfterFeature(IContextManager contextManager)
        {
            var objectContainer = contextManager?.TestThreadContext.Get<IObjectContainer>("objectContainer");
            if (objectContainer.IsRegistered<WebDriverContext>())
            {
                objectContainer.Resolve<WebDriverContext>().CloseBrowser();
            }
        }

        /// <summary>
        /// The create container function.
        /// </summary>
        /// <returns>The IObjectContainer.</returns>
        private IObjectContainer CreateContainer()
        {
            var builder = new ConfigurationBuilder()
             //.SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
             .AddEnvironmentVariables();
            IConfiguration configuration = builder.Build();
            var services = new ServiceCollection();
            services.AddOptions();
            services.Configure<ConfigurationParameters>(configuration.GetSection("ConfigurationParameters"));
            services.ConfigureOptions<ConfigureConfigurationParameters>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var environment = serviceProvider.GetService<IHostingEnvironment>();
            var options = serviceProvider.GetService<IOptionsMonitor<ConfigurationParameters>>();

            IConfigurationSection section = configuration.GetSection("ConfigurationParameters");
            var wOptions = new WritableOptions<ConfigurationParameters>(environment, options, section.Key, "appsettings.json");
            return new SpecflowContainer(wOptions).ObjectContainer;
        }
    }
}