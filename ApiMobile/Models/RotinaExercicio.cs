using System.ComponentModel.DataAnnotations;

namespace ApiMobile.Models
{
    public class RotinaExercicio
    {
        [Required]
        public int IdRotina { get; set; }
        [Required]
        public int IdExercicio { get; set; }

        public Rotina Rotina { get; set; }
        public Exercicio Exercicio { get; set; }
    }
}