using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class StatusDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "status";

        [JsonProperty("status")]
        public StatusConfigRequest Status { get; set; }
    }

    public class StatusConfigRequest
    {
        /// <summary>
        /// The available status options. Each option must have a name; id and color are optional.
        /// </summary>
        [JsonProperty("options")]
        public IEnumerable<StatusOptionRequest> Options { get; set; }

        /// <summary>
        /// Groups that organise the status options. Each group references option IDs.
        /// </summary>
        [JsonProperty("groups")]
        public IEnumerable<StatusGroupRequest> Groups { get; set; }
    }

    public class StatusOptionRequest
    {
        /// <summary>
        /// ID of an existing option to update. Omit when creating a new option.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>Name of the status option.</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>Color of the status option.</summary>
        [JsonProperty("color")]
        public Color? Color { get; set; }
    }

    public class StatusGroupRequest
    {
        /// <summary>
        /// ID of an existing group to update. Omit when creating a new group.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>Name of the group.</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>Color of the group.</summary>
        [JsonProperty("color")]
        public Color? Color { get; set; }

        /// <summary>IDs of the status options that belong to this group.</summary>
        [JsonProperty("option_ids")]
        public IEnumerable<string> OptionIds { get; set; }
    }
}
