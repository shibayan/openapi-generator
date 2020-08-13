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
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Models;

namespace Org.OpenAPITools.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AnotherFakeApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnotherFakeApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AnotherFakeApi()
            : this(new Org.OpenAPITools.Client.Configuration())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnotherFakeApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AnotherFakeApi(string basePath)
            : this(new Org.OpenAPITools.Client.Configuration { BasePath = basePath })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnotherFakeApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AnotherFakeApi(Org.OpenAPITools.Client.Configuration configuration)
            : this(new Org.OpenAPITools.Client.ApiClient(configuration), configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnotherFakeApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public AnotherFakeApi(Org.OpenAPITools.Client.ApiClient client, Org.OpenAPITools.Client.IReadableConfiguration configuration)
        {
            this.Client = client;
            this.Configuration = configuration;
        }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Org.OpenAPITools.Client.ApiClient Client { get; }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Org.OpenAPITools.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// To test special tags To test special tags and operation ID starting with number
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="modelClient">client model</param>
        /// <returns>ModelClient</returns>
        public ModelClient Call123TestSpecialTags(ModelClient modelClient)
        {
            var localVarResponse = Call123TestSpecialTagsWithHttpInfo(modelClient);
            return localVarResponse.Data;
        }

        /// <summary>
        /// To test special tags To test special tags and operation ID starting with number
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="modelClient">client model</param>
        /// <returns>ApiResponse of ModelClient</returns>
        public Org.OpenAPITools.Client.ApiResponse<ModelClient> Call123TestSpecialTagsWithHttpInfo(ModelClient modelClient)
        {
            var localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            var contentTypes = new string[]
            {
                "application/json"
            };

            // to determine the Accept header
            var accepts = new string[]
            {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = modelClient;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<ModelClient>("/another-fake/dummy", localVarRequestOptions);

            return localVarResponse;
        }

        /// <summary>
        /// To test special tags To test special tags and operation ID starting with number
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="modelClient">client model</param>
        /// <returns>Task of ModelClient</returns>
        public async System.Threading.Tasks.Task<ModelClient> Call123TestSpecialTagsAsync(ModelClient modelClient)
        {
            var localVarResponse = await Call123TestSpecialTagsWithHttpInfoAsync(modelClient);
            return localVarResponse.Data;
        }

        /// <summary>
        /// To test special tags To test special tags and operation ID starting with number
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="modelClient">client model</param>
        /// <returns>Task of ApiResponse (ModelClient)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<ModelClient>> Call123TestSpecialTagsWithHttpInfoAsync(ModelClient modelClient)
        {
            var localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            var contentTypes = new string[]
            {
                "application/json"
            };

            // to determine the Accept header
            var accepts = new string[]
            {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            
            localVarRequestOptions.Data = modelClient;


            // make the HTTP request

            var localVarResponse = await this.Client.PatchAsync<ModelClient>("/another-fake/dummy", localVarRequestOptions);

            return localVarResponse;
        }

    }
}
