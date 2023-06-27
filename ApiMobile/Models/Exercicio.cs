using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace ApiMobile.Models
{
    public class Exercicio
    {
        public int IdExercicio { get; set; }
        public int IdMedico { get; set; }
        public int IdTipoLesao { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Instrucoes { get; set; }
        public byte[]? EncodedGif { get; set; }
        public string? Precaucoes { get; set; }
        public string? Observacoes { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public ICollection<RotinaExercicio>? Rotinas { get; set; }

        public virtual Medico? Medico { get; set; }
        [ForeignKey("IdTipoLesao")]
        public virtual TipoLesao? TipoLesao { get; set; }
    }
}