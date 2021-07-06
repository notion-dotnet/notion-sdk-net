﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Notion.Client.Extensions;
using Notion.Client.http;

namespace Notion.Client
{
    public class RestClient : IRestClient
    {
        private HttpClient _httpClient;
        private readonly ClientOptions _options;

        protected readonly JsonSerializerSettings defaultSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        public RestClient(ClientOptions options)
        {
            _options = MergeOptions(options);
        }

        private static ClientOptions MergeOptions(ClientOptions options)
        {
            return new ClientOptions
            {
                AuthToken = options.AuthToken,
                BaseUrl = options.BaseUrl ?? Constants.BASE_URL,
                NotionVersion = options.NotionVersion ?? Constants.DEFAULT_NOTION_VERSION
            };
        }

        public async Task<T> GetAsync<T>(
            string uri,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            CancellationToken cancellationToken = default)
        {
            var response = await SendAsync(uri, HttpMethod.Get, queryParams, headers, cancellationToken: cancellationToken);

            return await response.ParseStreamAsync<T>(serializerSettings);
        }

        private static async Task<Exception> BuildException(HttpResponseMessage response)
        {
            var errorBody = await response.Content.ReadAsStringAsync();

            NotionApiErrorResponse errorResponse = null;
            if (!string.IsNullOrWhiteSpace(errorBody))
            {
                try
                {
                    errorResponse = JsonConvert.DeserializeObject<NotionApiErrorResponse>(errorBody);
                }
                catch
                {
                }
            }

            return new NotionApiException(response.StatusCode, errorResponse?.ErrorCode, errorResponse.Message);
        }

        private async Task<HttpResponseMessage> SendAsync(
            string requestUri,
            HttpMethod httpMethod,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            Action<HttpRequestMessage> attachContent = null,
            CancellationToken cancellationToken = default)
        {
            EnsureHttpClient();

            requestUri = AddQueryString(requestUri, queryParams);

            HttpRequestMessage httpRequest = new HttpRequestMessage(httpMethod, requestUri);
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.AuthToken);
            httpRequest.Headers.Add("Notion-Version", _options.NotionVersion);

            if (headers != null)
            {
                AddHeaders(httpRequest, headers);
            }

            attachContent?.Invoke(httpRequest);

            var response = await _httpClient.SendAsync(httpRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw await BuildException(response);
            }

            return response;
        }

        private static void AddHeaders(HttpRequestMessage request, IDictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        public async Task<T> PostAsync<T>(
            string uri,
            object body,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            CancellationToken cancellationToken = default)
        {
            void AttachContent(HttpRequestMessage httpRequest)
            {
                httpRequest.Content = new StringContent(JsonConvert.SerializeObject(body, defaultSerializerSettings), Encoding.UTF8, "application/json");
            }

            var response = await SendAsync(uri, HttpMethod.Post, queryParams, headers, AttachContent, cancellationToken: cancellationToken);

            return await response.ParseStreamAsync<T>(serializerSettings);
        }

        public async Task<T> PatchAsync<T>(string uri, object body, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null, JsonSerializerSettings serializerSettings = null, CancellationToken cancellationToken = default)
        {
            void AttachContent(HttpRequestMessage httpRequest)
            {
                var serializedBody = JsonConvert.SerializeObject(body, defaultSerializerSettings);
                httpRequest.Content = new StringContent(serializedBody, Encoding.UTF8, "application/json");
            }

            var response = await SendAsync(uri, new HttpMethod("PATCH"), queryParams, headers, AttachContent, cancellationToken: cancellationToken);

            return await response.ParseStreamAsync<T>(serializerSettings);
        }

        private HttpClient EnsureHttpClient()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri(_options.BaseUrl);
            }

            return _httpClient;
        }

        private static string AddQueryString(string uri, IDictionary<string, string> queryParams)
        {
            return queryParams == null ? uri : QueryHelpers.AddQueryString(uri, queryParams);
        }
    }
}
