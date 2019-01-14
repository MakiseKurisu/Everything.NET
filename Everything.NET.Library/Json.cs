using System.Web.Script.Serialization;

namespace Everything.NET.Library
{
    public static class Json
    {
        public static T ToObject<T>(string json)
        {
            var js = new JavaScriptSerializer();
            return js.Deserialize<T>(json);
        }

        public static string ToJson<T>(T obj)
        {
            var js = new JavaScriptSerializer();
            return js.Serialize(obj);
        }
    }
}
