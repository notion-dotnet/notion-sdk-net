using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Notion.Client
{
    public interface IDatabasesListQueryParmaters : IPaginationParameters
    {

    }

    public class DatabasesListParameters : IDatabasesListQueryParmaters
    {
        public string StartCursor { get; set; }
        public string PageSize { get; set; }
    }

    public interface IDatabaseQueryBodyParameters : IPaginationParameters
    {
        Filter Filter { get; set; }
        List<Sort> Sorts { get; set; }
    }

    public class DatabasesQueryParameters : IDatabaseQueryBodyParameters
    {
        public Filter Filter { get; set; }
        public List<Sort> Sorts { get; set; }
        public string StartCursor { get; set; }
        public string PageSize { get; set; }
    }
    public class Database
    {
        public string Object => "database";
        public string Id { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }

        public List<RichTextBase> Title { get; set; }

        public Dictionary<string, Property> Properties { get; set; }
    }
}