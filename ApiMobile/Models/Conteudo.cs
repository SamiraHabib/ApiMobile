using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace ApiMobile.Models
{
    public class Conteudo
    {
        public int IdConteudo { get; set; }
        public int IdMedico { get; set; }
        [Required]
        public int IdTipoLesao { get; set; }
        public string? Titulo { get; set; }
        public string? Subtitulo { get; set; }
        public string? Descricao { get; set; }
        public string? Observacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public virtual Medico? Medico { get; set; }
        [ForeignKey("IdTipoLesao")]
        public virtual TipoLesao? TipoLesao { get; set; }
    }
}
