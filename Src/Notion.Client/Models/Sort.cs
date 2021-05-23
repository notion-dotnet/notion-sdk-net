using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class Sort
    {
        public string Property { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Timestamp Timestamp { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Direction Direction { get; set; }
    }

    public enum Timestamp
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "created_time")]
        CreatedTime,

        [EnumMember(Value = "last_edited_time")]
        LastEditedTime
    }

    public enum Direction
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "ascending")]
        Ascending,
        [EnumMember(Value = "descending")]
        Descending
    }
}