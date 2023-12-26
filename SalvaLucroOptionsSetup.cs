using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace SalvaLucro
{
    public class SalvaLucroOptionsSetup : IConfigureOptions<SalvaLucroOptions>
    {

        private const string SectionName = "SalvaLucro";
        private readonly IConfiguration _configuration;

        public SalvaLucroOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(SalvaLucroOptions options)
        {
            _configuration
           .GetSection(SectionName)
           .Bind(options);
        }
    }
}
