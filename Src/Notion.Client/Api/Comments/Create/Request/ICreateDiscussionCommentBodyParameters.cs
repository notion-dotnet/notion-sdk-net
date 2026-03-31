using Newtonsoft.Json;

namespace Notion.Client
{
    public interface ICreateDiscussionCommentBodyParameters : ICreateCommentsBodyParameters
    {
        [JsonProperty("discussion_id")]
        public string DiscussionId { get; set; }
    }
}
