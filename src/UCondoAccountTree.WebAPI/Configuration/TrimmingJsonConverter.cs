namespace UCondoAccountTree.WebAPI.Configuration;

using Newtonsoft.Json;

public class TrimmingJsonConverter : JsonConverter
{
    public override bool CanRead => true;
    public override bool CanWrite => false;

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(string);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
        JsonSerializer serializer)
    {
        return ((string)reader.Value)?.Trim();
    }
}
