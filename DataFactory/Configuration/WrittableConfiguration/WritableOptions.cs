// <copyright file="WritableOptions.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace DataFactory.Configuration.Configuration
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The writable options class.
    /// </summary>
    /// <typeparam name="T">The options.</typeparam>
    /// <seealso cref="DataFactory.Configuration.IWritableOptions{T}" />
    public class WritableOptions<T> : IWritableOptions<T>
        where T : class, new()
    {
        /// <summary>
        /// The environment.
        /// </summary>
        private readonly IHostingEnvironment environment;

        /// <summary>
        /// The options.
        /// </summary>
        private readonly IOptionsMonitor<T> options;

        /// <summary>
        /// The section.
        /// </summary>
        private readonly string section;

        /// <summary>
        /// The file.
        /// </summary>
        private readonly string file;

        /// <summary>
        /// Initializes a new instance of the <see cref="WritableOptions{T}"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="options">The options.</param>
        /// <param name="section">The section.</param>
        /// <param name="file">The file.</param>
        public WritableOptions(
            IHostingEnvironment environment,
            IOptionsMonitor<T> options,
            string section,
            string file)
        {
            this.environment = environment;
            this.options = options;
            this.section = section;
            this.file = file;
        }

        /// <summary>
        /// Gets the default configured TOptions instance.
        /// </summary>
        public T Value => this.options.CurrentValue;

        /// <summary>
        /// Returns a configured TOptions instance with the given name.
        /// </summary>
        /// <param name="name">The param name.</param>
        /// <returns>The TOptions.</returns>
        public T Get(string name) => this.options.Get(name);

        /// <summary>
        /// Updates the specified apply changes.
        /// </summary>
        /// <param name="applyChanges">The apply changes.</param>
        public void Update(Action<T> applyChanges)
        {
            var fileProvider = this.environment.ContentRootFileProvider;
            var fileInfo = fileProvider.GetFileInfo(this.file);
            var physicalPath = fileInfo.PhysicalPath;

            var jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(physicalPath));
            var sectionObject = jObject.TryGetValue(this.section, out JToken section) ?
                JsonConvert.DeserializeObject<T>(section.ToString()) : (this.Value ?? new T());

            applyChanges(sectionObject);

            jObject[this.section] = JObject.Parse(JsonConvert.SerializeObject(sectionObject));
            File.WriteAllText(physicalPath, JsonConvert.SerializeObject(jObject, Formatting.Indented));
        }
    }
}
