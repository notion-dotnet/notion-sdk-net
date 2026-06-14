using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CheckboxProperty), PropertyType.CheckboxValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CreatedByProperty), PropertyType.CreatedByValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CreatedTimeProperty), PropertyType.CreatedTimeValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DateProperty), PropertyType.DateValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(EmailProperty), PropertyType.EmailValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FilesProperty), PropertyType.FilesValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FormulaProperty), PropertyType.FormulaValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LastEditedByProperty), PropertyType.LastEditedByValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LastEditedTimeProperty), PropertyType.LastEditedTimeValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(MultiSelectProperty), PropertyType.MultiSelectValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(NumberProperty), PropertyType.NumberValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PeopleProperty), PropertyType.PeopleValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PhoneNumberProperty), PropertyType.PhoneNumberValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RelationProperty), PropertyType.RelationValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RichTextProperty), PropertyType.RichTextValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RollupProperty), PropertyType.RollupValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(SelectProperty), PropertyType.SelectValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(StatusProperty), PropertyType.StatusValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TitleProperty), PropertyType.TitleValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UrlProperty), PropertyType.UrlValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UniqueIdProperty), PropertyType.UniqueIdValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ButtonProperty), PropertyType.ButtonValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(VerificationProperty), PropertyType.VerificationValue)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PlaceProperty), PropertyType.PlaceValue)]
    [JsonSubtypes.FallBackSubTypeAttribute(typeof(Property))]
    public class Property
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public virtual PropertyType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
