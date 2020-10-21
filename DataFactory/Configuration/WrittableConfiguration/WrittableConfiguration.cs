// <copyright file="WrittableConfiguration.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace DataFactory.Configuration.Configuration
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The writtable configuration.
    /// </summary>
    public class WrittableConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrittableConfiguration"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="services">The services.</param>
        public WrittableConfiguration(IConfiguration configuration, IServiceCollection services)
        {
            services.ConfigureWritable<ConfigurationParameters>(configuration.GetSection("BrowsersConfiguration"));
        }
    }
}
