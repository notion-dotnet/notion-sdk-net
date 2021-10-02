using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class Filter
    {

    }

    public class SinglePropertyFilter : Filter
    {
        [JsonProperty("property")]
        public string Property { get; set; }
    }

    public class CompoundFilter : Filter
    {
        [JsonProperty("or")]
        public List<Filter> Or { get; set; }

        [JsonProperty("and")]
        public List<Filter> And { get; set; }

        public CompoundFilter(List<Filter> or = null, List<Filter> and = null)
        {
            Or = or;
            And = and;
        }
    }
}
