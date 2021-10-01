using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class RollupProperty : Property
    {
        public override PropertyType Type => PropertyType.Rollup;

        [JsonProperty("rollup")]
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
        Range,

        [EnumMember(Value = "show_original")]
        ShowOriginal,

        [EnumMember(Value = "show_unique")]
        ShowUnique
    }
}
