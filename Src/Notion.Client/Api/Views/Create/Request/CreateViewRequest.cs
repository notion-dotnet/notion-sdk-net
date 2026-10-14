using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreateViewRequest
    {
        [JsonProperty("data_source_id")]
        public string DataSourceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public ViewType Type { get; set; }

        /// <summary>
        /// The database to create the view in. Mutually exclusive with <see cref="ViewId" /> and <see cref="CreateDatabase" />.
        /// </summary>
        [JsonProperty("database_id")]
        public string DatabaseId { get; set; }

        /// <summary>
        /// A dashboard view to add this view to as a widget. Mutually exclusive with <see cref="DatabaseId" /> and
        /// <see cref="CreateDatabase" />.
        /// </summary>
        [JsonProperty("view_id")]
        public string ViewId { get; set; }

        [JsonProperty("filter")]
        public object Filter { get; set; }

        [JsonProperty("sorts")]
        public IEnumerable<ViewSort> Sorts { get; set; }

        /// <summary>
        /// Quick filters to pin in the view's filter bar. Keys are property names or ids; values are filter conditions
        /// (a property filter without the <c>property</c> field).
        /// </summary>
        [JsonProperty("quick_filters")]
        public IDictionary<string, object> QuickFilters { get; set; }

        /// <summary>
        /// Creates a new linked database block on a page and adds the view to it. Mutually exclusive with
        /// <see cref="DatabaseId" /> and <see cref="ViewId" />.
        /// </summary>
        [JsonProperty("create_database")]
        public CreateDatabaseForViewRequest CreateDatabase { get; set; }

        [JsonProperty("configuration")]
        public ViewConfiguration Configuration { get; set; }

        /// <summary>
        /// Where to place the view in the database's view tab bar. Only with <see cref="DatabaseId" />; defaults to the end.
        /// </summary>
        [JsonProperty("position")]
        public ViewPositionRequest Position { get; set; }

        /// <summary>
        /// Where to place the widget in a dashboard view. Only with <see cref="ViewId" />; defaults to a new row at the end.
        /// </summary>
        [JsonProperty("placement")]
        public WidgetPlacementRequest Placement { get; set; }
    }
}
