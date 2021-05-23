using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class Page
    {
        public string Object => "page";
        public string Id { get; set; }
        public Parent Parent { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }

        [JsonProperty("archived")]
        public bool IsArchived { get; set; }

        public IDictionary<string, PropertyValue> Properties { get; set; }
    }

    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(DatabaseParent), ParentType.DatabaseId)]
    [JsonSubtypes.KnownSubType(typeof(PageParent), ParentType.PageId)]
    [JsonSubtypes.KnownSubType(typeof(WorkspaceParent), ParentType.Workspace)]
    public class Parent
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ParentType Type { get; set; }
    }

    public enum ParentType
    {
        [EnumMember(Value = null)]
        Unknown,

        [EnumMember(Value = "database_id")]
        DatabaseId,

        [EnumMember(Value = "page_id")]
        PageId,
        [EnumMember(Value = "workspace")]
        Workspace
    }

    public class DatabaseParent : Parent
    {
        [JsonProperty("database_id")]
        public string DatabaseId { get; set; }
    }

    public class PageParent : Parent
    {
        [JsonProperty("page_id")]
        public string PageId { get; set; }
    }

    public class WorkspaceParent : Parent
    {
    }
}