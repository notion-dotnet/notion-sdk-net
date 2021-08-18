using System.Collections.Generic;

namespace Notion.Client
{
    public interface IDatabasesUpdateBodyParameters
    {
        Dictionary<string, IUpdatePropertySchema> Properties { get; set; }
        List<RichTextBaseInput> Title { get; set; }
    }

    public class DatabasesUpdateParameters : IDatabasesUpdateBodyParameters
    {
        public Dictionary<string, IUpdatePropertySchema> Properties { get; set; }
        public List<RichTextBaseInput> Title { get; set; }
    }
}
