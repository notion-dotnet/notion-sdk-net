using System.Collections.Generic;

namespace Notion.Client
{
    public class DatabasesQueryParameters : IDatabaseQueryBodyParameters, IDatabaseQueryQueryParameters
    {
        public Filter Filter { get; set; }

        public List<Sort> Sorts { get; set; }

        public string StartCursor { get; set; }

        public int? PageSize { get; set; }

        public List<string> FilterProperties { get; set; }
    }
}
