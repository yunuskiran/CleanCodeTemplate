using Api.Shared.Data;

namespace Api.Infrastructure.Shared.Data;

public class SampleSerializer : ISerializer
{
    public T Deserialize<T>(string text) => default!;

    public string Serialize<T>(T obj) => default!;

    public string Serialize<T>(T obj, Type type) => default!;
}
