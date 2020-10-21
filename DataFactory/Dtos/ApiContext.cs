// <copyright file="ApiContext.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace DataFactory.Configuration
{
    /// <summary>
    /// The API context.
    /// </summary>
    public class ApiContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiContext"/> class.
        /// </summary>
        public ApiContext()
        {
            this.ValidUserId = "1";
            this.InvalidUserId = "wrong\\%&";
            this.NonExistingUserId = "123";
        }

        /// <summary>
        /// Gets the valid user ID.
        /// </summary>
        public string ValidUserId { get; }

        /// <summary>
        /// Gets the invalid user id.
        /// </summary>
        public string InvalidUserId { get; }

        /// <summary>
        /// Gets the non existing user id.
        /// </summary>
        public string NonExistingUserId { get; }
    }
}