using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    /// <summary>
    ///     Date property value object.
    /// </summary>
    public class DatePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Date;

        /// <summary>
        ///     Date
        /// </summary>
        [JsonProperty("date", NullValueHandling = NullValueHandling.Include)]
        public Date Date { get; set; }
    }

    /// <summary>
    ///     Date value object.
    /// </summary>
    [JsonConverter(typeof(DateCustomConverter))]
    public class Date
    {
        /// <summary>
        ///     Start date with optional time.
        /// </summary>
        [JsonProperty("start")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTimeOffset? Start { get; set; }

        /// <summary>
        ///     End date with optional time.
        /// </summary>
        [JsonProperty("end")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTimeOffset? End { get; set; }

        /// <summary>
        ///     Optional time zone information for start and end. Possible values are extracted from the IANA database and they are
        ///     based on the time zones from Moment.js.
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        /// <summary>
        ///     Whether to include time
        /// </summary>
        public bool IncludeTime { get; set; } = true;
    }

    public class DateJsonObject
    {
        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }
    }

    public class DateCustomConverter : JsonConverter<Date>
    {
        public override Date ReadJson(JsonReader reader, Type objectType, Date existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jsonObject = serializer.Deserialize<DateJsonObject>(reader);

            if (jsonObject == null)
            {
                return null;
            }

            var date = new Date
            {
                Start = ParseDateTime(jsonObject.Start, out bool includeTime),
                End = ParseDateTime(jsonObject.End, out _),
                TimeZone = jsonObject.TimeZone,
                IncludeTime = includeTime,
            };

            return date;
        }

        public override void WriteJson(JsonWriter writer, Date value, JsonSerializer serializer)
        {
            if (value is null)
            {
                writer.WriteNull();

                return;
            }

            writer.WriteStartObject();

            if (value.Start.HasValue)
            {
                string startFormat = value.IncludeTime ? "yyyy-MM-ddTHH:mm:ss" : "yyyy-MM-dd";
                writer.WritePropertyName("start");
                writer.WriteValue(value.Start.Value.ToString(startFormat));
            }

            if (value.End.HasValue)
            {
                string endFormat = value.IncludeTime ? "yyyy-MM-ddTHH:mm:ss" : "yyyy-MM-dd";
                writer.WritePropertyName("end");
                writer.WriteValue(value.End.Value.ToString(endFormat));
            }

            if (!string.IsNullOrEmpty(value.TimeZone))
            {
                writer.WritePropertyName("time_zone");
                writer.WriteValue(value.TimeZone);
            }

            writer.WriteEndObject();
        }

        private static DateTime? ParseDateTime(string dateTimeString, out bool includeTime)
        {
            includeTime = false;

            if (string.IsNullOrEmpty(dateTimeString))
            {
                return null;
            }

            includeTime = dateTimeString.Contains("T") || dateTimeString.Contains(" ");

            return DateTimeOffset.Parse(dateTimeString).UtcDateTime;
        }
    }
}
