using System.Collections.Generic;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(TableViewConfiguration), ViewType.TableValue)]
    [JsonSubtypes.KnownSubType(typeof(BoardViewConfiguration), ViewType.BoardValue)]
    [JsonSubtypes.KnownSubType(typeof(CalendarViewConfiguration), ViewType.CalendarValue)]
    [JsonSubtypes.KnownSubType(typeof(TimelineViewConfiguration), ViewType.TimelineValue)]
    [JsonSubtypes.KnownSubType(typeof(GalleryViewConfiguration), ViewType.GalleryValue)]
    [JsonSubtypes.KnownSubType(typeof(ListViewConfiguration), ViewType.ListValue)]
    [JsonSubtypes.KnownSubType(typeof(MapViewConfiguration), ViewType.MapValue)]
    [JsonSubtypes.KnownSubType(typeof(FormViewConfiguration), ViewType.FormValue)]
    [JsonSubtypes.KnownSubType(typeof(ChartViewConfiguration), ViewType.ChartValue)]
    [JsonSubtypes.KnownSubType(typeof(DashboardViewConfiguration), ViewType.DashboardValue)]
    [JsonSubtypes.FallBackSubType(typeof(UnknownViewConfiguration))]
    public abstract class ViewConfiguration
    {
        [JsonProperty("type")]
        public abstract string Type { get; }
    }

    public class TableViewConfiguration : ViewConfiguration
    {
        public override string Type => ViewType.TableValue;

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }

    public class BoardViewConfiguration : ViewConfiguration
    {
        public override string Type => ViewType.BoardValue;

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }

    public class CalendarViewConfiguration : ViewConfiguration
    {
        public override string Type => ViewType.CalendarValue;

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }

    public class TimelineViewConfiguration : ViewConfiguration
    {
        public override string Type => ViewType.TimelineValue;

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }

    public class GalleryViewConfiguration : ViewConfiguration
    {
        public override string Type => ViewType.GalleryValue;

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }

    public class ListViewConfiguration : ViewConfiguration
    {
        public override string Type => ViewType.ListValue;

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }

    public class MapViewConfiguration : ViewConfiguration
    {
        public override string Type => ViewType.MapValue;

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }

    public class FormViewConfiguration : ViewConfiguration
    {
        public override string Type => ViewType.FormValue;

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }

    public class ChartViewConfiguration : ViewConfiguration
    {
        public override string Type => ViewType.ChartValue;

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }

    public class DashboardViewConfiguration : ViewConfiguration
    {
        public override string Type => ViewType.DashboardValue;

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }

    public class UnknownViewConfiguration : ViewConfiguration
    {
        public override string Type => "unknown";

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }
}
