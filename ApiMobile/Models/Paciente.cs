using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiMobile.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        public string? Ocupacao { get; set; }
    }
}