using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiMobile.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        public string NumeroCrm { get; set; }
        public string UfCrm { get; set; }
        [JsonIgnore]
        public string? SituacaoCrm { get; set; }
    }
}