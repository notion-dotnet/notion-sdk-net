using System.Diagnostics.CodeAnalysis;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(NumberPropertyItem), "number")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UrlPropertyItem), "url")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(SelectPropertyItem), "select")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(MultiSelectPropertyItem), "multi_select")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(StatusPropertyItem), "status")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DatePropertyItem), "date")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(EmailPropertyItem), "email")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PhoneNumberPropertyItem), "phone_number")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CheckboxPropertyItem), "checkbox")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FilesPropertyItem), "files")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CreatedByPropertyItem), "created_by")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CreatedTimePropertyItem), "created_time")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LastEditedByPropertyItem), "last_edited_by")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LastEditedTimePropertyItem), "last_edited_time")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FormulaPropertyItem), "formula")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TitlePropertyItem), "title")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RichTextPropertyItem), "rich_text")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PeoplePropertyItem), "people")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RelationPropertyItem), "relation")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RollupPropertyItem), "rollup")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public abstract class SimplePropertyItem : IPropertyItemObject
    {
        public string Object => "property_item";

        public abstract string Type { get; }

        public string Id { get; set; }

        public string NextURL { get; set; }
    }
}
