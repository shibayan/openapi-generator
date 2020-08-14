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
    /// User
    /// </summary>
    public partial class User : IEquatable<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="username">username.</param>
        /// <param name="firstName">firstName.</param>
        /// <param name="lastName">lastName.</param>
        /// <param name="email">email.</param>
        /// <param name="password">password.</param>
        /// <param name="phone">phone.</param>
        /// <param name="userStatus">User Status.</param>
        public User(long? id = default, string? username = default, string? firstName = default, string? lastName = default, string? email = default, string? password = default, string? phone = default, int? userStatus = default)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
            UserStatus = userStatus;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string? Username { get; set; }

        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string? Password { get; set; }

        /// <summary>
        /// Gets or Sets Phone
        /// </summary>
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string? Phone { get; set; }

        /// <summary>
        /// User Status
        /// </summary>
        /// <value>User Status</value>
        [JsonProperty("userStatus", NullValueHandling = NullValueHandling.Ignore)]
        public int? UserStatus { get; set; }

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
            return Equals((User)obj);
        }

        /// <summary>
        /// Returns true if User instances are equal
        /// </summary>
        /// <param name="other">Instance of User to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(User? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return 
                Id == other.Id &&
                Username == other.Username &&
                FirstName == other.FirstName &&
                LastName == other.LastName &&
                Email == other.Email &&
                Password == other.Password &&
                Phone == other.Phone &&
                UserStatus == other.UserStatus;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Username);
            hashCode.Add(FirstName);
            hashCode.Add(LastName);
            hashCode.Add(Email);
            hashCode.Add(Password);
            hashCode.Add(Phone);
            hashCode.Add(UserStatus);
            return hashCode.ToHashCode();
        }
    }
}
