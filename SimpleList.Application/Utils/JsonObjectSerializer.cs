using System.Text.Json;

namespace SimpleList.Application.Utils
{
    public static class JsonObjectSerializer
    {
        public static string SerializeObject<T>(T item, JsonSerializerOptions options = null)
        {
            if(item == null)
            {
                return string.Empty;
            }
            if(options==null)
            {
                options = new JsonSerializerOptions() 
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
            }

            return JsonSerializer.Serialize<T>(item, options);
        }
    }
}
