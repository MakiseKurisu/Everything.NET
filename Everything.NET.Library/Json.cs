using Newtonsoft.Json;
using System.IO;

namespace Everything.NET.Library
{
    public static class Json
    {
        public static T ToObject<T>(Stream json)
        {
            var js = new JsonSerializer();

            using (var sr = new StreamReader(json))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                return js.Deserialize<T>(jsonTextReader);
            }
        }
    }
}
