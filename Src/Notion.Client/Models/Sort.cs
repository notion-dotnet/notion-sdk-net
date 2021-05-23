using System.Runtime.Serialization;

namespace Notion.Client
{
    public class Sort
    {
        public string Property { get; set; }
        public Timestamp Timestamp { get; set; }
        public Direction Direction { get; set; }
    }

    public enum Timestamp
    {
        [EnumMember(Value = "created_time")]
        CreatedTime,

        [EnumMember(Value = "last_edited_time")]
        LastEditedTime
    }

    public enum Direction
    {
        [EnumMember(Value = "ascending")]
        Ascending,
        [EnumMember(Value = "descending")]
        Descending
    }
}