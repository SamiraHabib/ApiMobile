using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiMobile.Models
{
    public class Paciente
    {
        [Key]
        [JsonIgnore]
        public int IdPaciente { get; set; }
        public string Nome { get; set; }
        public string? Ocupacao { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}