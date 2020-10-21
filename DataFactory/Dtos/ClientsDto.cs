// <copyright file="ClientsDto.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace DataFactory.Configuration
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// The clients DTO.
    /// </summary>
    public class ClientsDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsDto"/> class.
        /// </summary>
        /// <param name="firstName">first name.</param>
        /// <param name="lastName">last name.</param>
        /// <param name="street">street name.</param>
        /// <param name="number">home number.</param>
        /// <param name="postalCode">postal code.</param>
        public ClientsDto(string firstName, string lastName, string street, string number, string postalCode)
        {
            this.Addresses = new List<ClientAddressDto>
            {
                new ClientAddressDto(street, number, postalCode),
            };
            this.FirstName = firstName;
            this.LastName = lastName;
            this._id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsDto"/> class.
        /// </summary>
        /// <param name="firstName">The first name .</param>
        /// <param name="lastName">The last name .</param>
        /// <param name="addresses">The addresses .</param>
        public ClientsDto(string firstName, string lastName, List<ClientAddressDto> addresses)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this._id = Guid.NewGuid();
            this.Addresses = new List<ClientAddressDto>();
            this.Addresses = addresses;
        }

        /// <summary>
        /// Gets or sets the _id
        /// Gets or sets mongoDb id.
        /// </summary>
        public Guid _id { get; set; }

        /// <summary>
        /// Gets or sets the FirstName
        /// Gets or sets gets and sets the First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// Gets or sets gets and sets the Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        /// <value>
        /// The addresses.
        /// </value>
        [BsonSerializer(typeof(ClientsDtoSerializer))]
        public List<ClientAddressDto> Addresses { get; set; }
    }
}