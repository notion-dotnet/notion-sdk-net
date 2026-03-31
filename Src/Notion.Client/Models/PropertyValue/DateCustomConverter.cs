using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DateCustomConverter : JsonConverter<Date>
    {
        private const string DateFormat = "yyyy-MM-dd";
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";

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
                Start = ParseDateTime(jsonObject.Start, out bool startIncludeTime),
                End = ParseDateTime(jsonObject.End, out bool endIncludeTime),
                TimeZone = jsonObject.TimeZone,
                IncludeTime = startIncludeTime || endIncludeTime,
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
                string startFormat = value.IncludeTime ? DateTimeFormat : DateFormat;
                writer.WritePropertyName("start");
                writer.WriteValue(value.Start.Value.ToUniversalTime().ToString(startFormat, CultureInfo.InvariantCulture));
            }

            if (value.End.HasValue)
            {
                string endFormat = value.IncludeTime ? DateTimeFormat : DateFormat;
                writer.WritePropertyName("end");
                writer.WriteValue(value.End.Value.ToUniversalTime().ToString(endFormat, CultureInfo.InvariantCulture));
            }

            if (!string.IsNullOrEmpty(value.TimeZone))
            {
                writer.WritePropertyName("time_zone");
                writer.WriteValue(value.TimeZone);
            }

            writer.WriteEndObject();
        }

        private static DateTimeOffset? ParseDateTime(string dateTimeString, out bool includeTime)
        {
            includeTime = false;

            if (string.IsNullOrEmpty(dateTimeString))
            {
                return null;
            }

            includeTime = dateTimeString.Contains("T") || dateTimeString.Contains(" ");

            return DateTimeOffset.Parse(dateTimeString, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
        }
    }
}
