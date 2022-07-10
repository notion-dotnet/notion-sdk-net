using Newtonsoft.Json;

namespace Notion.Client
{
    public class FilesFilter : SinglePropertyFilter
    {
        [JsonProperty("files")]
        public Condition Files { get; set; }

        public FilesFilter(
            string propertyName,
            bool? isEmpty = null,
            bool? isNotEmpty = null)
        {
            Property = propertyName;
            Files = new Condition(isEmpty: isEmpty, isNotEmpty: isNotEmpty);
        }

        public class Condition
        {
            [JsonProperty("is_empty")]
            public bool? IsEmpty { get; set; }

            [JsonProperty("is_not_empty")]
            public bool? IsNotEmpty { get; set; }

            public Condition(
                bool? isEmpty = null,
                bool? isNotEmpty = null)
            {
                IsEmpty = isEmpty;
                IsNotEmpty = isNotEmpty;
            }
        }
    }
}
