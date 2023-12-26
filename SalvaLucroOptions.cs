using Newtonsoft.Json.Linq;
using SalvaLucro.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SalvaLucro
{
    public class SalvaLucroOptions
    {

        public string client_id {  get; set; }
        public string client_secret { get; set; }
        public string grant_type { get; set; } = "client_credentials";
        public string CNPJ { get; set; }
        public string url { get; set; } = "https://app.salvalucro.com.br";
        public string versao { get; set; } = "v1";
        public string? proxyURL { get; set;}
        public string? proxyUserName { get; set;}
        public string? proxyPassword { get; set;}

    }

    
}
