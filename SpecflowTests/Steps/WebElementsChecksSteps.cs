// <copyright file="WebElementsChecksSteps.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Specflow.Steps
{
    using Automation.Pages;
    using BoDi;
    using FluentAssertions;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Infrastructure;
    using WebDriverHelper.Pages;

    /// <summary>
    /// The WebElement check steps.
    /// </summary>
    [Binding]
    public sealed class WebElementsChecksSteps
    {
        /// <summary>
        /// The web elements checks page1.
        /// </summary>
        private readonly WebElementColorsCheckPage webElementsColorCheck;

        private readonly WebElementsLineNumberChecks webElementsLineNumberChecks;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebElementsChecksSteps"/> class.
        /// </summary>
        /// <param name="contextManager">The object container.</param>
        public WebElementsChecksSteps(IContextManager contextManager)
        {
           var objectContainer = contextManager?.TestThreadContext.Get<IObjectContainer>("objectContainer");
            this.webElementsColorCheck = objectContainer?.Resolve<WebElementColorsCheckPage>();
            this.webElementsLineNumberChecks = objectContainer?.Resolve<WebElementsLineNumberChecks>();
        }

        /// <summary>
        /// Then the color of the element element should be red.
        /// </summary>
        /// <param name="expectedColor">The color.</param>
        [StepDefinition("The color of the element element should be (.*)")]
        public void ThenTheColorOfTheElementElementShouldBeRed(string expectedColor)
        {
            var elementColor = this.webElementsColorCheck.GetButtonBackgroundColor();
            elementColor.Should().Be(expectedColor);
        }

        /// <summary>
        /// Then the element has lines.
        /// </summary>
        /// <param name="expectedLineNumber"></param>
        [Then(@"The element has '(.*)' lines")]
        public void ThenTheElementHasLines(int expectedLineNumber)
        {
            webElementsLineNumberChecks.GetFirstParagraphLineNumber().Should().Be(expectedLineNumber);
        }
    }
}