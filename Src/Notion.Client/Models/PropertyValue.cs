using System.Collections.Generic;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
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
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public virtual PropertyValueType Type { get; }
    }

    public class RelationPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Relation;

        /// <summary>
        /// Array of page references
        /// </summary>
        public List<ObjectId> Relation { get; set; }
    }

    public class TitlePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Title;
        public List<RichTextBase> Title { get; set; }
    }

    public class RichTextPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.RichText;

        [JsonProperty("rich_text")]
        public List<RichTextBase> RichText { get; set; }
    }

    public class NumberPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Number;
        public double Number { get; set; }
    }

    public class SelectPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Select;
        public SelectOption Select { get; set; }
    }

    public class MultiSelectPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.MultiSelect;

        [JsonProperty("multi_select")]
        public List<SelectOption> MultiSelect { get; set; }
    }

    public class DatePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Date;
        public Date Date { get; set; }
    }

    public class Date
    {
        public string Start { get; set; }
        public string End { get; set; }
    }

    public class FormulaPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Formula;

        public FormulaValue Formula { get; set; }
    }

    public class FormulaValue
    {
        public string Type { get; set; }
        public string String { get; set; }
        public double? Number { get; set; }
        public bool Boolean { get; set; }
        public DatePropertyValue Date { get; set; }
    }

    public class RollupPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Rollup;

        public RollupValue Rollup { get; set; }
    }

    public class RollupValue
    {
        public string Type { get; set; }
        public double Number { get; set; }
        public DatePropertyValue Date { get; set; }

        /// <summary>
        /// Array containing the propert value object will not contain value for Id field
        /// </summary>
        public List<PropertyValue> Array { get; set; }
    }

    public class PeoplePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.People;
        public List<User> People { get; set; }
    }

    public class FilesPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Files;

        public List<FileValue> Files { get; set; }
    }

    public class FileValue
    {
        public string Name { get; set; }
    }

    public class CheckboxPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Checkbox;

        public bool Checkbox { get; set; }
    }

    public class UrlPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Url;

        public string Url { get; set; }
    }

    public class EmailPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Email;

        public string Email { get; set; }
    }

    public class PhoneNumberPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.PhoneNumber;


        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }

    public class CreatedTimePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.CreatedTime;

        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }
    }

    public class CreatedByPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.CreatedBy;

        [JsonProperty("created_by")]
        public User CreatedBy { get; set; }
    }

    public class LastEditedTimePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.LastEditedTime;

        [JsonProperty("last_edited_time")]
        public string LastEditedTime { get; set; }
    }

    public class LastEditedByPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.LastEditedBy;

        [JsonProperty("last_edited_by")]
        public User LastEditedBy { get; set; }
    }

    public enum PropertyValueType
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "rich_text")]
        RichText,

        [EnumMember(Value = "number")]
        Number,

        [EnumMember(Value = "select")]
        Select,

        [EnumMember(Value = "multi_select")]
        MultiSelect,

        [EnumMember(Value = "date")]
        Date,

        [EnumMember(Value = "formula")]
        Formula,

        [EnumMember(Value = "relation")]
        Relation,

        [EnumMember(Value = "rollup")]
        Rollup,

        [EnumMember(Value = "title")]
        Title,

        [EnumMember(Value = "people")]
        People,

        [EnumMember(Value = "files")]
        Files,

        [EnumMember(Value = "checkbox")]
        Checkbox,

        [EnumMember(Value = "url")]
        Url,

        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "phone_number")]
        PhoneNumber,

        [EnumMember(Value = "created_time")]
        CreatedTime,

        [EnumMember(Value = "created_by")]
        CreatedBy,

        [EnumMember(Value = "last_edited_time")]
        LastEditedTime,

        [EnumMember(Value = "last_edited_by")]
        LastEditedBy
    }

}
