using SalvaLucro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaLucro.Domain.Services
{
    public interface IAjustesService
    {
        public Task<IEnumerable<Ajuste>> getAjustesAsync(DateOnly dataInicial, DateOnly dataFinal);
    }
}
