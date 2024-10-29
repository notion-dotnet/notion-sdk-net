using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CheckboxProperty), PropertyType.Checkbox)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CreatedByProperty), PropertyType.CreatedBy)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CreatedTimeProperty), PropertyType.CreatedTime)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DateProperty), PropertyType.Date)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(EmailProperty), PropertyType.Email)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FilesProperty), PropertyType.Files)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FormulaProperty), PropertyType.Formula)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LastEditedByProperty), PropertyType.LastEditedBy)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LastEditedTimeProperty), PropertyType.LastEditedTime)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(MultiSelectProperty), PropertyType.MultiSelect)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(NumberProperty), PropertyType.Number)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PeopleProperty), PropertyType.People)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PhoneNumberProperty), PropertyType.PhoneNumber)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RelationProperty), PropertyType.Relation)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RichTextProperty), PropertyType.RichText)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RollupProperty), PropertyType.Rollup)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(SelectProperty), PropertyType.Select)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(StatusProperty), PropertyType.Status)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TitleProperty), PropertyType.Title)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UrlProperty), PropertyType.Url)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UniqueIdProperty), PropertyType.UniqueId)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ButtonProperty), PropertyType.Button)]
    public class Property
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual PropertyType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
