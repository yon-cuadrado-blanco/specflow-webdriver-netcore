// <copyright file="GeneralParameters.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace DataFactory.Configuration.Parameters
{
    /// <summary>
    /// General Parameters.
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
}
