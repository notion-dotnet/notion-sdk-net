using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class NumberProperty : Property
    {
        public override PropertyType Type => PropertyType.Number;
        public Number Number { get; set; }
    }

    public class Number
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public NumberFormat Format { get; set; }
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
}
