using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace io.github.crisstanza.csharputils
{
    public class JsonUtils
    {
        private readonly bool debug;
        public JsonUtils(bool debug)
        {
            this.debug = debug;
        }
        public byte[] SerializeToArray<T>(T jsonObject)
        {
            return Encoding.UTF8.GetBytes(Serialize(jsonObject) ?? "");
        }
        public string Serialize<T>(T jsonObject)
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = this.debug, DefaultIgnoreCondition = this.debug ? JsonIgnoreCondition.Never : JsonIgnoreCondition.WhenWritingNull };
            return JsonSerializer.Serialize<T>(jsonObject, options);
        }
        public T Deserialize<T>(string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
