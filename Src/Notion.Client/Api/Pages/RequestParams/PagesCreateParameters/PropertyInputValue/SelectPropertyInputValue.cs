using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Select property value object.
    /// </summary>
    public class SelectPropertyInputValue : PropertyInputValue
    {
        [JsonProperty("select")]
        public SelectOption Select { get; set; }
    }
}
