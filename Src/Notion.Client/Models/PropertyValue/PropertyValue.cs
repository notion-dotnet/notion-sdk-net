using System.Diagnostics.CodeAnalysis;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     An object describing the identifier, type, and value of a page property.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CheckboxPropertyValue), PropertyValueType.CheckboxValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CreatedByPropertyValue), PropertyValueType.CreatedByValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CreatedTimePropertyValue), PropertyValueType.CreatedTimeValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DatePropertyValue), PropertyValueType.DateValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(EmailPropertyValue), PropertyValueType.EmailValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FilesPropertyValue), PropertyValueType.FilesValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FormulaPropertyValue), PropertyValueType.FormulaValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LastEditedByPropertyValue), PropertyValueType.LastEditedByValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LastEditedTimePropertyValue), PropertyValueType.LastEditedTimeValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(MultiSelectPropertyValue), PropertyValueType.MultiSelectValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(NumberPropertyValue), PropertyValueType.NumberValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PeoplePropertyValue), PropertyValueType.PeopleValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PhoneNumberPropertyValue), PropertyValueType.PhoneNumberValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RelationPropertyValue), PropertyValueType.RelationValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RichTextPropertyValue), PropertyValueType.RichTextValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RollupPropertyValue), PropertyValueType.RollupValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(SelectPropertyValue), PropertyValueType.SelectValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(StatusPropertyValue), PropertyValueType.StatusValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TitlePropertyValue), PropertyValueType.TitleValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UrlPropertyValue), PropertyValueType.UrlValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UniqueIdPropertyValue), PropertyValueType.UniqueIdValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ButtonPropertyValue), PropertyValueType.ButtonValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(VerificationPropertyValue), PropertyValueType.VerificationValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PlacePropertyValue), PropertyValueType.PlaceValue)]
    [JsonSubtypes.FallBackSubTypeAttribute(typeof(PropertyValue))]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnassignedGetOnlyAutoProperty")]
    public class PropertyValue
    {
        /// <summary>
        ///     Underlying identifier of the property.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public virtual PropertyValueType Type { get; }
    }
}
