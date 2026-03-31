using Newtonsoft.Json;

namespace Notion.Client
{
    public interface ICreatePageCommentBodyParameters : ICreateCommentsBodyParameters
    {
        [JsonProperty("parent")]
        public ParentPageInput Parent { get; set; }
    }
}
