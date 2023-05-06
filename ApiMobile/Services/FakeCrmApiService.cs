using ApiMobile.DTO;
using ApiMobile.Services.Interfaces;

namespace ApiMobile.Services
{
    public class FakeCrmApiService : ICRMApiService
    {
        public Task<ConsultaCRMResult> GetMedicosAsync(string numero, string uf)
        {
            var consultaCRMResult = new ConsultaCRMResult
            {
                URL = "https://example.com",
                Total = 1,
                Status = "Success",
                Mensagem = "Consulta CRM result",
                ApiLimite = "10",
                ApiConsultas = "https://api.example.com",
                Itens = new List<ConsultaCRM>
                {
                    new ConsultaCRM
                    {
                        Nome = "teste",
                        Numero = numero,
                        Profissao = "Testador",
                        Situacao = "ativo",
                        Tipo = "CRM",
                        UF = uf
                    },
                }
            };
            return Task.FromResult(consultaCRMResult);
        }
    }
}
