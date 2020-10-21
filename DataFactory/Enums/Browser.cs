// <copyright file="Browser.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace DataFactory.Configuration
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The Browser enum.
    /// </summary>
    public enum Browser
    {
        /// <summary>
        /// The firefox.
        /// </summary>
        [EnumMember(Value = "Firefox")]
        Firefox,

        /// <summary>
        /// The internet explorer 11.
        /// </summary>
        [EnumMember(Value = "IE11")]
        IE11,

        /// <summary>
        /// The chrome desktop.
        /// </summary>
        [EnumMember(Value = "ChromeDesktop")]
        ChromeDesktop,

        /// <summary>
        /// The chrome android 7.
        /// </summary>
        [EnumMember(Value = "ChromeAndroid7")]
        ChromeAndroid7,

        /// <summary>
        /// The chrome android 8.
        /// </summary>
        [EnumMember(Value = "ChromeAndroid8")]
        ChromeAndroid8,

        /// <summary>
        /// The chrome android 9.
        /// </summary>
        [EnumMember(Value = "ChromeAndroid9")]
        ChromeAndroid9,

        /// <summary>
        /// The IOS12.
        /// </summary>
        [EnumMember(Value = "Safari")]
        Safari,
    }
}