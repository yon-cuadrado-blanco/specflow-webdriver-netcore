// <copyright file="ApiTestsSteps.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Specflow.Steps
{
    using Automation.Helpers;
    using BoDi;
    using DataFactory.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Infrastructure;

    /// <summary>
    /// The API tests steps.
    /// </summary>
    [Binding]
    public class ApiTestsSteps : Steps
    {
        /// <summary>
        /// The API execution helper.
        /// </summary>
        private readonly ApiExecutionHelper apiExecutionHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiTestsSteps"/> class.
        /// </summary>
        /// <param name="contextManager">The object container.</param>
        public ApiTestsSteps(IContextManager contextManager)
        {
            this.ApiContext = new ApiContext();
            this.apiExecutionHelper = contextManager?.TestThreadContext.Get<IObjectContainer>("objectContainer")?.Resolve<ApiExecutionHelper>();
        }

        /// <summary>
        /// Gets the API context.
        /// </summary>
        private ApiContext ApiContext { get; }

        /// <summary>
        /// The given a valid user id.
        /// </summary>
        [StepDefinition("a valid user id")]
        public void GivenAValidUserId()
        {
            this.apiExecutionHelper.SetUserId(this.ApiContext.ValidUserId);
        }

        /// <summary>
        /// The given a non existing user id.
        /// </summary>
        [StepDefinition("a non existing user id")]
        public void GivenAnUnexistingUserId()
        {
            this.apiExecutionHelper.SetUserId(this.ApiContext.NonExistingUserId);
        }

        /// <summary>
        /// The given an incorrect user id.
        /// </summary>
        [StepDefinition("an incorrect user id")]
        public void GivenAnIncorrectUserId()
        {
            this.apiExecutionHelper.SetUserId(this.ApiContext.InvalidUserId);
        }

        /// <summary>
        /// The when the information of this user is requested.
        /// </summary>
        [StepDefinition("the information of this user is requested")]
        public void WhenTheInformationOfThisUserIsRequested()
        {
            this.apiExecutionHelper.SendRequest();
        }

        /// <summary>
        /// The then the user data is returned.
        /// </summary>
        [StepDefinition("the user data is returned")]
        public void ThenTheUserDataIsReturned()
        {
            var response = this.apiExecutionHelper.GetResponse();
            var content = response.Content.ReadAsStringAsync();
            dynamic json = JToken.Parse(content.Result);

            string id = json[1]["id"].ToString();

            Assert.AreEqual(response.ReasonPhrase, "OK");
            Assert.AreEqual(id, "2");
        }

        /// <summary>
        /// The then no user data is returned.
        /// </summary>
        [StepDefinition("no user data is returned")]
        public void ThenNoUserDataIsReturned()
        {
            var response = this.apiExecutionHelper.GetResponse();
            var content = response.Content.ReadAsStringAsync();
            dynamic json = JToken.Parse(content.Result);

            var jsonObject = (JArray)json;

            Assert.AreEqual(response.ReasonPhrase, "OK");
            Assert.AreEqual(jsonObject.Count, 0);
        }

        /// <summary>
        /// The then an error is returned.
        /// </summary>
        [StepDefinition("an error is returned")]
        public void ThenAnErrorIsReturned()
        {
            var response = this.apiExecutionHelper.GetResponse();
            var content = response.Content.ReadAsStringAsync();
            dynamic json = JToken.Parse(content.Result);

            var jsonObject = (JArray)json;

            Assert.AreEqual(response.ReasonPhrase, "OK");
            Assert.AreEqual(jsonObject.Count, 0);
        }
    }
}