using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SalvaLucro.Extensions.JsonConverters
{
    internal class DecimalJsonConverter : JsonConverter<decimal>
    {

        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            decimal result;

            // Then try in Brazilian Portuguese
            if (!decimal.TryParse(reader.GetString(), NumberStyles.Any, CultureInfo.GetCultureInfo("pt-BR"), out result)  &&
                // Try parsing in the current culture
                !decimal.TryParse(reader.GetString(), NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                // Then in neutral language
                !decimal.TryParse(reader.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = decimal.Parse("0");
            }
            return result;
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.CurrentCulture));
        }
    }
}
