using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Fallback deserialization target for <see cref="IObject"/> responses whose
    /// <c>"object"</c> discriminator is not yet recognised by the library.
    /// Preserves the <c>id</c> and <c>object</c> fields; all other properties are ignored.
    /// </summary>
    public class UnknownObject : IObject, ISearchResponseObject, IQueryDataSourceResponseObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public ObjectType Object { get; set; }
    }
}
