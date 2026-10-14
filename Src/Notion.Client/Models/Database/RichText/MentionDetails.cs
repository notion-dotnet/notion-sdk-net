using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Details of a <c>link_preview</c> mention.
    /// </summary>
    public class LinkPreviewMention
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    /// <summary>
    ///     Details of a <c>link_mention</c> mention.
    /// </summary>
    public class LinkMention
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("link_author")]
        public string LinkAuthor { get; set; }

        [JsonProperty("link_provider")]
        public string LinkProvider { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("iframe_url")]
        public string IframeUrl { get; set; }

        [JsonProperty("height")]
        public double? Height { get; set; }

        [JsonProperty("padding")]
        public double? Padding { get; set; }

        [JsonProperty("padding_top")]
        public double? PaddingTop { get; set; }
    }

    /// <summary>
    ///     Details of a <c>template_mention</c>: either a date placeholder (<c>today</c> / <c>now</c>) or
    ///     a user placeholder (<c>me</c>). Used in response and request.
    /// </summary>
    public class TemplateMention
    {
        /// <summary>
        ///     "template_mention_date" or "template_mention_user".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        ///     "today" or "now"; set when <see cref="Type" /> is <c>template_mention_date</c>.
        /// </summary>
        [JsonProperty("template_mention_date")]
        public string TemplateMentionDate { get; set; }

        /// <summary>
        ///     "me"; set when <see cref="Type" /> is <c>template_mention_user</c>.
        /// </summary>
        [JsonProperty("template_mention_user")]
        public string TemplateMentionUser { get; set; }

        public static TemplateMention Date(string todayOrNow) =>
            new TemplateMention { Type = "template_mention_date", TemplateMentionDate = todayOrNow };

        public static TemplateMention UserMe() =>
            new TemplateMention { Type = "template_mention_user", TemplateMentionUser = "me" };
    }
}
