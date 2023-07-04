namespace ApiMobile.Models
{
    public class DiaSemana
    {
        public int IdDiaSemana { get; set; }
        public string Nome { get; set; }

        public List<RotinaDiaSemana>? RotinasDiaSemanas { get; set; } = new();
        public List<Rotina> Rotinas { get; } = new();
    }
}