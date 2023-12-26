using SalvaLucro.Extensions.JsonConverters;
using System.Text.Json.Serialization;

namespace SalvaLucro.Domain.Model
{
    public class Parcela
    {
        public string nsu {  get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly dataVenda { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly dataCredito { get; set; }
        public decimal valorBruto { get; set; }
        public decimal valorLiquido { get; set; }
        public decimal valorDesconto { get; set; }
        [JsonConverter(typeof(Int32JsonConverter))]
        public int numeroParcela { get; set; }
        [JsonConverter(typeof(Int32JsonConverter))]
        public int quantidadeParcelas { get; set; }

    }
}
