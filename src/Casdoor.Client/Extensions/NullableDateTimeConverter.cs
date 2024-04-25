using System.Text.Json;
using System.Text.Json.Serialization;

namespace Casdoor.Client;

public class NullableDateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? str = reader.GetString();
        if (string.IsNullOrWhiteSpace(str))
        {
            return null;
        }
        return DateTime.Parse(str);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            writer.WriteStringValue(value.Value.ToString("o"));
        }
    }
}
