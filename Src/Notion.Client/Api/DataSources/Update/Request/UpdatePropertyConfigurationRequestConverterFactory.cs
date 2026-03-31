using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Converter factory that creates the appropriate generic converter for UpdatePropertyConfigurationRequest.
    /// This solves the issue with open generic types in JsonConverter attributes.
    /// </summary>
    public class UpdatePropertyConfigurationRequestConverterFactory : JsonConverter
    {
        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType &&
                   objectType.GetGenericTypeDefinition() == typeof(UpdatePropertyConfigurationRequest<>) &&
                   typeof(DataSourcePropertyConfigRequest).IsAssignableFrom(objectType.GetGenericArguments()[0]);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            var objectType = value.GetType();
            var genericArgument = objectType.GetGenericArguments()[0];
            var converterType = typeof(UpdatePropertyConfigurationRequestConverter<>).MakeGenericType(genericArgument);
            var converter = (JsonConverter)Activator.CreateInstance(converterType);

            converter.WriteJson(writer, value, serializer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Deserialization is not implemented for UpdatePropertyConfigurationRequest.");
        }
    }
}
