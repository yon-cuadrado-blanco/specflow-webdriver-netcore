// <copyright file="CommonSteps.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Specflow.Steps
{
    using System;
    using BoDi;
    using DataFactory.Configuration;
    using Specflow.GlobalFunctions;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Infrastructure;
    using Unity;

    /// <summary>
    /// The common steps.
    /// </summary>
    [Binding]
    public sealed class CommonSteps : Steps
    {
        /// <summary>
        /// The configuration parameters.
        /// </summary>
        private readonly IWritableOptions<ConfigurationParameters> options;

        /// <summary>
        /// The object container.
        /// </summary>
        private readonly IContextManager contextManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonSteps"/> class.
        /// </summary>
        /// <param name="contextManager">The context manager.</param>
        public CommonSteps(IContextManager contextManager)
        {
            this.contextManager = contextManager;
            this.options = contextManager?.TestThreadContext.Get<IObjectContainer>("objectContainer")?.Resolve<IWritableOptions<ConfigurationParameters>>();
        }

        /// <summary>
        /// The given i navigate to the page.
        /// </summary>
        /// <param name="appName">describe appName parameter on GivenINavigateToThePage.</param>
        [StepDefinition("I navigate to the page (.*)")]
        public void GivenINavigateToThePage(string appName)
        {
            Hooks.GetWebDriver(this.contextManager, this.options).GoToUrl(this.GetAppUrl(appName));
        }

        /// <summary>
        /// The function gets the value of the url from the app.config class.
        /// </summary>
        /// <param name="app">Name of the app.</param>
        /// <returns>Url of the app.</returns>
        private Uri GetAppUrl(string app)
        {
            Uri returnValue = app switch
            {
                "webtables" => this.options.Value.UrlParameters.WebTableAppUrl,
                "FileUploadUrl" => this.options.Value.UrlParameters.FileUploadAppUrl,
                "FileDownloadUrl" => this.options.Value.UrlParameters.FileDownloadAppUrl,
                "DragAndDropUrl" => this.options.Value.UrlParameters.DragAndDropUrl,
                "WebElementsColor" => this.options.Value.UrlParameters.WebElementsColorUrl,
                "ElementsHeightUrl" => this.options.Value.UrlParameters.ElementsHeightUrl,
                _ => throw new Exception("url of the app not defined"),
            };
            return returnValue;
        }
    }
}