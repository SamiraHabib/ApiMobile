using ApiMobile.Models;

namespace ApiMobile.DTO
{
    public class RotinaDto
    {
        public int IdRotina { get; set; }
        public int IdPaciente { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public TimeSpan? HorarioInicio { get; set; }
        public TimeSpan? HorarioFim { get; set; }
        public TimeSpan? Intervalo { get; set; }
        public bool? Ativa { get; set; }
        public ICollection<RotinaExercicio> Exercicios { get; set; }
        public ICollection<RotinaDiaSemana> DiasSemana { get; set; }
        public ICollection<NotificacaoDto> Notificacoes { get; set; }
    }
}
