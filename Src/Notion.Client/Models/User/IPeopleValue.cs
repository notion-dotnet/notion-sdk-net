using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// An entry of a people value: either a <see cref="User"/> or a <see cref="Group"/>.
    /// Check the runtime type (or <see cref="Object"/>) to tell them apart.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "object")]
    [JsonSubtypes.KnownSubType(typeof(User), ObjectType.UserValue)]
    [JsonSubtypes.KnownSubType(typeof(Group), ObjectType.GroupValue)]
    [JsonSubtypes.FallBackSubTypeAttribute(typeof(User))]
    public interface IPeopleValue
    {
        [JsonProperty("id")]
        string Id { get; set; }

        [JsonProperty("object")]
        ObjectType Object { get; }

        /// <summary>The user's or group's name. May be null.</summary>
        [JsonProperty("name")]
        string Name { get; set; }
    }
}
