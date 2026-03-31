using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IListDataSourceTemplatesQueryParameters : IPaginationParameters
    {
        /// <summary>
        /// Filter templates by name (case-insensitive substring match).
        /// </summary>
        [JsonProperty("name")]
        string Name { get; set; }
    }
}
