using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiMobile.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        [Required]
        public string Email { get; set; }
        [JsonIgnore]
        [Required]
        public string SenhaEncriptada { get; set; }
    }
}
