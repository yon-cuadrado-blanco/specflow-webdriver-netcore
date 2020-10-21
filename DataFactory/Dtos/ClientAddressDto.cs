// <copyright file="ClientAddressDto.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace DataFactory.Configuration
{
    /// <summary>
    /// Client Address Dto.
    /// </summary>
    public class ClientAddressDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientAddressDto"/> class.
        /// </summary>
        /// <param name="street">Street name.</param>
        /// <param name="number">Number in the street.</param>
        /// <param name="postalCode">Postal Code.</param>
        public ClientAddressDto(string street, string number, string postalCode)
        {
            this.Street = street;
            this.Number = number;
            this.PostalCode = postalCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientAddressDto"/> class.
        /// </summary>
        public ClientAddressDto()
        {
        }

        /// <summary>
        /// Gets or sets the Street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the Street Number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the Postal Code.
        /// </summary>
        public string PostalCode { get; set; }
    }
}