using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DatabasesCreateRequest : IDatabasesCreateBodyParameters
    {
        public IParentOfDatabaseRequest Parent { get; set; }

        public List<RichTextBaseInput> Title { get; set; }

        public List<RichTextBaseInput> Description { get; set; }

        public bool? IsInline { get; set; }

        public InitialDataSourceRequest InitialDataSource { get; set; }

        public IPageIconRequest Icon { get; set; }

        public IPageCoverRequest Cover { get; set; }
    }

    public class InitialDataSourceRequest
    {
        [JsonProperty("properties")]
        public Dictionary<string, DataSourcePropertyConfigRequest> Properties { get; set; }
    }
}
