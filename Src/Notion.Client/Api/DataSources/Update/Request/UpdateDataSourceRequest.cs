using System.Collections.Generic;

namespace Notion.Client
{
    public class UpdateDataSourceRequest : IUpdateDataSourcePathParameters, IUpdateDataSourceBodyParameters
    {
        public string DataSourceId { get; set; }
        public IEnumerable<RichTextBaseInput> Title { get; set; }
        public IPageIconRequest Icon { get; set; }
        public IDictionary<string, IUpdatePropertyConfigurationRequest> Properties { get; set; }
        public bool InTrash { get; set; }
        public bool Archived { get; set; }
        public IParentOfDataSourceRequest Parent { get; set; }
    }
}
