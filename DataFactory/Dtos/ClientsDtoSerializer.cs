// <copyright file="ClientsDtoSerializer.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace DataFactory.Configuration
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.Serializers;

    /// <summary>
    /// The ClientsDtoSerializer class.
    /// </summary>
    [BsonSerializer(typeof(ClientsDtoSerializer))]
    public class ClientsDtoSerializer : SerializerBase<List<ClientAddressDto>>, IBsonDocumentSerializer, IBsonArraySerializer
    {
        /// <summary>
        /// Tries to get the serialization info for the individual items of the array.
        /// </summary>
        /// <param name="serializationInfo">The serialization information.</param>
        /// <returns>
        /// <c>true</c> if the serialization info exists; otherwise <c>false</c>.
        /// </returns>
        public bool TryGetItemSerializationInfo(out BsonSerializationInfo serializationInfo)
        {
            const string ElementName = null;
            var serializer = BsonSerializer.LookupSerializer(typeof(ClientAddressDto));
            const Type NominalType = null;
            serializationInfo = new BsonSerializationInfo(ElementName, serializer, NominalType);
            return true;
        }

        /// <summary>
        /// The TryGetMemberSerializationInfo.
        /// </summary>
        /// <param name="memberName">The memberName.</param>
        /// <param name="serializationInfo">The serializationInfo.</param>
        /// <returns>true in case there is serialization info for that member.</returns>
        public bool TryGetMemberSerializationInfo(string memberName, out BsonSerializationInfo serializationInfo)
        {
            switch (memberName)
            {
                case "Street":
                    serializationInfo = new BsonSerializationInfo("Street", new ObjectIdSerializer(), typeof(string));
                    return true;

                case "Number":
                    serializationInfo = new BsonSerializationInfo("Number", new StringSerializer(), typeof(string));
                    return true;

                case "PostalCode":
                    serializationInfo = new BsonSerializationInfo("PostalCode", new StringSerializer(), typeof(string));
                    return true;

                default:
                    serializationInfo = null;
                    return false;
            }
        }

        /// <summary>
        /// The Serialize function.
        /// </summary>
        /// <param name="context">The context parameter.</param>
        /// <param name="args">The arguments parameter.</param>
        /// <param name="value">The value parameter.</param>
        public override void Serialize(MongoDB.Bson.Serialization.BsonSerializationContext context, MongoDB.Bson.Serialization.BsonSerializationArgs args, List<ClientAddressDto> value)
        {
            context?.Writer.WriteStartArray();
            foreach (ClientAddressDto mvnt in value)
            {
                context.Writer.WriteStartDocument();
                context.Writer.WriteName("Street");
                context.Writer.WriteString(mvnt.Street);
                context.Writer.WriteName("Number");
                context.Writer.WriteString(mvnt.Number);
                context.Writer.WriteName("PostalCode");
                context.Writer.WriteString(mvnt.PostalCode);
                context.Writer.WriteEndDocument();
            }

            context.Writer.WriteEndArray();
        }

        /// <summary>
        /// The Deserialize function.
        /// </summary>
        /// <param name="context">The context parameter.</param>
        /// <param name="args">The arguments parameter.</param>
        /// <returns>The result of the deserialization of the element.</returns>
        public override List<ClientAddressDto> Deserialize(MongoDB.Bson.Serialization.BsonDeserializationContext context, MongoDB.Bson.Serialization.BsonDeserializationArgs args)
        {
            context?.Reader.ReadStartArray();

            var result = new List<ClientAddressDto>();

            while (true)
            {
                try
                {
                    // this catch block only need to identify the end of the Array
                    context.Reader.ReadStartDocument();
                }
                catch (Exception)
                {
                    context.Reader.ReadEndArray();
                    break;
                }

                var street = context.Reader.ReadString();
                var number = context.Reader.ReadString();
                var postalCode = context.Reader.ReadString();

                result.Add(new ClientAddressDto(street, number, postalCode));

                context.Reader.ReadEndDocument();
            }

            return result;
        }
    }
}