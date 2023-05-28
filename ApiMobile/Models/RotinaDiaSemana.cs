using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMobile.Models
{
    public class RotinaDiaSemana
    {
        [Required]
        public int IdRotina { get; set; }
        [Required]
        public int IdDiaSemana { get; set; }

        [ForeignKey("IdRotina")]
        public Rotina Rotina { get; set; }
        [ForeignKey("IdDiaSemana")]
        public DiaSemana DiaSemana { get; set; }
    }
}