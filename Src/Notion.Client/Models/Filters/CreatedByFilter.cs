using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreatedByFilter : SinglePropertyFilter
    {
        public CreatedByFilter(
            string propertyName,
            PeopleFilter.Condition createdBy)
        {
            Property = propertyName;
            CreatedBy = createdBy;
        }

        /// <summary>
        /// Gets or sets the created by condition.
        /// </summary>
        [JsonProperty("created_by")]
        public PeopleFilter.Condition CreatedBy { get; set; }
    }
}
