using System;
using Newtonsoft.Json;

namespace Notion.Client
{
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
