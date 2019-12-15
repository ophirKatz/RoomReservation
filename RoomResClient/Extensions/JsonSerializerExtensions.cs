using Newtonsoft.Json;
using System.IO;

namespace RoomResClient.Extensions
{
    public static class JsonSerializerExtensions
    {
        public static T Deserialize<T>(this JsonSerializer jsonSerializer, byte[] data) where T : class
        {
            return jsonSerializer.Deserialize<T>(data.ToString());
        }

        public static T Deserialize<T>(this JsonSerializer jsonSerializer, string data) where T : class
        {
            using var stream = new StringReader(data);
            using var reader = new JsonTextReader(stream);
            return jsonSerializer.Deserialize<T>(reader);
        }
    }
}