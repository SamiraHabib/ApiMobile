using ApiMobile.Models;

namespace ApiMobile.DTO
{
    public class RotinaDto
    {
        public int IdRotina { get; set; }
        public int IdPaciente { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime? HorarioInicio { get; set; }
        public DateTime? HorarioFim { get; set; }
        public TimeSpan? Intervalo { get; set; }
        public bool? Ativa { get; set; }
        public List<RotinaExercicioDto?> RotinaExercicios { get; set; }
        public List<RotinaDiaSemanaDto> RotinaDiaSemanas { get; set; }
        public List<NotificacaoDto> Notificacoes { get; set; }
        public List<ExercicioDto?> Exercicios { get; set; }
    }
}
