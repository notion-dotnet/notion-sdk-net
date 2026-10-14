using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Parent of a block or page that belongs to a Notion agent.
    /// </summary>
    public class AgentParent : IParentOfBlock, IParentOfPage
    {
        public string Type { get; set; } = ParentTypes.Agent;

        [JsonProperty(ParentTypes.Agent)]
        public string AgentId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
