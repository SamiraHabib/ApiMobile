using ApiMobile.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Text.Json;

namespace ApiMobile.Services
{
    public class CRMApiService : ICRMApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration configuration;

        public CRMApiService(IConfiguration config, IHttpClientFactory clientFactory)
        {
            configuration = config;
            _clientFactory = clientFactory;
        }
        public async Task<ConsultaCRMResult> GetMedicos(string numero, string uf)
        {
            var tokenApi = configuration.GetSection("CRMApi:token");

            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://www.consultacrm.com.br/api/index.php");

            var url = $"?tipo=crm&uf={uf}&q={numero}&chave={tokenApi.Value}&destino=json";

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ConsultaCRMResult>(stringResponse);

                if (result == null)
                {
                    throw new HttpRequestException("CRM não encontrado");
                }
                
                return result;

            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }
    }
}
