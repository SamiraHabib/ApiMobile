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

        public List<RotinaExercicio>? Exercicios { get; } = new();
        public List<RotinaDiaSemana>? RotinaDiaSemanas { get; } = new();
        public List<DiaSemana> DiaSemanas { get; } = new ();
        public List<Notificacao>? Notificacoes { get; } = new();

        [ForeignKey("IdPaciente")]
        public virtual Paciente? Paciente { get; set; }
    }
}