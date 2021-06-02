using System.Collections.Generic;

namespace Notion.Client
{
    public interface IDatabaseQueryBodyParameters : IPaginationParameters
    {
        Filter Filter { get; set; }
        List<Sort> Sorts { get; set; }
    }
}
