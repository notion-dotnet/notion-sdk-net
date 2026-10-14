using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     The new parent of a moved page. Either a page or a data source.
    /// </summary>
    public class MovePageParent
    {
        /// <summary>
        ///     "page_id" or "data_source_id". When not set, it is inferred from which id is provided.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        {
            get => _type ?? (DataSourceId != null ? "data_source_id" : "page_id");
            set => _type = value;
        }

        [JsonProperty("page_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PageId { get; set; }

        [JsonProperty("data_source_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DataSourceId { get; set; }

        private string _type;

        public static MovePageParent ToPage(string pageId) => new MovePageParent { PageId = pageId };

        public static MovePageParent ToDataSource(string dataSourceId) =>
            new MovePageParent { DataSourceId = dataSourceId };
    }
}
