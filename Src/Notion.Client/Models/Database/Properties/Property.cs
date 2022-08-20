using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(CheckboxProperty), PropertyType.Checkbox)]
    [JsonSubtypes.KnownSubType(typeof(CreatedByProperty), PropertyType.CreatedBy)]
    [JsonSubtypes.KnownSubType(typeof(CreatedTimeProperty), PropertyType.CreatedTime)]
    [JsonSubtypes.KnownSubType(typeof(DateProperty), PropertyType.Date)]
    [JsonSubtypes.KnownSubType(typeof(EmailProperty), PropertyType.Email)]
    [JsonSubtypes.KnownSubType(typeof(FilesProperty), PropertyType.Files)]
    [JsonSubtypes.KnownSubType(typeof(FormulaProperty), PropertyType.Formula)]
    [JsonSubtypes.KnownSubType(typeof(LastEditedByProperty), PropertyType.LastEditedBy)]
    [JsonSubtypes.KnownSubType(typeof(LastEditedTimeProperty), PropertyType.LastEditedTime)]
    [JsonSubtypes.KnownSubType(typeof(MultiSelectProperty), PropertyType.MultiSelect)]
    [JsonSubtypes.KnownSubType(typeof(NumberProperty), PropertyType.Number)]
    [JsonSubtypes.KnownSubType(typeof(PeopleProperty), PropertyType.People)]
    [JsonSubtypes.KnownSubType(typeof(PhoneNumberProperty), PropertyType.PhoneNumber)]
    [JsonSubtypes.KnownSubType(typeof(RelationProperty), PropertyType.Relation)]
    [JsonSubtypes.KnownSubType(typeof(RichTextProperty), PropertyType.RichText)]
    [JsonSubtypes.KnownSubType(typeof(RollupProperty), PropertyType.Rollup)]
    [JsonSubtypes.KnownSubType(typeof(SelectProperty), PropertyType.Select)]
    [JsonSubtypes.KnownSubType(typeof(StatusProperty), PropertyType.Status)]
    [JsonSubtypes.KnownSubType(typeof(TitleProperty), PropertyType.Title)]
    [JsonSubtypes.KnownSubType(typeof(UrlProperty), PropertyType.Url)]
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
