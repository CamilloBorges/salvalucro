using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SalvaLucro.Extensions.JsonConverters
{
    internal class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            TimeOnly result;

            // Try parsing in the current culture
            // Try parsing in the current culture
            if (!TimeOnly.TryParse(reader.GetString(), CultureInfo.CurrentCulture, out result) &&
                // Then try in Brazilian Portuguese
                !TimeOnly.TryParse(reader.GetString(), CultureInfo.GetCultureInfo("pt-BR"), out result) &&
                // Then in neutral language
                !TimeOnly.TryParse(reader.GetString(), CultureInfo.InvariantCulture, out result))
            {
                result = TimeOnly.MinValue;
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.CurrentCulture));
        }
    }
}
