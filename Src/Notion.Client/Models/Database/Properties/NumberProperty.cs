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
        Yuan,

        [EnumMember(Value = "hong_kong_dollar")]
        HongKongDollar,

        [EnumMember(Value = "new_zealand_dollar")]
        NewZealandDollar,

        [EnumMember(Value = "krona")]
        Krona,

        [EnumMember(Value = "norwegian_krone")]
        NorwegianKrone,

        [EnumMember(Value = "mexican_peso")]
        MexicanPeso,

        [EnumMember(Value = "rand")]
        Rand,

        [EnumMember(Value = "new_taiwan_dollar")]
        NewTaiwanDollar,

        [EnumMember(Value = "danish_krone")]
        DanishKrone,

        [EnumMember(Value = "zloty")]
        Zloty,

        [EnumMember(Value = "baht")]
        Baht,

        [EnumMember(Value = "forint")]
        Forint,

        [EnumMember(Value = "koruna")]
        Koruna,

        [EnumMember(Value = "shekel")]
        Shekel,

        [EnumMember(Value = "chilean_peso")]
        ChileanPeso,

        [EnumMember(Value = "philippine_peso")]
        PhilippinePeso,

        [EnumMember(Value = "dirham")]
        Dirham,

        [EnumMember(Value = "colombian_peso")]
        ColombianPeso,

        [EnumMember(Value = "riyal")]
        Riyal,

        [EnumMember(Value = "ringgit")]
        Ringgit,

        [EnumMember(Value = "leu")]
        Leu
    }
}
