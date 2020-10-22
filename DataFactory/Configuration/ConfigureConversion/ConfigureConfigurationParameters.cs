// <copyright file="ConfigureConfigurationParameters.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace DataFactory.Configuration
{
    using System;
    using System.Globalization;
    using System.IO;
    using Microsoft.Extensions.Options;

#pragma warning disable CS1584 // XML comment has syntactically incorrect cref attribute
#pragma warning disable CS1658 // Warning is overriding an error
/// <summary>
    /// THe configuration class of the json parsing.
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Options.IConfigureOptions{DataFactory.Configuration.ConfigurationParameters}" />
    public class ConfigureConfigurationParameters : IConfigureOptions<ConfigurationParameters>
#pragma warning restore CS1658 // Warning is overriding an error
#pragma warning restore CS1584 // XML comment has syntactically incorrect cref attribute
    {
        /// <summary>
        /// Invoked to configure a TOptions instance.
        /// </summary>
        /// <param name="options">The options instance to configure.</param>
        public void Configure(ConfigurationParameters options)
        {
            options.GeneralParameters.ProjectRootFolder = System.IO.Directory.GetCurrentDirectory();
            options.BrowsersConfiguration.ChromeDriverPath = System.IO.Directory.GetCurrentDirectory() + "/" + options.BrowsersConfiguration.ChromeDriverPath;
            options.BrowsersConfiguration.FirefoxBinaryPath = options.BrowsersConfiguration.FirefoxBinaryPath.Replace(
                "ProgramFiles",
                Path.Combine(
                nameof(Environment.SpecialFolder.ProgramFiles),
                Constants.FirefoxExecutableName),
                ignoreCase: false,
                new CultureInfo("es-ES"));
            options.BrowsersConfiguration.FirefoxDriverPath = System.IO.Directory.GetCurrentDirectory() + "/" + options.BrowsersConfiguration.FirefoxDriverPath;
            options.BrowsersConfiguration.IeDriverPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), options.BrowsersConfiguration.IeDriverPath);
        }
    }
}
