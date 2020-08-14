/* 
 * OpenAPI Petstore
 *
 * This spec is mainly for testing Petstore server and contains fake endpoints, models. Please do not use this for any other purpose. Special characters: \" \\
 *
 * The version of the OpenAPI document: 1.0.0
 * 
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
    /// DogAllOf
    /// </summary>
    public partial class DogAllOf : IEquatable<DogAllOf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DogAllOf" /> class.
        /// </summary>
        /// <param name="breed">breed.</param>
        public DogAllOf(string? breed = default)
        {
            Breed = breed;
        }

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
            return Equals((DogAllOf)obj);
        }

        /// <summary>
        /// Returns true if DogAllOf instances are equal
        /// </summary>
        /// <param name="other">Instance of DogAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DogAllOf? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return 
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
            return hashCode.ToHashCode();
        }
    }
}
