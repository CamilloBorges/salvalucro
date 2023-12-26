using SalvaLucro.Extensions.JsonConverters;
using System.Text.Json.Serialization;

namespace SalvaLucro.Domain.Model
{
    public class Adquirente
    {
        [JsonConverter(typeof(Int32JsonConverter))]
        public int codigoAdquirente { get; set; }
        public string nomeAdquirente { get; set; }
    }
}
