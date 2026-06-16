using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Controls where appended block children are placed within the parent block.
    /// </summary>
    public abstract class ContentPosition
    {
        [JsonProperty("type")]
        public abstract string Type { get; }
    }

    /// <summary>
    /// Places the new blocks immediately after the specified existing block.
    /// </summary>
    public class AfterBlockContentPosition : ContentPosition
    {
        public override string Type => "after_block";

        [JsonProperty("after_block")]
        public AfterBlockReference AfterBlock { get; set; }
    }

    /// <summary>
    /// Places the new blocks at the start of the parent block's children.
    /// </summary>
    public class StartContentPosition : ContentPosition
    {
        public override string Type => "start";
    }

    /// <summary>
    /// Places the new blocks at the end of the parent block's children (default behaviour).
    /// </summary>
    public class EndContentPosition : ContentPosition
    {
        public override string Type => "end";
    }
}
