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
    /// NumberOnly
    /// </summary>
    public partial class NumberOnly : IEquatable<NumberOnly>
    {
        /// <summary>
        /// Gets or Sets JustNumber
        /// </summary>
        [JsonProperty("JustNumber", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? JustNumber { get; set; }

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
            return Equals((NumberOnly)obj);
        }

        /// <summary>
        /// Returns true if NumberOnly instances are equal
        /// </summary>
        /// <param name="other">Instance of NumberOnly to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NumberOnly? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return 
                JustNumber == other.JustNumber;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(JustNumber);
            return hashCode.ToHashCode();
        }
    }
}
