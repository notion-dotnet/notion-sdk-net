using System.Collections.Generic;

namespace Notion.Client
{
    public class FilesUpdatePropertySchema : IUpdatePropertySchema
    {
        public Dictionary<string, object> File { get; set; }
    }
}
