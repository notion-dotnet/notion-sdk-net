using Newtonsoft.Json;

namespace Notion.Client
{
    public class UniqueIdFilter : SinglePropertyFilter
    {
        public UniqueIdFilter(
            string propertyName,
            NumberFilter.Condition uniqueId)
        {
            Property = propertyName;
            UniqueId = uniqueId;
        }

        /// <summary>
        /// Gets or sets the unique id condition.
        /// </summary>
        [JsonProperty("unique_id")]
        public NumberFilter.Condition UniqueId { get; set; }
    }
}
