using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// A Notion user group, as it appears in people property values.
    /// </summary>
    public class Group : IObject, IPeopleValue
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        public ObjectType Object => ObjectType.Group;

        public string Id { get; set; }
    }
}
