using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace ApiMobile.Models
{
    public class Usuario
    {
        [Key]
        [JsonIgnore]
        public int IdUsuario { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string SenhaEncriptada { get; set; }

        [Required]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [JsonIgnore]
        public int? IdPaciente { get; set; }
        public virtual Paciente? Paciente { get; set; }
        
        [JsonIgnore]
        public int? IdMedico { get; set; }
        public virtual Medico? Medico { get; set; }
    }
}
