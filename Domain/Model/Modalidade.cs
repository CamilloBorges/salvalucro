using SalvaLucro.Extensions.JsonConverters;
using System.Text.Json.Serialization;

namespace SalvaLucro.Domain.Model
{
    public class Modalidade
    {

        [JsonConverter(typeof(Int32JsonConverter))]
        public int codigoModalidade { get; set; }
        public string descricaoModalidade { get; set; }
    }
}
