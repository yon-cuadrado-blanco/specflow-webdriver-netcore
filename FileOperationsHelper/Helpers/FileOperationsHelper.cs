// <copyright file="FileOperationsHelper.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Automation.Helpers
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using DataFactory.Configuration;

    /// <summary>
    /// The file moving copying helper.
    /// </summary>
    public class FileOperationsHelper
    {
        /// <summary>
        /// The options.
        /// </summary>
        private readonly IWritableOptions<ConfigurationParameters> options;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOperationsHelper"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public FileOperationsHelper(IWritableOptions<ConfigurationParameters> options)
        {
            this.options = options;
        }

        /// <summary>
        /// Gets or sets the source file.
        /// </summary>
        /// <value>
        /// The source file.
        /// </value>
        public string SourceFile { get; set; }

        /// <summary>
        /// Gets or sets the source folder.
        /// </summary>
        /// <value>
        /// The source folder.
        /// </value>
        public string SourceFolder { get; set; }

        /// <summary>
        /// Gets or sets the target file.
        /// </summary>
        /// <value>
        /// The target file.
        /// </value>
        public string TargetFile { get; set; }

        /// <summary>
        /// Gets or sets the target folder.
        /// </summary>
        /// <value>
        /// The target folder.
        /// </value>
        public string TargetFolder { get; set; }

        /// <summary>
        /// Copies the file to location.
        /// </summary>
        /// <exception cref="Exception">
        /// The file is still in the source folder
        /// or
        /// The file has not been moved to the target folder.
        /// </exception>
        public void CopyFileToLocation()
        {
            var projectFolderRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            this.SourceFolder = Path.Combine(projectFolderRoot, this.SourceFolder);
            var sourceFileNameAndPath = Path.Combine(this.SourceFolder, this.SourceFile);
            if (this.TargetFile == null)
            {
                this.TargetFile = this.SourceFile;
            }

            var tempFolder = Path.GetTempPath();
            this.TargetFolder = Path.Combine(tempFolder, this.TargetFolder);
            var targetFileNameAndPath = Path.Combine(this.TargetFolder, this.TargetFile);
            if (!Directory.Exists(Path.Combine(tempFolder, this.TargetFolder)))
            {
                Directory.CreateDirectory(Path.Combine(tempFolder, this.TargetFolder));
            }

            File.Copy(sourceFileNameAndPath, targetFileNameAndPath, true);

            if (!RetryUntilSuccessOrTimeout(() => File.Exists(targetFileNameAndPath), TimeSpan.FromSeconds(this.options.Value.GeneralParameters.FileOperationsTimeout)))
            {
                throw new Exception("The file has not been moved to the target folder");
            }

            this.SourceFolder = this.TargetFolder;
            this.SourceFile = this.TargetFile;
        }

        /// <summary>
        /// Moves the file to location.
        /// </summary>
        public void MoveFileToLocation()
        {
            var sourceFileNameAndPath = Path.Combine(this.SourceFolder, this.SourceFile);
            if (this.TargetFile == null)
            {
                this.TargetFile = this.SourceFile;
            }

            var tempFolder = Path.GetTempPath();
            this.TargetFolder = Path.Combine(tempFolder, this.TargetFolder);
            var targetFileNameAndPath = Path.Combine(this.TargetFolder, this.TargetFile);

            if (File.Exists(targetFileNameAndPath))
            {
                File.Delete(targetFileNameAndPath);
            }

            if (!Directory.Exists(this.TargetFolder))
            {
                Directory.CreateDirectory(this.TargetFolder);
            }

            File.Move(sourceFileNameAndPath, targetFileNameAndPath);
        }

        /// <summary>
        /// Determines whether [is file copied] [the specified timeout].
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns>
        ///   <c>true</c> if [is file copied] [the specified timeout]; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="Exception">The file has not been moved to the target folder.</exception>
        public bool IsFileCopied(int timeout)
        {
            var targetFileNameAndPath = Path.Combine(this.TargetFolder, this.TargetFile);

            if (!RetryUntilSuccessOrTimeout(() => File.Exists(targetFileNameAndPath), TimeSpan.FromSeconds(timeout)))
            {
                throw new Exception("The file has not been moved to the target folder");
            }

            return true;
        }

        /// <summary>
        /// Determines whether [is file moved] [the specified timeout].
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns>
        ///   <c>true</c> if [is file moved] [the specified timeout]; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="Exception">The file has not been moved to the target folder.</exception>
        public bool IsFileMoved(int timeout)
        {
            var sourceFileNameAndPath = Path.Combine(this.SourceFolder, this.SourceFile);
            var targetFileNameAndPath = Path.Combine(this.TargetFolder, this.TargetFile);
            if (!RetryUntilSuccessOrTimeout(() => !File.Exists(sourceFileNameAndPath), TimeSpan.FromSeconds(timeout)))
            {
                throw new Exception("The file is still in the source folder");
            }

            if (!RetryUntilSuccessOrTimeout(() => File.Exists(targetFileNameAndPath), TimeSpan.FromSeconds(timeout)))
            {
                throw new Exception("The file has not been moved to the target folder");
            }

            return true;
        }

        /// <summary>
        /// The retry until success or timeout.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="timeSpan">The time span.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private static bool RetryUntilSuccessOrTimeout(Func<bool> task, TimeSpan timeSpan)
        {
            var success = false;
            var elapsed = 0;
            while ((!success) && (elapsed < timeSpan.TotalMilliseconds))
            {
                Thread.Sleep(1000);
                elapsed += 1000;
                success = task?.Invoke() ?? default;
            }

            return success;
        }
    }
}