namespace ApiMobile.Models
{
    public class DiaSemana
    {
        public int IdDiaSemana { get; set; }
        public string Nome { get; set; }

        public ICollection<RotinaDiaSemana> Rotinas { get; set; }
    }
}