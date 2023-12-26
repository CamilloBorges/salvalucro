using Microsoft.Extensions.Options;
using SalvaLucro.Domain.Model;
using SalvaLucro.Domain.Resources;
using SalvaLucro.Domain.Services;
using SalvaLucro.Exceptions;
using SalvaLucro.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SalvaLucro.Services
{
    public class AjustesService : IAjustesService
    {
        private readonly IConnectionService _connectionService;
        private readonly SalvaLucroOptions _options;

        public AjustesService(IConnectionService connectionService, IOptions<SalvaLucroOptions> options)
        {
            _connectionService = connectionService;
            _options = options.Value;
        }

        public async Task<IEnumerable<Ajuste>> getAjustesAsync(DateOnly dataInicial, DateOnly dataFinal)
        {
            if (dataInicial == DateOnly.MinValue)
                dataInicial = DateOnly.FromDateTime(DateTime.Now.Date);
            if (dataFinal == DateOnly.MinValue)
                dataFinal = DateOnly.FromDateTime(DateTime.Now.Date);

            var queryStringParams = new Dictionary<string, string>()
            {
                ["cnpj"] = FormatCnpjCpf.FormatCNPJ(_options.CNPJ),
                ["dataInicial"] = dataInicial.ToString("yyyy-MM-dd"),
                ["dataFinal"] = dataFinal.ToString("yyyy-MM-dd")
            };

            var response = await _connectionService.GetAsync($"/api/{_options.versao}/ajustes", queryStringParams);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<Ajuste>>();
            else
                throw new HttpRequestException("Erro Vendas ", await response.ExceptionResponse());
        }
    }
}
