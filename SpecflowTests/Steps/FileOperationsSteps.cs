// <copyright file="FileOperationsSteps.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Specflow.Steps
{
    using Automation.Helpers;
    using BoDi;
    using DataFactory.Configuration;
    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Infrastructure;
    using Unity;

    /// <summary>
    /// The file moving steps.
    /// </summary>
    [Binding]
    public sealed class FileOperationsSteps
    {
        /// <summary>
        /// The file operations helper.
        /// </summary>
        private readonly FileOperationsHelper fileOperationsHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOperationsSteps"/> class.
        /// </summary>
        /// <param name="contextManager">The context manager.</param>
        public FileOperationsSteps(IContextManager contextManager)
        {
            this.fileOperationsHelper = contextManager?.TestThreadContext.Get<IObjectContainer>("objectContainer")?.Resolve<FileOperationsHelper>();
        }

        /// <summary>
        /// Gets the Parameters.
        /// </summary>
        public ConfigurationParameters Parameters { get; }

        /// <summary>
        /// The given i have a file with the name test in the folder.
        /// </summary>
        /// <param name="fileName">The file Name.</param>
        /// <param name="folderName">The folder Name.</param>
        [StepDefinition(@"I have a file with the name (.*) in the folder (.*)")]
        public void GivenIHaveAFileWithTheNameTestInTheFolder(string fileName, string folderName)
        {
            this.fileOperationsHelper.SourceFile = fileName;
            this.fileOperationsHelper.SourceFolder = folderName;
        }

        /// <summary>
        /// The given i move it to the folder test.
        /// </summary>
        /// <param name="targetFolderName">The target Folder Name.</param>
        [StepDefinition(@"I move it to the folder (.*)")]
        public void IMoveItToTheFolderTest(string targetFolderName)
        {
            this.fileOperationsHelper.TargetFolder = targetFolderName;
            this.fileOperationsHelper.MoveFileToLocation();
        }

        /// <summary>
        /// The then the file is moved to the destination folder in less than seconds.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        [StepDefinition(@"the file is moved to the destination folder in less than (.*) seconds")]
        public void ThenTheFileIsMovedToTheDestinationFolderInLessThanSeconds(int timeout)
        {
            this.fileOperationsHelper.IsFileMoved(timeout).Should().BeTrue();
        }

        /// <summary>
        /// The when i copy it to the folder destination Folder.
        /// </summary>
        /// <param name="targetFolderName">The target Folder Name.</param>
        [StepDefinition(@"I copy it to the folder (.*)")]
        public void WhenICopyItToTheFolder(string targetFolderName)
        {
            this.fileOperationsHelper.TargetFolder = targetFolderName;
            this.fileOperationsHelper.CopyFileToLocation();
        }

        /// <summary>
        /// The then the file is copied to the destination folder in less than seconds.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        [StepDefinition(@"the file is copied to the destination folder in less than (.*) seconds")]
        public void ThenTheFileIsCopiedToTheDestinationFolderInLessThanSeconds(int timeout)
        {
            this.fileOperationsHelper.IsFileCopied(timeout).Should().BeTrue();
        }
    }
}