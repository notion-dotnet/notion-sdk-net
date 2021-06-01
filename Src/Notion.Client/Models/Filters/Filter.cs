using System.Collections.Generic;

namespace Notion.Client
{
    public class Filter
    {

    }

    public class SinglePropertyFilter : Filter
    {
        public string Property { get; set; }
    }

    public class CompoundFilter : Filter
    {
        public List<Filter> Or { get; set; }
        public List<Filter> And { get; set; }
    }
}