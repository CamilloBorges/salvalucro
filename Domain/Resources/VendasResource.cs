using SalvaLucro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaLucro.Domain.Resources
{
    internal class VendasResource
    {
        public IEnumerable<Venda> VENDAS { get; set; }
        public string MENSAGEM {  get; set; }
    }
}
