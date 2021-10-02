using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IDatabaseQueryBodyParameters : IPaginationParameters
    {
        [JsonProperty("filter")]
        Filter Filter { get; set; }

        [JsonProperty("sorts")]
        List<Sort> Sorts { get; set; }
    }
}
