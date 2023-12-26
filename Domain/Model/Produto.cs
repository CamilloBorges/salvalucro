using SalvaLucro.Extensions.JsonConverters;
using System.Text.Json.Serialization;

namespace SalvaLucro.Domain.Model
{
    public class Produto
    {
        [JsonConverter(typeof(Int32JsonConverter))]
        public int codigoProduto { get; set; }
        public string descricaoProduto { get; set; }
    }
}
