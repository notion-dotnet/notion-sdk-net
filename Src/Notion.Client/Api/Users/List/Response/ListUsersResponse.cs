using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ListUsersResponse : PaginatedList<User>
    {
        [JsonProperty("user")]
        public Dictionary<string, object> User { get; set; }
    }
}
