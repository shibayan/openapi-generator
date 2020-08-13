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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Org.OpenAPITools.Models
{
    /// <summary>
    /// Model for testing reserved words
    /// </summary>
    public partial class Return : IEquatable<Return>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Return" /> class.
        /// </summary>
        /// <param name="_return">_return.</param>
        public Return(int? _return = default)
        {
            _Return = _return;
        }

        /// <summary>
        /// Gets or Sets _Return
        /// </summary>
        [JsonProperty("return", NullValueHandling = NullValueHandling.Ignore)]
        public int? _Return { get; set; }

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
            return Equals((Return)obj);
        }

        /// <summary>
        /// Returns true if Return instances are equal
        /// </summary>
        /// <param name="other">Instance of Return to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Return? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return 
                _Return == other._Return;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(_Return);
            return hashCode.ToHashCode();
        }
    }
}
