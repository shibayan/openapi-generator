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
    /// SpecialModelName
    /// </summary>
    public partial class SpecialModelName : IEquatable<SpecialModelName>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialModelName" /> class.
        /// </summary>
        /// <param name="specialPropertyName">specialPropertyName.</param>
        public SpecialModelName(long? specialPropertyName = default)
        {
            SpecialPropertyName = specialPropertyName;
        }

        /// <summary>
        /// Gets or Sets SpecialPropertyName
        /// </summary>
        [JsonProperty("$special[property.name]", NullValueHandling = NullValueHandling.Ignore)]
        public long? SpecialPropertyName { get; set; }

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
            return Equals((SpecialModelName)obj);
        }

        /// <summary>
        /// Returns true if SpecialModelName instances are equal
        /// </summary>
        /// <param name="other">Instance of SpecialModelName to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SpecialModelName? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return 
                SpecialPropertyName == other.SpecialPropertyName;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(SpecialPropertyName);
            return hashCode.ToHashCode();
        }
    }
}
