using Microsoft.Extensions.Options;
using SalvaLucro.Domain.Model;
using SalvaLucro.Domain.Resources;
using SalvaLucro.Domain.Services;
using SalvaLucro.Exceptions;
using SalvaLucro.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SalvaLucro.Services
{
    public class VendasService : IVendasService
    {
        private readonly IConnectionService _connectionService;
        private readonly SalvaLucroOptions _options;

        public VendasService(IConnectionService connectionService, IOptions<SalvaLucroOptions> options)
        {
            _connectionService = connectionService;
            _options = options.Value;
        }

        public async Task<IEnumerable<Venda>> GetVendasAsync(DateTime? data)
        {
            var sendDate = data ?? DateTime.Now.Date;

            var queryStringParams = new Dictionary<string, string>()
            {
                ["cnpj"] = FormatCnpjCpf.FormatCNPJ(_options.CNPJ),
                ["data"] = sendDate.ToString("yyyy-MM-dd")
            };

            var response = await _connectionService.GetAsync($"/api/{_options.versao}/vendas", queryStringParams);
            VendasResource result;
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<VendasResource>();
            else
                throw new HttpRequestException("Erro Vendas ", await response.ExceptionResponse());
            return result.VENDAS;
        }
    }
}
