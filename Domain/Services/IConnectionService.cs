using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaLucro.Domain.Services
{
    public interface IConnectionService
    {
        public Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string>? queryStringParams);
    }
}
