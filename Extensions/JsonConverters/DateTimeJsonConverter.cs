using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SalvaLucro.Extensions.JsonConverters
{
    internal class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            DateTime result;

            // Try parsing in the current culture
            // Try parsing in the current culture
            if (!DateTime.TryParse(reader.GetString(), CultureInfo.CurrentCulture, out result) &&
                // Then try in Brazilian Portuguese
                !DateTime.TryParse(reader.GetString(), CultureInfo.GetCultureInfo("pt-BR"), out result) &&
                // Then in neutral language
                !DateTime.TryParse(reader.GetString(), CultureInfo.InvariantCulture, out result))
            {
                result = DateTime.MinValue;
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.CurrentCulture));
        }
    }
}
