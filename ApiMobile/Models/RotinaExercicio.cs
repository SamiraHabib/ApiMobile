using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMobile.Models
{
    public class RotinaExercicio
    {
        [Required]
        public int IdRotina { get; set; }
        [Required]
        public int IdExercicio { get; set; }

        [ForeignKey("IdRotina")]
        public Rotina? Rotina { get; set; }
        [ForeignKey("IdExercicio")]
        public Exercicio? Exercicio { get; set; }
    }
}