using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class SelectDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Select;

        public OptionWrapper<SelectOptionResponse> Select { get; set; }
    }

    public class SelectOptionResponse
    {
        /// <summary>
        ///     Name of the option as it appears in Notion.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     ID of the option.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Color of the option. Possible values are: "default", "gray", "brown", "red", "orange", "yellow", "green", "blue",
        ///     "purple", "pink". Defaults to "default".
        /// </summary>
        [JsonProperty("color")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Color? Color { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
