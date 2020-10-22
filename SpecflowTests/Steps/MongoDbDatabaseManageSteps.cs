// <copyright file="MongoDbDatabaseManageSteps.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Specflow.Steps
{
    using System;
    using System.Linq;
    using Automation.Helpers;
    using BoDi;
    using DataFactory.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Infrastructure;

    /// <summary>
    /// The mongo DB database access and modification steps . test.
    /// </summary>
    [Binding]
    public class MongoDbDatabaseManageSteps : Steps
    {
        /// <summary>
        /// The object container.
        /// </summary>
        private readonly IObjectContainer objectContainer;

        /// <summary>
        /// Url used in the webTable test cases.
        /// </summary>
        private readonly MongoDbHelper mongoDbHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbDatabaseManageSteps"/> class.
        /// </summary>
        /// <param name="contextManager">The object container.</param>
        public MongoDbDatabaseManageSteps(IContextManager contextManager)
        {
            this.objectContainer = contextManager?.TestThreadContext.Get<IObjectContainer>("objectContainer");
            this.mongoDbHelper = this.objectContainer?.Resolve<MongoDbHelper>();
        }

        /// <summary>
        /// The given i have a non existing client.
        /// </summary>
        [Given("I have a non existing client")]
        public void GivenIHaveANonExistingClient()
        {
            this.mongoDbHelper.Client = new ClientsDto("maria", "garcia", "Barnia", "5", Guid.NewGuid().ToString());
        }

        /// <summary>
        /// The given i have an existing client.
        /// </summary>
        [Given("I have an existing client")]
        public void GivenIHaveAnExistingClient()
        {
            this.mongoDbHelper.Client = new ClientsDto("maria", "garcia", "Barnia", "5", "28080");
            this.mongoDbHelper.AddEmployee();
        }

        /// <summary>
        /// The when i add the data of this client to the database.
        /// </summary>
        [When("I add the data of this client to the database")]
        public void WhenIAddTheDataOfThisClientToTheDatabase()
        {
            this.mongoDbHelper.AddEmployee();
        }

        /// <summary>
        /// The when i get the data of this client.
        /// </summary>
        [When("I get the data of this client")]
        public void WhenIGetTheDataOfThisClient()
        {
            this.mongoDbHelper.GetEmployee();
        }

        /// <summary>
        /// The then this client should not be found in the database.
        /// </summary>
        [Then("this client should not be found in the database")]
        public void ThenThisClientShouldNotBeFoundInTheDatabase()
        {
            var client = this.mongoDbHelper.Client;
            var databaseClient = this.mongoDbHelper.GetEmployee();

            Assert.IsFalse(client == databaseClient);
        }

        /// <summary>
        /// Then I have added a non existing element.
        /// </summary>
        [Given("I have added a non existing client")]
        public void GivenIHaveAddedANonExistingElement()
        {
            this.mongoDbHelper.Client = new ClientsDto("maria", "garcia", "Barnia", "5", Guid.NewGuid().ToString());
            this.mongoDbHelper.AddEmployee();
        }

        /// <summary>
        /// Then this client should appear in the database.
        /// </summary>
        [Then("this client should be found in the database")]
        public void ThenThisClientShouldBeFoundInTheDatabase()
        {
            var databaseClient = this.mongoDbHelper.GetEmployee();
            var client = this.mongoDbHelper.Client;
            Assert.IsTrue(databaseClient.Addresses.Any(z => client.Addresses.Any(
                                                                                  y => y.Number == z.Number
                                                                                  && (y.Street == z.Street
                                                                                  && y.PostalCode == z.PostalCode))));
            Assert.IsTrue(client.FirstName.Equals(databaseClient.FirstName, StringComparison.Ordinal));
            Assert.IsTrue(client.LastName.Equals(databaseClient.LastName, StringComparison.Ordinal));
        }

        /// <summary>
        /// When I remove this client.
        /// </summary>
        [When("I remove this client")]
        public void WhenIRemoveThisClient()
        {
            var client = this.mongoDbHelper.Client;
            this.mongoDbHelper.DeleteDocument(client);
            var databaseClient = this.mongoDbHelper.GetEmployee();
            this.ScenarioContext.Add(nameof(databaseClient), databaseClient);
        }

        /// <summary>
        /// When I modify the value of the last name.
        /// </summary>
        /// <param name="lastName">new value of the lastName field.</param>
        [When(@"I modify the value of the last name to be ""(.*)""")]
        public void WhenIModifyTheValueOfTheLastNameToBe(string lastName)
        {
            var client = this.mongoDbHelper.Client;
            var newClient = new ClientsDto(client.FirstName, lastName, client.Addresses);
            this.mongoDbHelper.UpdateClient(client, newClient);
        }
    }
}