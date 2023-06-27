using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMobile.Models
{
    public class Rotina
    {
        [Key]
        public int IdRotina { get; set; }
        public int IdPaciente { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        [TimeOnly]
        public DateTime? HorarioInicio { get; set; }
        [TimeOnly]
        public DateTime? HorarioFim { get; set; }
        public TimeSpan? Intervalo { get; set; }
        public bool? Ativa { get; set; }

        public ICollection<RotinaExercicio>? Exercicios { get; set; }
        public ICollection<RotinaDiaSemana>? DiasSemana { get; set; }
        public ICollection<Notificacao>? Notificacoes { get; set; }

        [ForeignKey("IdPaciente")]
        public virtual Paciente? Paciente { get; set; }
    }
}