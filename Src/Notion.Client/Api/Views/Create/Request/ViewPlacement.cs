using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Where to place a new view in the database's view tab bar (<see cref="CreateViewRequest.Position" />).
    /// </summary>
    public class ViewPositionRequest
    {
        /// <summary>
        /// "start", "end" or "after_view".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The existing view to place the new view after; only for <c>after_view</c>.
        /// </summary>
        [JsonProperty("view_id")]
        public string ViewId { get; set; }

        public static ViewPositionRequest Start() => new ViewPositionRequest { Type = "start" };

        public static ViewPositionRequest End() => new ViewPositionRequest { Type = "end" };

        public static ViewPositionRequest AfterView(string viewId) =>
            new ViewPositionRequest { Type = "after_view", ViewId = viewId };
    }

    /// <summary>
    /// Where to place a new widget in a dashboard view (<see cref="CreateViewRequest.Placement" />).
    /// </summary>
    public class WidgetPlacementRequest
    {
        /// <summary>
        /// "new_row" or "existing_row".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 0-based row index. Optional for <c>new_row</c> (appended at the end when omitted), required for
        /// <c>existing_row</c>.
        /// </summary>
        [JsonProperty("row_index")]
        public int? RowIndex { get; set; }

        public static WidgetPlacementRequest NewRow(int? rowIndex = null) =>
            new WidgetPlacementRequest { Type = "new_row", RowIndex = rowIndex };

        public static WidgetPlacementRequest ExistingRow(int rowIndex) =>
            new WidgetPlacementRequest { Type = "existing_row", RowIndex = rowIndex };
    }

    /// <summary>
    /// Creates a new linked database block on a page and adds the view to it
    /// (<see cref="CreateViewRequest.CreateDatabase" />).
    /// </summary>
    public class CreateDatabaseForViewRequest
    {
        public CreateDatabaseForViewRequest()
        {
        }

        public CreateDatabaseForViewRequest(string pageId, string afterBlockId = null)
        {
            Parent = new ParentInfo { PageId = pageId };

            if (afterBlockId != null)
            {
                Position = new PositionInfo { BlockId = afterBlockId };
            }
        }

        /// <summary>
        /// The page to create the linked database block on.
        /// </summary>
        [JsonProperty("parent")]
        public ParentInfo Parent { get; set; }

        /// <summary>
        /// Where to place the block within the page; appended at the end when omitted.
        /// </summary>
        [JsonProperty("position")]
        public PositionInfo Position { get; set; }

        public class ParentInfo
        {
            [JsonProperty("type")]
            public string Type => "page_id";

            [JsonProperty("page_id")]
            public string PageId { get; set; }
        }

        public class PositionInfo
        {
            [JsonProperty("type")]
            public string Type => "after_block";

            [JsonProperty("block_id")]
            public string BlockId { get; set; }
        }
    }
}
