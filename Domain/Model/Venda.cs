using SalvaLucro.Extensions.JsonConverters;
using System.Text.Json.Serialization;

namespace SalvaLucro.Domain.Model
{
    public class Venda
    {
        public string codigoVenda { get; set; }
        public string cnpj { get; set; }   
        public string razaosocial { get; set; }
        public string numeroPV { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly dataVenda { get; set; }
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly horaVenda { get; set; }
        public string nsu {  get; set; }
        public string bin { get; set; }
        public string cartao { get; set; }
        public Adquirente adquirente { get; set; }
        public Produto produto { get; set; }
        public Bandeira bandeira { get; set; }
        public Modalidade modalidade { get; set; }
        public decimal valorBruto { get; set; }
        public decimal valorDesconto { get; set; }
        public decimal valorLiquido { get; set; }
        public decimal taxa { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly dataCredito { get; set; }
        public int quantidadeParcelas { get; set; }
        public string codigoAutorizacao { get;set; }
        public string terminal { get;set; }
        public string tid { get;set; }
        public IEnumerable<Parcela> parcelas { get; set; }
    }
}
