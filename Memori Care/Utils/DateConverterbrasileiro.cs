using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

public class DateConverterBrasileiro : JsonConverter<DateTime?>
{
    private readonly string _formato = "dd/MM/yyyy";

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Se o valor no JSON for nulo ou uma string vazia, retorna null sem erro
        string? dataTexto = reader.GetString();

        if (string.IsNullOrWhiteSpace(dataTexto))
        {
            return null;
        }

        // Se houver texto, tenta converter no formato brasileiro
        return DateTime.ParseExact(dataTexto, _formato, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        // Se o valor for nulo no C#, escreve "null" no JSON
        if (value == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            // Se houver data, escreve no formato dd/MM/yyyy
            writer.WriteStringValue(value.Value.ToString(_formato));
        }
    }
}