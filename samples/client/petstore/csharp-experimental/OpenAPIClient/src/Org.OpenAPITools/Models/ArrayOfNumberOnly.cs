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
    /// ArrayOfNumberOnly
    /// </summary>
    public partial class ArrayOfNumberOnly : IEquatable<ArrayOfNumberOnly>
    {
        /// <summary>
        /// Gets or Sets ArrayNumber
        /// </summary>
        [JsonProperty("ArrayNumber", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<decimal>? ArrayNumber { get; set; }

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
            return Equals((ArrayOfNumberOnly)obj);
        }

        /// <summary>
        /// Returns true if ArrayOfNumberOnly instances are equal
        /// </summary>
        /// <param name="other">Instance of ArrayOfNumberOnly to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ArrayOfNumberOnly? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return 
                Equals(ArrayNumber, other.ArrayNumber);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(ArrayNumber);
            return hashCode.ToHashCode();
        }
    }
}
