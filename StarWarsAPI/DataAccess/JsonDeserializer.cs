
using System.Text.Json;

namespace StarWarsAPI.DataAccess;
public class JsonDeserializer : IJsonDeserializer
{
    public T? Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json);
    }
}
