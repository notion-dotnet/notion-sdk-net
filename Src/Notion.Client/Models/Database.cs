using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public interface IDatabasesListQueryParmaters : IPaginationParameters
    {

    }

    public class DatabasesListParameters : IDatabasesListQueryParmaters
    {
        public string StartCursor { get; set; }
        public string PageSize { get; set; }
    }


    public interface IDatabaseQueryBodyParameters : IPaginationParameters
    {
        Filter Filter { get; set; }
        List<Sort> Sorts { get; set; }
    }

    public class DatabasesQueryParameters : IDatabaseQueryBodyParameters
    {
        public Filter Filter { get; set; }
        public List<Sort> Sorts { get; set; }
        public string StartCursor { get; set; }
        public string PageSize { get; set; }
    }

    public class Database
    {
        public string Object => "database";
        public string Id { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }


        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }

        public List<RichTextBase> Title { get; set; }

        public Dictionary<string, Property> Properties { get; set; }
    }

    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(RichTextText), RichTextType.Text)]
    [JsonSubtypes.KnownSubType(typeof(RichTextEquation), RichTextType.Equation)]
    [JsonSubtypes.KnownSubType(typeof(RichTextMention), RichTextType.Mention)]
    public class RichTextBase
    {
        [JsonProperty("plain_text")]
        public string PlainText { get; set; }

        public string Href { get; set; }

        public Annotations Annotations { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public virtual RichTextType Type { get; set; }
    }

    public class RichTextText : RichTextBase
    {
        public override RichTextType Type => RichTextType.Text;
        public Text Text { get; set; }
    }

    public class Text
    {
        public string Content { get; set; }
        public Link Link { get; set; }
    }

    public class Link
    {
        public string Type => "url";
        public string Url { get; set; }
    }

    public class RichTextMention : RichTextBase
    {
        public override RichTextType Type => RichTextType.Mention;
        public Mention Mention { get; set; }
    }

    public class Mention
    {
        public string Type { get; set; }
        public User User { get; set; }
        public ObjectId Page { get; set; }
        public ObjectId Database { get; set; }
        public DatePropertyValue Date { get; set; }
    }

    public class ObjectId
    {
        public string Id { get; set; }
    }

    public class RichTextEquation : RichTextBase
    {
        public override RichTextType Type => RichTextType.Equation;
        public Equation Equation { get; set; }
    }

    public class Equation
    {
        public string Expression { get; set; }
    }

    public enum RichTextType
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "text")]
        Text,

        [EnumMember(Value = "mention")]
        Mention,

        [EnumMember(Value = "equation")]
        Equation
    }

    public class Annotations
    {
        [JsonProperty("bold")]
        public bool IsBold { get; set; }

        [JsonProperty("italic")]
        public bool IsItalic { get; set; }

        [JsonProperty("strikethrough")]
        public bool IsStrikeThrough { get; set; }

        [JsonProperty("underline")]
        public bool IsUnderline { get; set; }

        [JsonProperty("code")]
        public bool IsCode { get; set; }

        // color: Color | BackgroundColor
        public string Color { get; set; }
    }

    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(CheckboxProperty), PropertyType.Checkbox)]
    [JsonSubtypes.KnownSubType(typeof(CreatedByProperty), PropertyType.CreatedBy)]
    [JsonSubtypes.KnownSubType(typeof(CreatedTimeProperty), PropertyType.CreatedTime)]
    [JsonSubtypes.KnownSubType(typeof(DateProperty), PropertyType.Date)]
    [JsonSubtypes.KnownSubType(typeof(EmailProperty), PropertyType.Email)]
    [JsonSubtypes.KnownSubType(typeof(FileProperty), PropertyType.File)]
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
    [JsonSubtypes.KnownSubType(typeof(TitleProperty), PropertyType.Title)]
    [JsonSubtypes.KnownSubType(typeof(UrlProperty), PropertyType.Url)]
    public class Property
    {
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public virtual PropertyType Type { get; set; }
    }

    public class TitleProperty : Property
    {
        public override PropertyType Type => PropertyType.Title;
        public Dictionary<string, object> Title { get; set; }
    }

    public class RichTextProperty : Property
    {
        public override PropertyType Type => PropertyType.RichText;

        [JsonProperty("rich_text")]
        public Dictionary<string, object> RichText { get; set; }
    }

    public class NumberProperty : Property
    {
        public override PropertyType Type => PropertyType.Number;
        public Number Number { get; set; }

    }

    public enum NumberFormat
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "number")]
        Number,

        [EnumMember(Value = "number_with_commas")]
        NumberWithCommas,

        [EnumMember(Value = "percent")]
        Percent,

        [EnumMember(Value = "dollar")]
        Dollar,

        [EnumMember(Value = "euro")]
        Euro,

        [EnumMember(Value = "pound")]
        Pound,

        [EnumMember(Value = "yen")]
        Yen,

        [EnumMember(Value = "ruble")]
        Ruble,

        [EnumMember(Value = "rupee")]
        Rupee,

        [EnumMember(Value = "won")]
        Won,

        [EnumMember(Value = "yuan")]
        Yuan
    }

    public class Number
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public NumberFormat Format { get; set; }
    }

    public class SelectProperty : Property
    {
        public override PropertyType Type => PropertyType.Select;
        public OptionWrapper<SelectOption> Select { get; set; }
    }

    public class OptionWrapper<T>
    {
        public List<T> Options { get; set; }
    }

    public class SelectOption
    {
        public string Name { get; set; }
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Color Color { get; set; }
    }

    public enum Color
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "default")]
        Default,

        [EnumMember(Value = "gray")]
        Gray,

        [EnumMember(Value = "brown")]
        Brown,

        [EnumMember(Value = "orange")]
        Orange,

        [EnumMember(Value = "yellow")]
        Yellow,

        [EnumMember(Value = "green")]
        Green,

        [EnumMember(Value = "blue")]
        Blue,

        [EnumMember(Value = "purple")]
        Purple,

        [EnumMember(Value = "pink")]
        Pink,

        [EnumMember(Value = "red")]
        Red
    }

    public class MultiSelectProperty : Property
    {
        public override PropertyType Type => PropertyType.MultiSelect;

        [JsonProperty("multi_select")]
        public OptionWrapper<SelectOption> MultiSelect { get; set; }
    }

    public class DateProperty : Property
    {
        public override PropertyType Type => PropertyType.MultiSelect;
        public Dictionary<string, object> Date { get; set; }
    }

    public class PeopleProperty : Property
    {
        public override PropertyType Type => PropertyType.People;
        public Dictionary<string, object> People { get; set; }
    }

    public class FileProperty : Property
    {
        public override PropertyType Type => PropertyType.File;
        public Dictionary<string, object> File { get; set; }
    }

    public class CheckboxProperty : Property
    {
        public override PropertyType Type => PropertyType.Checkbox;
        public Dictionary<string, object> Checkbox { get; set; }
    }

    public class UrlProperty : Property
    {
        public override PropertyType Type => PropertyType.Url;
        public Dictionary<string, object> Url { get; set; }
    }

    public class EmailProperty : Property
    {
        public override PropertyType Type => PropertyType.Email;
        public Dictionary<string, object> Email { get; set; }
    }

    public class PhoneNumberProperty : Property
    {
        public override PropertyType Type => PropertyType.PhoneNumber;

        [JsonProperty("phone_number")]
        public Dictionary<string, object> PhoneNumber { get; set; }
    }

    public class FormulaProperty : Property
    {
        public override PropertyType Type => PropertyType.Formula;

        public Formula Formula { get; set; }
    }

    public class Formula
    {
        public string Expression { get; set; }
    }

    public class RelationProperty : Property
    {
        public override PropertyType Type => PropertyType.Relation;

        public Relation Relation { get; set; }
    }

    public class Relation
    {
        [JsonProperty("datebase_id")]
        public string DatabaseId { get; set; }

        [JsonProperty("synced_property_name")]
        public string SyncedPropertyName { get; set; }

        [JsonProperty("synced_property_id")]
        public string SyncedPropertyId { get; set; }
    }

    public class RollupProperty : Property
    {
        public override PropertyType Type => PropertyType.Rollup;

        public Rollup Rollup { get; set; }
    }

    public class Rollup
    {
        [JsonProperty("relation_property_name")]
        public string RelationPropertyName { get; set; }

        [JsonProperty("relation_property_id")]
        public string RelationPropertyId { get; set; }

        [JsonProperty("rollup_property_name")]
        public string RollupPropertyName { get; set; }

        [JsonProperty("rollup_property_id")]
        public string RollupPropertyId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Function Function { get; set; }
    }

    public enum Function
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "count_all")]
        CountAll,
        [EnumMember(Value = "count_values")]
        CountValues,

        [EnumMember(Value = "count_unique_values")]
        CountUniqueValues,

        [EnumMember(Value = "count_empty")]
        CountEmpty,

        [EnumMember(Value = "count_not_empty")]
        CountNotEmpty,

        [EnumMember(Value = "percent_empty")]
        PercentEmpty,

        [EnumMember(Value = "percent_not_empty")]
        PercentNotEmpty,

        [EnumMember(Value = "sum")]
        Sum,

        [EnumMember(Value = "average")]
        Average,

        [EnumMember(Value = "median")]
        Median,

        [EnumMember(Value = "min")]
        Min,

        [EnumMember(Value = "max")]
        Max,

        [EnumMember(Value = "range")]
        Range
    }

    public class CreatedTimeProperty : Property
    {
        public override PropertyType Type => PropertyType.CreatedTime;

        [JsonProperty("created_time")]
        public Dictionary<string, object> CreatedTime { get; set; }
    }

    public class CreatedByProperty : Property
    {
        public override PropertyType Type => PropertyType.CreatedBy;

        [JsonProperty("created_by")]
        public Dictionary<string, object> CreatedBy { get; set; }
    }

    public class LastEditedTimeProperty : Property
    {
        public override PropertyType Type => PropertyType.LastEditedTime;

        [JsonProperty("last_edited_time")]
        public Dictionary<string, object> LastEditedTime { get; set; }
    }

    public class LastEditedByProperty : Property
    {
        public override PropertyType Type => PropertyType.LastEditedBy;

        [JsonProperty("last_edited_by")]
        public Dictionary<string, object> LastEditedBy { get; set; }
    }


    public enum PropertyType
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "title")]
        Title,

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

        [EnumMember(Value = "people")]
        People,

        [EnumMember(Value = "file")]
        File,

        [EnumMember(Value = "checkbox")]
        Checkbox,

        [EnumMember(Value = "url")]
        Url,

        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "phone_number")]
        PhoneNumber,

        [EnumMember(Value = "formula")]
        Formula,

        [EnumMember(Value = "relation")]
        Relation,

        [EnumMember(Value = "rollup")]
        Rollup,

        [EnumMember(Value = "created_time")]
        CreatedTime,

        [EnumMember(Value = "created_by")]
        CreatedBy,

        [EnumMember(Value = "last_edited_by")]
        LastEditedBy,

        [EnumMember(Value = "last_edited_time")]
        LastEditedTime
    }
}