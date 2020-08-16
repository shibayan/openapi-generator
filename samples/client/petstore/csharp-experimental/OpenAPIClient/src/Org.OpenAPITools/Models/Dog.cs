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
    /// Dog
    /// </summary>
    public partial class Dog : Animal, IEquatable<Dog>
    {
        /// <summary>
        /// Gets or Sets Breed
        /// </summary>
        [JsonProperty("breed", NullValueHandling = NullValueHandling.Ignore)]
        public string? Breed { get; set; }

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
            return Equals((Dog)obj);
        }

        /// <summary>
        /// Returns true if Dog instances are equal
        /// </summary>
        /// <param name="other">Instance of Dog to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Dog? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) &&
                Breed == other.Breed;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Breed);
            return base.GetHashCode() ^ hashCode.ToHashCode();
        }
    }
}
