using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IIntrospectTokenBodyParameters
    {
        /// <summary>
        /// The access token
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; }
    }
}
