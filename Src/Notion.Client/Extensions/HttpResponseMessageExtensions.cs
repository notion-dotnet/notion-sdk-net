using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Notion.Client.Extensions
{
    internal static class HttpResponseMessageExtensions
    {
        internal static async Task<T> ParseStreamAsync<T>(this HttpResponseMessage response, JsonSerializerSettings serializerSettings = null)
        {
            using (Stream stream = await response.Content.ReadAsStreamAsync())
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    using (JsonReader jsonReader = new JsonTextReader(streamReader))
                    {

                        JsonSerializer serializer = null;

                        if (serializerSettings == null)
                        {
                            serializer = JsonSerializer.CreateDefault();
                        }
                        else
                        {
                            serializer = JsonSerializer.Create(serializerSettings);
                        }

                        return serializer.Deserialize<T>(jsonReader);
                    }
                }
            }
        }
    }
}