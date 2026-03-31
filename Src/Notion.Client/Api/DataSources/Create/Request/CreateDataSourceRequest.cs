using System.Collections.Generic;

namespace Notion.Client
{
    public class CreateDataSourceRequest : ICreateDataSourceBodyParameters
    {
        public IParentOfDataSourceRequest Parent { get; set; }
        public IDictionary<string, DataSourcePropertyConfigRequest> Properties { get; set; }
        public IEnumerable<RichTextBaseInput> Title { get; set; }
        public IPageIconRequest Icon { get; set; }
    }
}
