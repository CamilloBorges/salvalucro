using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SalvaLucro.Domain.Model;
using SalvaLucro.Domain.Services;
using SalvaLucro.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SalvaLucro.Services
{
    internal class ConnectionService : IConnectionService
    {
        private Token _token;
        private HttpClient _httpClient;
        private CookieContainer _cookieContainer;
        private HttpClientHandler _httpClientHandler;

        private readonly Uri _url;
        private readonly WebProxy _proxy;
        private readonly SalvaLucroOptions _options;

        public ConnectionService(IOptions<SalvaLucroOptions> options)
        {
            _options = options.Value;
            _url = new Uri(_options.url);
            _cookieContainer = new CookieContainer();
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.CookieContainer = _cookieContainer;

            if (!string.IsNullOrEmpty(_options.proxyURL) &&
                !string.IsNullOrEmpty(_options.proxyUserName) &&
                !string.IsNullOrEmpty(_options.proxyPassword))
            {
                _proxy = new WebProxy()
                {
                    Address = new Uri(_options.proxyURL),

                    Credentials = new NetworkCredential(
                   userName: _options.proxyUserName,
                   password: _options.proxyPassword)
                };
                _httpClientHandler.Proxy = _proxy; 
            }

            _httpClient = new HttpClient(handler: _httpClientHandler, disposeHandler: false)
            {
                BaseAddress = _url,
            };
            var task = Task.Run(async () => await loginAsync()); 
            task.Wait();
        }

        private async Task loginAsync()
        {
            var webRequest = new HttpRequestMessage(HttpMethod.Post, $"/api/{_options.versao}/token");
            webRequest.Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("client_id", _options.client_id),
                    new KeyValuePair<string, string>("client_secret", _options.client_secret),
                    new KeyValuePair<string, string>("grant_type", _options.grant_type)
                });

            var response = _httpClient.Send(webRequest);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _token = await response.Content.ReadFromJsonAsync<Token>();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.acess_token);
            } else
            {
                var ex = await response.ExceptionResponse();

                throw new HttpRequestException("Erro ao Logar no SalvaLucro", ex) ;
            }
        }

        private async void CheckLogin()
        {
            if(_token.refresh_expires_in.AddMilliseconds(_token.expires_in) < DateTime.UtcNow)
                await loginAsync();
        }

        public async Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string>? queryStringParams)
        {
            CheckLogin();
            var requestUrl = url;
            if (queryStringParams != null)
                requestUrl = QueryHelpers.AddQueryString(url, queryStringParams);

            var webRequest = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            return await _httpClient.SendAsync(webRequest);
        }

    }
}
