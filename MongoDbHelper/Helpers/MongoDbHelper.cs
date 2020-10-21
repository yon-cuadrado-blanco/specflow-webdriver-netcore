// <copyright file="MongoDbHelper.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Automation.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using DataFactory.Configuration;
    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;

    /// <summary>
    /// The mongo database manage access.
    /// </summary>
    public class MongoDbHelper
    {
        /// <summary>
        /// The database.
        /// </summary>
        private readonly IMongoCollection<ClientsDto> collection;

        /// <summary>
        /// The database.
        /// </summary>
        private readonly IMongoDatabase database;

        /// <summary>
        /// The mongo client.
        /// </summary>
        private readonly MongoClient mongoClient;

        /// <summary>
        /// The options.
        /// </summary>
        private readonly IWritableOptions<ConfigurationParameters> options;

        /// <summary>
        /// The match found.
        /// </summary>
        private ClientsDto matchFound;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbHelper"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public MongoDbHelper(IWritableOptions<ConfigurationParameters> options)
        {
            this.options = options;

            if (!BsonClassMap.IsClassMapRegistered(typeof(ClientAddressDto)))
            {
                BsonClassMap.RegisterClassMap<ClientAddressDto>(ca => ca.AutoMap());

                BsonClassMap.RegisterClassMap<List<ClientAddressDto>>(cm => cm.AutoMap());
            }

            this.mongoClient = new MongoClient(this.options.Value.GeneralParameters.MongoDbConnectionString);
            this.database = this.mongoClient.GetDatabase(this.options.Value.GeneralParameters.MongoDbDatabaseName);
            this.collection = this.database.GetCollection<ClientsDto>(this.options.Value.GeneralParameters.MongoDbCollectionName);
        }

        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        public ClientsDto Client { get; set; }

        /// <summary>
        /// Gets the Parameters.
        /// </summary>
        public ConfigurationParameters Parameters { get; }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        public void AddEmployee()
        {
            this.collection.InsertOneAsync(this.Client).Wait();
        }

        /// <summary>
        /// Gets the match found.
        /// </summary>
        /// <returns>The value of the variable match found.</returns>
        public ClientsDto GetMatchFound()
        {
            return this.matchFound;
        }

        /// <summary>
        /// The delete document.
        /// </summary>
        /// <param name="client">describe client parameter on DeleteDocument.</param>
        public void DeleteDocument(ClientsDto client)
        {
            var numbers = client.Addresses.Select(bidResult => bidResult.Number).ToList();
            var streets = client.Addresses.Select(bidResult => bidResult.Street).ToList();
            var postalCodes = client.Addresses.Select(bidResult => bidResult.PostalCode).ToList();

            var builder = Builders<ClientsDto>.Filter;
            var filter = builder.Eq(x => x.FirstName, client.FirstName)
                & builder.Eq(x => x.LastName, client.LastName)
                & builder.Eq(x => x.Addresses, client.Addresses)
                & builder.ElemMatch(x => x.Addresses, el => numbers.Contains(el.Number) && (streets.Contains(el.Street) && postalCodes.Contains(el.PostalCode)));
            this.collection.DeleteOneAsync(filter).Wait();
        }

        /// <summary>
        /// Searches the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The result of the query to the database.</returns>
        public List<ClientsDto> Search(Expression<Func<ClientsDto, bool>> filter)
        {
            return this.collection.FindAsync(filter).Result.ToListAsync().Result;
        }

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <returns>The ClientsDto object.</returns>
        public ClientsDto GetEmployee()
        {
            var id = this.Client._id;
            var numbers = this.Client.Addresses.Select(bidResult => bidResult.Number).ToList();
            var streets = this.Client.Addresses.Select(bidResult => bidResult.Street).ToList();
            var postalCodes = this.Client.Addresses.Select(bidResult => bidResult.PostalCode).ToList();

            // this.collection.InsertOne(client);
            var builder = Builders<ClientsDto>.Filter;
            var filter = builder.Eq(x => x.FirstName, this.Client.FirstName)
                & builder.Eq(x => x.LastName, this.Client.LastName)
                & builder.Eq(x => x.Addresses, this.Client.Addresses)
                & builder.Eq(x => x._id, this.Client._id)
                & builder.ElemMatch(x => x.Addresses, el => numbers.Contains(el.Number)
                && (streets.Contains(el.Street)
                && postalCodes.Contains(el.PostalCode)));

            // Testing of mongodb filters var renderedFilter =
            // filter.Render(this.collection.DocumentSerializer, this.collection.Settings.SerializerRegistry);
            var result = this.collection.FindAsync(filter).Result.ToList();
            this.matchFound = result.Count > 0 ? result[0] : null;
            return result.Count > 0 ? result[0] : null;
        }

        /// <summary>
        /// The update element in database function.
        /// </summary>
        /// <param name="client">client to be updated.</param>
        /// <param name="newClient">new value for the client.</param>
        public void UpdateClient(ClientsDto client, ClientsDto newClient)
        {
            var numbers = client.Addresses.Select(bidResult => bidResult.Number).ToList();
            var streets = client.Addresses.Select(bidResult => bidResult.Street).ToList();
            var postalCodes = client.Addresses.Select(bidResult => bidResult.PostalCode).ToList();

            var builder = Builders<ClientsDto>.Filter;
            var filter = builder.Eq(x => x.FirstName, client.FirstName)
                & builder.Eq(x => x.LastName, client.LastName)
                & builder.Eq(x => x.Addresses, client.Addresses)
                & builder.ElemMatch(x => x.Addresses, el => numbers.Contains(el.Number) && streets.Contains(el.Street) && postalCodes.Contains(el.PostalCode));

            var update = Builders<ClientsDto>.Update.Set(s => s.FirstName, newClient.FirstName)
                                                    .Set(s => s.LastName, newClient.LastName)
                                                    .Set(s => s.Addresses, newClient.Addresses);

            this.collection.UpdateOneAsync(filter, update).Wait();
        }
    }
}