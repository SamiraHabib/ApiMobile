using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMobile.Models
{
    public class Notificacao
    {
        [Key]
        public int IdNotificacao { get; set; }
        public int IdExercicio { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime Hora { get; set; }
        public bool? Enviado { get; set; }

        [ForeignKey("Rotina")]
        public int? IdRotina { get; set; }
        public virtual Rotina? Rotina { get; set; }
        public virtual Exercicio? Exercicio { get; set; }
    }
}