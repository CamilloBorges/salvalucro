using SalvaLucro.Extensions.JsonConverters;
using System.Text.Json.Serialization;

namespace SalvaLucro.Domain.Model
{
    public class Bandeira
    {
        [JsonConverter(typeof(Int32JsonConverter))]
        public int codigoBandeira { get; set; }
        public string descricaoBandeira { get; set; }
    }
}
