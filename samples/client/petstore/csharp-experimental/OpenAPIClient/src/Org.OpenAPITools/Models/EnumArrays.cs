/*
 * OpenAPI Petstore
 *
 * This spec is mainly for testing Petstore server and contains fake endpoints, models. Please do not use this for any other purpose. Special characters: \" \\
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Org.OpenAPITools.Models
{
    /// <summary>
    /// EnumArrays
    /// </summary>
    public partial class EnumArrays : IEquatable<EnumArrays>
    {
        /// <summary>
        /// Defines JustSymbol
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum JustSymbolEnum
        {
            /// <summary>
            /// Enum GreaterThanOrEqualTo for value: >=
            /// </summary>
            [EnumMember(Value = ">=")]
            GreaterThanOrEqualTo = 1,

            /// <summary>
            /// Enum Dollar for value: $
            /// </summary>
            [EnumMember(Value = "$")]
            Dollar = 2

        }

        /// <summary>
        /// Defines ArrayEnum
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ArrayEnumEnum
        {
            /// <summary>
            /// Enum Fish for value: fish
            /// </summary>
            [EnumMember(Value = "fish")]
            Fish = 1,

            /// <summary>
            /// Enum Crab for value: crab
            /// </summary>
            [EnumMember(Value = "crab")]
            Crab = 2

        }


        /// <summary>
        /// Gets or Sets JustSymbol
        /// </summary>
        [JsonProperty("just_symbol", NullValueHandling = NullValueHandling.Ignore)]
        public JustSymbolEnum? JustSymbol { get; set; }

        /// <summary>
        /// Gets or Sets ArrayEnum
        /// </summary>
        [JsonProperty("array_enum", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<ArrayEnumEnum>? ArrayEnum { get; set; }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((EnumArrays)obj);
        }

        /// <summary>
        /// Returns true if EnumArrays instances are equal
        /// </summary>
        /// <param name="other">Instance of EnumArrays to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnumArrays? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return 
                JustSymbol == other.JustSymbol &&
                Equals(ArrayEnum, other.ArrayEnum);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(JustSymbol);
            hashCode.Add(ArrayEnum);
            return hashCode.ToHashCode();
        }
    }
}
