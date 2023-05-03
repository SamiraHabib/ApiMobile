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

        [JsonIgnore]
        public int? IdPaciente { get; set; }

        [JsonIgnore]
        public int? IdMedico { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string SenhaEncriptada { get; set; }

        public virtual Paciente? Paciente { get; set; }
        public virtual Medico? Medico { get; set; }
    }
}
