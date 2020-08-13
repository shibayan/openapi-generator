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
    /// NullableClass
    /// </summary>
    public partial class NullableClass : Dictionary<string, object>, IEquatable<NullableClass>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableClass" /> class.
        /// </summary>
        /// <param name="integerProp">integerProp.</param>
        /// <param name="numberProp">numberProp.</param>
        /// <param name="booleanProp">booleanProp.</param>
        /// <param name="stringProp">stringProp.</param>
        /// <param name="dateProp">dateProp.</param>
        /// <param name="datetimeProp">datetimeProp.</param>
        /// <param name="arrayNullableProp">arrayNullableProp.</param>
        /// <param name="arrayAndItemsNullableProp">arrayAndItemsNullableProp.</param>
        /// <param name="arrayItemsNullable">arrayItemsNullable.</param>
        /// <param name="objectNullableProp">objectNullableProp.</param>
        /// <param name="objectAndItemsNullableProp">objectAndItemsNullableProp.</param>
        /// <param name="objectItemsNullable">objectItemsNullable.</param>
        public NullableClass(int? integerProp = default, decimal? numberProp = default, bool? booleanProp = default, string? stringProp = default, DateTime? dateProp = default, DateTime? datetimeProp = default, IReadOnlyList<object>? arrayNullableProp = default, IReadOnlyList<object>? arrayAndItemsNullableProp = default, IReadOnlyList<object>? arrayItemsNullable = default, IDictionary<string, object>? objectNullableProp = default, IDictionary<string, object>? objectAndItemsNullableProp = default, IDictionary<string, object>? objectItemsNullable = default) : base()
        {
            IntegerProp = integerProp;
            NumberProp = numberProp;
            BooleanProp = booleanProp;
            StringProp = stringProp;
            DateProp = dateProp;
            DatetimeProp = datetimeProp;
            ArrayNullableProp = arrayNullableProp;
            ArrayAndItemsNullableProp = arrayAndItemsNullableProp;
            ArrayItemsNullable = arrayItemsNullable;
            ObjectNullableProp = objectNullableProp;
            ObjectAndItemsNullableProp = objectAndItemsNullableProp;
            ObjectItemsNullable = objectItemsNullable;
        }

        /// <summary>
        /// Gets or Sets IntegerProp
        /// </summary>
        [JsonProperty("integer_prop", NullValueHandling = NullValueHandling.Ignore)]
        public int? IntegerProp { get; set; }

        /// <summary>
        /// Gets or Sets NumberProp
        /// </summary>
        [JsonProperty("number_prop", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? NumberProp { get; set; }

        /// <summary>
        /// Gets or Sets BooleanProp
        /// </summary>
        [JsonProperty("boolean_prop", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BooleanProp { get; set; }

        /// <summary>
        /// Gets or Sets StringProp
        /// </summary>
        [JsonProperty("string_prop", NullValueHandling = NullValueHandling.Ignore)]
        public string? StringProp { get; set; }

        /// <summary>
        /// Gets or Sets DateProp
        /// </summary>
        [JsonProperty("date_prop", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(Org.OpenAPITools.Client.OpenAPIDateConverter))]
        public DateTime? DateProp { get; set; }

        /// <summary>
        /// Gets or Sets DatetimeProp
        /// </summary>
        [JsonProperty("datetime_prop", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DatetimeProp { get; set; }

        /// <summary>
        /// Gets or Sets ArrayNullableProp
        /// </summary>
        [JsonProperty("array_nullable_prop", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<object>? ArrayNullableProp { get; set; }

        /// <summary>
        /// Gets or Sets ArrayAndItemsNullableProp
        /// </summary>
        [JsonProperty("array_and_items_nullable_prop", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<object>? ArrayAndItemsNullableProp { get; set; }

        /// <summary>
        /// Gets or Sets ArrayItemsNullable
        /// </summary>
        [JsonProperty("array_items_nullable", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<object>? ArrayItemsNullable { get; set; }

        /// <summary>
        /// Gets or Sets ObjectNullableProp
        /// </summary>
        [JsonProperty("object_nullable_prop", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, object>? ObjectNullableProp { get; set; }

        /// <summary>
        /// Gets or Sets ObjectAndItemsNullableProp
        /// </summary>
        [JsonProperty("object_and_items_nullable_prop", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, object>? ObjectAndItemsNullableProp { get; set; }

        /// <summary>
        /// Gets or Sets ObjectItemsNullable
        /// </summary>
        [JsonProperty("object_items_nullable", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, object>? ObjectItemsNullable { get; set; }

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
            return Equals((NullableClass)obj);
        }

        /// <summary>
        /// Returns true if NullableClass instances are equal
        /// </summary>
        /// <param name="other">Instance of NullableClass to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NullableClass? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) &&
                IntegerProp == other.IntegerProp &&base.Equals(other) &&
                NumberProp == other.NumberProp &&base.Equals(other) &&
                BooleanProp == other.BooleanProp &&base.Equals(other) &&
                StringProp == other.StringProp &&base.Equals(other) &&
                DateProp == other.DateProp &&base.Equals(other) &&
                DatetimeProp == other.DatetimeProp &&base.Equals(other) &&
                Equals(ArrayNullableProp, other.ArrayNullableProp) &&base.Equals(other) &&
                Equals(ArrayAndItemsNullableProp, other.ArrayAndItemsNullableProp) &&base.Equals(other) &&
                Equals(ArrayItemsNullable, other.ArrayItemsNullable) &&base.Equals(other) &&
                Equals(ObjectNullableProp, other.ObjectNullableProp) &&base.Equals(other) &&
                Equals(ObjectAndItemsNullableProp, other.ObjectAndItemsNullableProp) &&base.Equals(other) &&
                Equals(ObjectItemsNullable, other.ObjectItemsNullable);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(IntegerProp);
            hashCode.Add(NumberProp);
            hashCode.Add(BooleanProp);
            hashCode.Add(StringProp);
            hashCode.Add(DateProp);
            hashCode.Add(DatetimeProp);
            hashCode.Add(ArrayNullableProp);
            hashCode.Add(ArrayAndItemsNullableProp);
            hashCode.Add(ArrayItemsNullable);
            hashCode.Add(ObjectNullableProp);
            hashCode.Add(ObjectAndItemsNullableProp);
            hashCode.Add(ObjectItemsNullable);
            return base.GetHashCode() ^ hashCode.ToHashCode();
        }
    }
}
