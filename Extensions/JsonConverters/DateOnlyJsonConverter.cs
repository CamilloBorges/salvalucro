using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SalvaLucro.Extensions.JsonConverters
{
    internal class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            DateOnly result;

            // Try parsing in the current culture
            // Try parsing in the current culture
            if (!DateOnly.TryParse(reader.GetString(), CultureInfo.CurrentCulture, out result) &&
                // Then try in Brazilian Portuguese
                !DateOnly.TryParse(reader.GetString(), CultureInfo.GetCultureInfo("pt-BR"), out result) &&
                // Then in neutral language
                !DateOnly.TryParse(reader.GetString(), CultureInfo.InvariantCulture, out result))
            {
                result = DateOnly.MinValue;
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.CurrentCulture));
        }
    }
}
