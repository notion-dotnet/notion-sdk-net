using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Notion.Client
{
    public class DatabasesListParameters
    {
        public PaginationParameters PaginationParameters { get; set; }
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

    public class RichTextBase
    {
        [JsonProperty("plain_text")]
        public string PlainText { get; set; }

        public string Href { get; set; }

        public Annotations Annotations { get; set; }

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
        public int MyProperty { get; set; }
    }

    public class Mention
    {
        public string Type { get; set; }
        public User User { get; set; }
        public ObjectId Page { get; set; }
        public ObjectId Database { get; set; }
        public PropertyValue Date { get; set; }
    }

    public class ObjectId
    {
        public string Id { get; set; }
    }

    public class PropertyValue
    {
        public string Id { get; set; }
        public string Type { get; set; }

        // DateProperty Value
        public Date Date { get; set; }
    }

    public class Date
    {
        public string Start { get; set; }
        public string End { get; set; }
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

    public abstract class Property
    {
        public string Id { get; set; }
        public virtual string Type { get; set; }
    }

    public class TitleProperty : Property
    {
        public override string Type => "title";
        public Dictionary<string, object> Title { get; set; }
    }

    public class RichTextProperty : Property
    {
        public override string Type => "rich_text";

        [JsonProperty("rich_text")]
        public Dictionary<string, object> RichText { get; set; }
    }

    public class NumberProperty : Property
    {
        public override string Type => "number";
        public Number Number { get; set; }

    }

    public enum NumberFormat
    {
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
        public override string Type => "select";
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

    public class MultiSelctProperty : Property
    {
        public override string Type => "multi_select";

        [JsonProperty("multi_select")]
        public OptionWrapper<SelectOption> MultiSelect { get; set; }
    }

    public class DateProperty : Property
    {
        public override string Type => "date";
        public Dictionary<string, object> Date { get; set; }
    }

    public class PeopleProperty : Property
    {
        public override string Type => "people";
        public Dictionary<string, object> People { get; set; }
    }

    public class FileProperty : Property
    {
        public override string Type => "file";
        public Dictionary<string, object> File { get; set; }
    }

    public class CheckboxProperty : Property
    {
        public override string Type => "checkbox";
        public Dictionary<string, object> Checkbox { get; set; }
    }

    public class UrlProperty : Property
    {
        public override string Type => "url";
        public Dictionary<string, object> Url { get; set; }
    }

    public class EmailProperty : Property
    {
        public override string Type => "email";
        public Dictionary<string, object> Email { get; set; }
    }

    public class PhoneNumberProperty : Property
    {
        public override string Type => "phone_number";

        [JsonProperty("phone_number")]
        public Dictionary<string, object> PhoneNumber { get; set; }
    }

    public class FormulaProperty : Property
    {
        public override string Type => "formula";

        public Formula Formula { get; set; }
    }

    public class Formula
    {
        public string Expression { get; set; }
    }

    public class RelationProperty : Property
    {
        public override string Type => "relation";

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
        public override string Type => "rollup";

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
        public override string Type => "created_time";

        [JsonProperty("created_time")]
        public Dictionary<string, object> CreatedTime { get; set; }
    }

    public class CreatedByProperty : Property
    {
        public override string Type => "created_by";

        [JsonProperty("created_by")]
        public Dictionary<string, object> CreatedBy { get; set; }
    }

    public class LastEditedTimeProperty : Property
    {
        public override string Type => "last_edited_time";

        [JsonProperty("last_edited_time")]
        public Dictionary<string, object> LastEditedTime { get; set; }
    }

    public class LastEditedByProperty : Property
    {
        public override string Type => "last_edited_by";

        [JsonProperty("last_edited_by")]
        public Dictionary<string, object> LastEditedBy { get; set; }
    }

    // Todo: Is there a better way?
    public class PropertyConverter : JsonConverter<Property>
    {
        public override Property ReadJson(JsonReader reader, Type objectType, Property existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject  = JObject.Load(reader);
            var type = jsonObject["type"].Value<string>();

            switch(type)
            {
                case "title":
                    return jsonObject.ToObject<TitleProperty>();
                case "rich_text":
                    return jsonObject.ToObject<RichTextProperty>();
                case "number":
                    return jsonObject.ToObject<NumberProperty>();
                case "select":
                    return jsonObject.ToObject<SelectProperty>();
                case "multi_select":
                    return jsonObject.ToObject<MultiSelctProperty>();
                case "date":
                    return jsonObject.ToObject<DateProperty>();
                case "people":
                    return jsonObject.ToObject<PeopleProperty>();
                case "file":
                    return jsonObject.ToObject<FileProperty>();
                case "checkbox":
                    return jsonObject.ToObject<CheckboxProperty>();
                case "url":
                    return jsonObject.ToObject<UrlProperty>();
                case "email":
                    return jsonObject.ToObject<EmailProperty>();
                case "phone_number":
                    return jsonObject.ToObject<PhoneNumberProperty>();
                case "formula":
                    return jsonObject.ToObject<FormulaProperty>();
                case "relation":
                    return jsonObject.ToObject<RelationProperty>();
                case "rollup":
                    return jsonObject.ToObject<RollupProperty>();
                case "created_time":
                    return jsonObject.ToObject<CreatedTimeProperty>();
                case "created_by":
                    return jsonObject.ToObject<CreatedByProperty>();
                case "last_edited_by":
                    return jsonObject.ToObject<LastEditedByProperty>();
                case "last_edited_time":
                    return jsonObject.ToObject<LastEditedTimeProperty>();

                default:
                    throw new InvalidOperationException();
            }
        }

        public override void WriteJson(JsonWriter writer, Property value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}