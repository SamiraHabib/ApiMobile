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
        public List<RotinaExercicio> Exercicios { get; set; }
        public List<RotinaDiaSemana> DiasSemana { get; set; }
        public List<NotificacaoDto> Notificacoes { get; set; }
    }
}
