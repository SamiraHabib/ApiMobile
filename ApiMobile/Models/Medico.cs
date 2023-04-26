namespace ApiMobile.Models
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public int IdUsuario { get; set; }
        public string NumeroCrm { get; set; }
        public string UfCrm { get; set; }
        public string SituacaoCrm { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
