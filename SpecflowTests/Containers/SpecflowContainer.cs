// <copyright file="SpecflowContainer.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Specflow
{
    using Automation.Helpers;
    using Automation.Pages;
    using BoDi;
    using DataFactory.Configuration;
    using WebDriverHelper.Pages;

    /// <summary>
    /// The Specflow Container class.
    /// </summary>
    public class SpecflowContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecflowContainer"/> class.
        /// </summary>
        /// <param name="options">The options object.</param>
        public SpecflowContainer(IWritableOptions<ConfigurationParameters> options)
        {
            var objectContainer = new ObjectContainer();
            this.ObjectContainer = objectContainer;
            this.ObjectContainer.RegisterInstanceAs<IWritableOptions<ConfigurationParameters>>(options);
            this.ObjectContainer.RegisterTypeAs<FileOperationsHelper, FileOperationsHelper>();
            this.ObjectContainer.RegisterTypeAs<MongoDbHelper, MongoDbHelper>();
            this.ObjectContainer.RegisterTypeAs<ApiExecutionHelper, ApiExecutionHelper>();
            this.ObjectContainer.RegisterTypeAs<DragAndDropPage, DragAndDropPage>();
            this.ObjectContainer.RegisterTypeAs<WebElementColorsCheckPage, WebElementColorsCheckPage>();
            this.ObjectContainer.RegisterTypeAs<WebElementsLineNumberChecks, WebElementsLineNumberChecks>();

            this.ObjectContainer = objectContainer;
        }

        /// <summary>
        /// Gets the object container.
        /// </summary>
        /// <value>
        /// The object container.
        /// </value>
        public IObjectContainer ObjectContainer { get; }
    }
}