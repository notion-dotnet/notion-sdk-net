using System.Collections.Generic;

namespace Notion.Client
{
    public class DatabasesCreateParameters : IDatabasesCreateBodyParameters, IDatabasesCreateQueryParameters
    {
        public ParentPageInput Parent { get; set; }
        public Dictionary<string, IPropertySchema> Properties { get; set; }
        public List<RichTextBaseInput> Title { get; set; }
    }
}
