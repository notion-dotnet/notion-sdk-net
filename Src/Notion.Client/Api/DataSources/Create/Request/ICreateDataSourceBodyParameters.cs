using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface ICreateDataSourceBodyParameters
    {
        [JsonProperty("parent")]
        public IParentOfDataSourceRequest Parent { get; set; }

        [JsonProperty("properties")]
        public IDictionary<string, DataSourcePropertyConfigRequest> Properties { get; set; }

        [JsonProperty("title")]
        public IEnumerable<RichTextBaseInput> Title { get; set; }

        [JsonProperty("icon")]
        public IPageIconRequest Icon { get; set; }
    }
}
