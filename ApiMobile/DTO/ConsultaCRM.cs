using System.Text.Json.Serialization;

namespace ApiMobile.DTO
{
    public class ConsultaCRM
    {
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        [JsonPropertyName("numero")]
        public string Numero { get; set; }
        [JsonPropertyName("profissao")]
        public string Profissao { get; set; }
        [JsonPropertyName("uf")]
        public string UF { get; set; }
        [JsonPropertyName("situacao")]
        public string Situacao { get; set; }

    }
}
