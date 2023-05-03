using System.ComponentModel.DataAnnotations;

namespace ApiMobile.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        public string Nome { get; set; }
        public string? Ocupacao { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}