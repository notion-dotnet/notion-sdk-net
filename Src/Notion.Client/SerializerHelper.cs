using Newtonsoft.Json;
using System.IO;

namespace Notion.Client
{
    internal class SerializerHelper
    {
        internal static T Deserialize<T>(Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    return serializer.Deserialize<T>(reader);
                }
            }
        }
    }
}
