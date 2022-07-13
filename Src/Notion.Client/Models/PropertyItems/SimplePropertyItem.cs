using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(NumberPropertyItem), "number")]
    [JsonSubtypes.KnownSubType(typeof(UrlPropertyItem), "url")]
    [JsonSubtypes.KnownSubType(typeof(SelectPropertyItem), "select")]
    [JsonSubtypes.KnownSubType(typeof(MultiSelectPropertyItem), "multi_select")]
    [JsonSubtypes.KnownSubType(typeof(DatePropertyItem), "date")]
    [JsonSubtypes.KnownSubType(typeof(EmailPropertyItem), "email")]
    [JsonSubtypes.KnownSubType(typeof(PhoneNumberPropertyItem), "phone_number")]
    [JsonSubtypes.KnownSubType(typeof(CheckboxPropertyItem), "checkbox")]
    [JsonSubtypes.KnownSubType(typeof(FilesPropertyItem), "files")]
    [JsonSubtypes.KnownSubType(typeof(CreatedByPropertyItem), "created_by")]
    [JsonSubtypes.KnownSubType(typeof(CreatedTimePropertyItem), "created_time")]
    [JsonSubtypes.KnownSubType(typeof(LastEditedByPropertyItem), "last_edited_by")]
    [JsonSubtypes.KnownSubType(typeof(LastEditedTimePropertyItem), "last_edited_time")]
    [JsonSubtypes.KnownSubType(typeof(FormulaPropertyItem), "formula")]
    [JsonSubtypes.KnownSubType(typeof(TitlePropertyItem), "title")]
    [JsonSubtypes.KnownSubType(typeof(RichTextPropertyItem), "rich_text")]
    [JsonSubtypes.KnownSubType(typeof(PeoplePropertyItem), "people")]
    [JsonSubtypes.KnownSubType(typeof(RelationPropertyItem), "relation")]
    public abstract class SimplePropertyItem : IPropertyItemObject
    {
        public string Object => "property_item";

        public abstract string Type { get; }

        public string Id { get; set; }

        public string NextURL { get; set; }
    }
}
