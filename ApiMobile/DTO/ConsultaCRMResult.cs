using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace ApiMobile.DTO
{
    public class ConsultaCRMResult
    {
        [JsonPropertyName("url")]
        public string URL { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }
        [JsonPropertyName("api_limite")]
        public string ApiLimite { get; set; }
        [JsonPropertyName("api_consultas")]
        public string ApiConsultas { get; set; }
        [JsonPropertyName("item")]
        public ICollection<ConsultaCRM> Itens { get; set; }
    }
}
