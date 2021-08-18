using System.Collections.Generic;

namespace Notion.Client
{
    public interface IDatabasesCreateBodyParameters
    {
        ParentPageInput Parent { get; set; }
        Dictionary<string, IPropertySchema> Properties { get; set; }
        List<RichTextBaseInput> Title { get; set; }
    }
}
