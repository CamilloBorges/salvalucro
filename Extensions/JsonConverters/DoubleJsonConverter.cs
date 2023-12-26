using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SalvaLucro.Extensions.JsonConverters
{
    internal class DoubleJsonConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            double result;

           
            if (// Then try in Brazilian Portuguese
                !double.TryParse(reader.GetString(), NumberStyles.Any, CultureInfo.GetCultureInfo("pt-BR"), out result) &&
                // Try parsing in the current culture
                !double.TryParse(reader.GetString(), NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                // Then in neutral language
                !double.TryParse(reader.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = double.Parse("0");
            }
            return result;
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.CurrentCulture));
        }
    }
}
