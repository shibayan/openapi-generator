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
    /// ApiResponse
    /// </summary>
    public partial class ApiResponse : IEquatable<ApiResponse>
    {
        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int? Code { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string? Message { get; set; }

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
            return Equals((ApiResponse)obj);
        }

        /// <summary>
        /// Returns true if ApiResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ApiResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiResponse? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return 
                Code == other.Code &&
                Type == other.Type &&
                Message == other.Message;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Code);
            hashCode.Add(Type);
            hashCode.Add(Message);
            return hashCode.ToHashCode();
        }
    }
}
