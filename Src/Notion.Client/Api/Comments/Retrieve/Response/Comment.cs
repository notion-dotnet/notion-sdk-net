using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class Comment : IObject
    {
        [JsonProperty("parent")]
        public ICommentParent Parent { get; set; }

        [JsonProperty("discussion_id")]
        public string DiscussionId { get; set; }

        [JsonProperty("rich_text")]
        public IEnumerable<RichTextBase> RichText { get; set; }

        [JsonProperty("created_by")]
        public PartialUser CreatedBy { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }

        public string Id { get; set; }

        public ObjectType Object => ObjectType.Comment;
    }
}
