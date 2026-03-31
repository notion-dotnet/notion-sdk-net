using System.Runtime.Serialization;

namespace Notion.Client
{
    public enum FileUploadMode
    {
        [EnumMember(Value = "single_part")]
        SinglePart,

        [EnumMember(Value = "multi_part")]
        MultiPart,

        [EnumMember(Value = "external_url")]
        ExternalUrl
    }
}
