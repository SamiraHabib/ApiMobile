namespace ApiMobile.Models
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public int IdUsuario { get; set; }
        public string? Ocupacao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
