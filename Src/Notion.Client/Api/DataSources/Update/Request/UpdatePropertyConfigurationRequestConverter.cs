using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Notion.Client
{
    // write custom json convert for UpdatePropertyConfigurationRequest to flatten PropertyRequest into parent object
    public class UpdatePropertyConfigurationRequestConverter<T> : JsonConverter<UpdatePropertyConfigurationRequest<T>> where T : DataSourcePropertyConfigRequest
    {
        public override bool CanRead => false;

        public override void WriteJson(JsonWriter writer, UpdatePropertyConfigurationRequest<T> value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            if (value.Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteValue(value.Name);
            }

            if (value.PropertyRequest != null)
            {
                var propertyRequestJson = JObject.FromObject(value.PropertyRequest, serializer);
                foreach (var property in propertyRequestJson.Properties())
                {
                    property.WriteTo(writer);
                }
            }

            writer.WriteEndObject();
        }

        public override UpdatePropertyConfigurationRequest<T> ReadJson(JsonReader reader, Type objectType, UpdatePropertyConfigurationRequest<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Deserialization is not implemented for UpdatePropertyConfigurationRequest.");
        }
    }
}
