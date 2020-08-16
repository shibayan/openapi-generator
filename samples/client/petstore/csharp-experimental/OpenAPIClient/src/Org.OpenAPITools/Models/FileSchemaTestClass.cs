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
    /// FileSchemaTestClass
    /// </summary>
    public partial class FileSchemaTestClass : IEquatable<FileSchemaTestClass>
    {
        /// <summary>
        /// Gets or Sets File
        /// </summary>
        [JsonProperty("file", NullValueHandling = NullValueHandling.Ignore)]
        public File? File { get; set; }

        /// <summary>
        /// Gets or Sets Files
        /// </summary>
        [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<File>? Files { get; set; }

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
            return Equals((FileSchemaTestClass)obj);
        }

        /// <summary>
        /// Returns true if FileSchemaTestClass instances are equal
        /// </summary>
        /// <param name="other">Instance of FileSchemaTestClass to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FileSchemaTestClass? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return 
                Equals(File, other.File) &&
                Equals(Files, other.Files);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(File);
            hashCode.Add(Files);
            return hashCode.ToHashCode();
        }
    }
}
