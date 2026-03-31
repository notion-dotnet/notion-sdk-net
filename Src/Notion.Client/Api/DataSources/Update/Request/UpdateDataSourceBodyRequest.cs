using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Internal concrete implementation of IUpdateDataSourceBodyParameters used for JSON serialization.
    /// This class contains only the properties that should be serialized in the request body.
    /// </summary>
    internal class UpdateDataSourceBodyRequest : IUpdateDataSourceBodyParameters
    {
        /// <summary>
        /// The title of the data source.
        /// </summary>
        [JsonProperty("title")]
        public IEnumerable<RichTextBaseInput> Title { get; set; }

        /// <summary>
        /// Page icon for data source.
        /// </summary>
        [JsonProperty("icon")]
        public IPageIconRequest Icon { get; set; }

        /// <summary>
        /// Properties configuration for the data source.
        /// </summary>
        [JsonProperty("properties")]
        public IDictionary<string, IUpdatePropertyConfigurationRequest> Properties { get; set; }

        /// <summary>
        /// Whether the database should be moved to or from the trash. If not provided, the trash
        /// status will not be updated.
        /// </summary>
        [JsonProperty("in_trash")]
        public bool InTrash { get; set; }

        /// <summary>
        /// Whether the database should be moved to or from the trash. If not provided, the trash
        /// status will not be updated. Equivalent to `in_trash`.
        /// </summary>
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// The parent of the data source.
        /// </summary>
        [JsonProperty("parent")]
        public IParentOfDataSourceRequest Parent { get; set; }

        /// <summary>
        /// Creates an UpdateDataSourceBodyRequest from an UpdateDataSourceRequest
        /// </summary>
        /// <param name="source">The source request containing all parameters</param>
        /// <returns>A new UpdateDataSourceBodyRequest with only body parameters</returns>
        internal static UpdateDataSourceBodyRequest FromRequest(UpdateDataSourceRequest source)
        {
            return new UpdateDataSourceBodyRequest
            {
                Title = source.Title,
                Icon = source.Icon,
                Properties = source.Properties,
                InTrash = source.InTrash,
                Archived = source.Archived,
                Parent = source.Parent
            };
        }
    }
}