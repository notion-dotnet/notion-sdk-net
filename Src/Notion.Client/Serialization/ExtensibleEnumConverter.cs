using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// A Newtonsoft.Json converter for extensible enum structs.
    /// Serializes as a plain string and deserializes any string value —
    /// including values unknown at compile time — without throwing.
    /// <para>
    /// Apply via <c>[JsonConverter(typeof(ExtensibleEnumConverter&lt;T&gt;))]</c> on the struct type itself.
    /// </para>
    /// </summary>
    public class ExtensibleEnumConverter<T> : JsonConverter
        where T : struct
    {
        public override bool CanConvert(Type objectType)
            => objectType == typeof(T) || objectType == typeof(T?);

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = reader.Value?.ToString() ?? string.Empty;
            return Activator.CreateInstance(typeof(T), value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value?.ToString() ?? string.Empty);
        }
    }
}
