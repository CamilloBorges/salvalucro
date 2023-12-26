using SalvaLucro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaLucro.Domain.Services
{
    public interface IVendasService
    {
        public Task<IEnumerable<Venda>> GetVendasAsync(DateTime? data);
    }
}
