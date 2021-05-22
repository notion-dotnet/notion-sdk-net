using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Notion.Client
{
    internal class SerializerHelper
    {
        internal static T Deserialize<T>(Stream stream, List<JsonConverter> converters)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = JsonSerializer.CreateDefault();

                    if (converters.Any())
                    {
                        foreach (var converter in converters)
                        {
                            serializer.Converters.Add(converter);
                        }
                    }

                    return serializer.Deserialize<T>(reader);
                }
            }
        }
    }
}
