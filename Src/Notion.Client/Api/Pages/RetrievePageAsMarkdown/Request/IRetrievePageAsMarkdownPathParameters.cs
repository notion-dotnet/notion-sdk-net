using Newtonsoft.Json;

public interface IRetrievePageAsMarkdownPathParameters
{
    /// <summary>
    /// The ID of the page (or block) to retrieve as markdown. 
    /// Non-navigable block IDs from truncated responses can be passed here to fetch their subtrees.
    /// </summary>
    [JsonProperty("page_id")]
    string PageId { get; set; }
}
