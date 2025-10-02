using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IRestClient
    {
        Task<T> GetAsync<T>(
            string uri,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            CancellationToken cancellationToken = default);

        Task<T> PostAsync<T>(
            string uri,
            object body,
            IEnumerable<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            IBasicAuthenticationParameters basicAuthenticationParameters = null,
            CancellationToken cancellationToken = default);

        Task<T> PatchAsync<T>(
            string uri,
            object body,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            JsonSerializerSettings serializerSettings = null,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            string uri,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null,
            CancellationToken cancellationToken = default);

        Task<RestClient.UploadResponse> Upload(string filePath, JsonSerializerSettings serializerSettings = null);
        Task<RestClient.UploadResponse> Upload(Stream stream, string filename, JsonSerializerSettings serializerSettings = null);
    }
}
