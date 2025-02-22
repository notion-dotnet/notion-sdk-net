using System.Diagnostics.CodeAnalysis;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    /// <summary>
    ///     An object describing the identifier, type, and value of a page property.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CheckboxPropertyValue), PropertyValueType.Checkbox)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CreatedByPropertyValue), PropertyValueType.CreatedBy)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CreatedTimePropertyValue), PropertyValueType.CreatedTime)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DatePropertyValue), PropertyValueType.Date)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(EmailPropertyValue), PropertyValueType.Email)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FilesPropertyValue), PropertyValueType.Files)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FormulaPropertyValue), PropertyValueType.Formula)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LastEditedByPropertyValue), PropertyValueType.LastEditedBy)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LastEditedTimePropertyValue), PropertyValueType.LastEditedTime)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(MultiSelectPropertyValue), PropertyValueType.MultiSelect)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(NumberPropertyValue), PropertyValueType.Number)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PeoplePropertyValue), PropertyValueType.People)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PhoneNumberPropertyValue), PropertyValueType.PhoneNumber)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RelationPropertyValue), PropertyValueType.Relation)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RichTextPropertyValue), PropertyValueType.RichText)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RollupPropertyValue), PropertyValueType.Rollup)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(SelectPropertyValue), PropertyValueType.Select)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(StatusPropertyValue), PropertyValueType.Status)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TitlePropertyValue), PropertyValueType.Title)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UrlPropertyValue), PropertyValueType.Url)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UniqueIdPropertyValue), PropertyValueType.UniqueId)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ButtonPropertyValue), PropertyValueType.Button)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(VerificationPropertyValue), PropertyValueType.Verification)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnassignedGetOnlyAutoProperty")]
    public class PropertyValue
    {
        /// <summary>
        ///     Underlying identifier of the property.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public virtual PropertyValueType Type { get; }
    }
}
