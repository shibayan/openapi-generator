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
using System.IO;
using System.Linq;

using Xunit;

using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Models;

namespace Org.OpenAPITools.Test
{
    /// <summary>
    ///  Class for testing FakeApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class FakeApiTests : IDisposable
    {
        private FakeApi instance;

        public FakeApiTests()
        {
            instance = new FakeApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of FakeApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' FakeApi
            //Assert.IsType(typeof(FakeApi), instance, "instance is a FakeApi");
        }

        
        /// <summary>
        /// Test FakeHealthGet
        /// </summary>
        [Fact]
        public void FakeHealthGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.FakeHealthGet();
            //Assert.IsType<HealthCheckResult> (response, "response is HealthCheckResult");
        }
        
        /// <summary>
        /// Test FakeHttpSignatureTest
        /// </summary>
        [Fact]
        public void FakeHttpSignatureTestTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Pet pet = null;
            //string query1 = null;
            //string header1 = null;
            //instance.FakeHttpSignatureTest(pet, query1, header1);
            
        }
        
        /// <summary>
        /// Test FakeOuterBooleanSerialize
        /// </summary>
        [Fact]
        public void FakeOuterBooleanSerializeTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //bool body = null;
            //var response = instance.FakeOuterBooleanSerialize(body);
            //Assert.IsType<bool> (response, "response is bool");
        }
        
        /// <summary>
        /// Test FakeOuterCompositeSerialize
        /// </summary>
        [Fact]
        public void FakeOuterCompositeSerializeTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //OuterComposite outerComposite = null;
            //var response = instance.FakeOuterCompositeSerialize(outerComposite);
            //Assert.IsType<OuterComposite> (response, "response is OuterComposite");
        }
        
        /// <summary>
        /// Test FakeOuterNumberSerialize
        /// </summary>
        [Fact]
        public void FakeOuterNumberSerializeTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //decimal body = null;
            //var response = instance.FakeOuterNumberSerialize(body);
            //Assert.IsType<decimal> (response, "response is decimal");
        }
        
        /// <summary>
        /// Test FakeOuterStringSerialize
        /// </summary>
        [Fact]
        public void FakeOuterStringSerializeTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string body = null;
            //var response = instance.FakeOuterStringSerialize(body);
            //Assert.IsType<string> (response, "response is string");
        }
        
        /// <summary>
        /// Test TestBodyWithFileSchema
        /// </summary>
        [Fact]
        public void TestBodyWithFileSchemaTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //FileSchemaTestClass fileSchemaTestClass = null;
            //instance.TestBodyWithFileSchema(fileSchemaTestClass);
            
        }
        
        /// <summary>
        /// Test TestBodyWithQueryParams
        /// </summary>
        [Fact]
        public void TestBodyWithQueryParamsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string query = null;
            //User user = null;
            //instance.TestBodyWithQueryParams(query, user);
            
        }
        
        /// <summary>
        /// Test TestClientModel
        /// </summary>
        [Fact]
        public void TestClientModelTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ModelClient modelClient = null;
            //var response = instance.TestClientModel(modelClient);
            //Assert.IsType<ModelClient> (response, "response is ModelClient");
        }
        
        /// <summary>
        /// Test TestEndpointParameters
        /// </summary>
        [Fact]
        public void TestEndpointParametersTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //decimal number = null;
            //double _double = null;
            //string patternWithoutDelimiter = null;
            //byte[] _byte = null;
            //int integer = null;
            //int int32 = null;
            //long int64 = null;
            //float _float = null;
            //string _string = null;
            //System.IO.Stream binary = null;
            //DateTime date = null;
            //DateTime dateTime = null;
            //string password = null;
            //string callback = null;
            //instance.TestEndpointParameters(number, _double, patternWithoutDelimiter, _byte, integer, int32, int64, _float, _string, binary, date, dateTime, password, callback);
            
        }
        
        /// <summary>
        /// Test TestEnumParameters
        /// </summary>
        [Fact]
        public void TestEnumParametersTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //IReadOnlyList<string> enumHeaderStringArray = null;
            //string enumHeaderString = null;
            //IReadOnlyList<string> enumQueryStringArray = null;
            //string enumQueryString = null;
            //int enumQueryInteger = null;
            //double enumQueryDouble = null;
            //IReadOnlyList<string> enumFormStringArray = null;
            //string enumFormString = null;
            //instance.TestEnumParameters(enumHeaderStringArray, enumHeaderString, enumQueryStringArray, enumQueryString, enumQueryInteger, enumQueryDouble, enumFormStringArray, enumFormString);
            
        }
        
        /// <summary>
        /// Test TestGroupParameters
        /// </summary>
        [Fact]
        public void TestGroupParametersTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int requiredStringGroup = null;
            //bool requiredBooleanGroup = null;
            //long requiredInt64Group = null;
            //int stringGroup = null;
            //bool booleanGroup = null;
            //long int64Group = null;
            //instance.TestGroupParameters(requiredStringGroup, requiredBooleanGroup, requiredInt64Group, stringGroup, booleanGroup, int64Group);
            
        }
        
        /// <summary>
        /// Test TestInlineAdditionalProperties
        /// </summary>
        [Fact]
        public void TestInlineAdditionalPropertiesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //IDictionary<string, string> requestBody = null;
            //instance.TestInlineAdditionalProperties(requestBody);
            
        }
        
        /// <summary>
        /// Test TestJsonFormData
        /// </summary>
        [Fact]
        public void TestJsonFormDataTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string param = null;
            //string param2 = null;
            //instance.TestJsonFormData(param, param2);
            
        }
        
        /// <summary>
        /// Test TestQueryParameterCollectionFormat
        /// </summary>
        [Fact]
        public void TestQueryParameterCollectionFormatTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //IReadOnlyList<string> pipe = null;
            //IReadOnlyList<string> ioutil = null;
            //IReadOnlyList<string> http = null;
            //IReadOnlyList<string> url = null;
            //IReadOnlyList<string> context = null;
            //instance.TestQueryParameterCollectionFormat(pipe, ioutil, http, url, context);
            
        }
        
    }
}
