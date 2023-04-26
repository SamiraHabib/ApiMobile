namespace ApiMobile.Models
{
    public class TipoLesao
    {
        public int IdTipoLesao { get; set; }
        public int IdMedico { get; set; }
        public string? Nome { get; set; }
        public string? Sigla { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public virtual Medico Medico { get; set; }
    }
}
