// <copyright file="IWritableOptions.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace DataFactory.Configuration
{
    using System;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// The IWritable options interface.
    /// </summary>
    /// <typeparam name="T">The name of the parameter.</typeparam>
    /// <seealso cref="Microsoft.Extensions.Options.IOptionsSnapshot{T}" />
    public interface IWritableOptions<out T> : IOptionsSnapshot<T>
        where T : class, new()
    {
        /// <summary>
        /// Updates the specified apply changes.
        /// </summary>
        /// <param name="applyChanges">The apply changes.</param>
        void Update(Action<T> applyChanges);
    }
}
