using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    /// <summary>
    /// An object describing the identifier, type, and value of a page property.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(CheckboxPropertyValue), PropertyValueType.Checkbox)]
    [JsonSubtypes.KnownSubType(typeof(CreatedByPropertyValue), PropertyValueType.CreatedBy)]
    [JsonSubtypes.KnownSubType(typeof(CreatedTimePropertyValue), PropertyValueType.CreatedTime)]
    [JsonSubtypes.KnownSubType(typeof(DatePropertyValue), PropertyValueType.Date)]
    [JsonSubtypes.KnownSubType(typeof(EmailPropertyValue), PropertyValueType.Email)]
    [JsonSubtypes.KnownSubType(typeof(FilesPropertyValue), PropertyValueType.Files)]
    [JsonSubtypes.KnownSubType(typeof(FormulaPropertyValue), PropertyValueType.Formula)]
    [JsonSubtypes.KnownSubType(typeof(LastEditedByPropertyValue), PropertyValueType.LastEditedBy)]
    [JsonSubtypes.KnownSubType(typeof(LastEditedTimePropertyValue), PropertyValueType.LastEditedTime)]
    [JsonSubtypes.KnownSubType(typeof(MultiSelectPropertyValue), PropertyValueType.MultiSelect)]
    [JsonSubtypes.KnownSubType(typeof(NumberPropertyValue), PropertyValueType.Number)]
    [JsonSubtypes.KnownSubType(typeof(PeoplePropertyValue), PropertyValueType.People)]
    [JsonSubtypes.KnownSubType(typeof(PhoneNumberPropertyValue), PropertyValueType.PhoneNumber)]
    [JsonSubtypes.KnownSubType(typeof(RelationPropertyValue), PropertyValueType.Relation)]
    [JsonSubtypes.KnownSubType(typeof(RichTextPropertyValue), PropertyValueType.RichText)]
    [JsonSubtypes.KnownSubType(typeof(RollupPropertyValue), PropertyValueType.Rollup)]
    [JsonSubtypes.KnownSubType(typeof(SelectPropertyValue), PropertyValueType.Select)]
    [JsonSubtypes.KnownSubType(typeof(TitlePropertyValue), PropertyValueType.Title)]
    [JsonSubtypes.KnownSubType(typeof(UrlPropertyValue), PropertyValueType.Url)]
    public class PropertyValue
    {
        /// <summary>
        /// Underlying identifier of the property.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public virtual PropertyValueType Type { get; }
    }
}
