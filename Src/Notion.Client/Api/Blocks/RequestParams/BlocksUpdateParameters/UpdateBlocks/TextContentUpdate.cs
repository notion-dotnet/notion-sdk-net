using System.Collections.Generic;

namespace Notion.Client
{
    public class TextContentUpdate
    {
        public IEnumerable<RichTextBaseInput> Text { get; set; }
    }
}
