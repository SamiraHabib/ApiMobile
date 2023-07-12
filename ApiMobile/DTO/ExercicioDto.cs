namespace ApiMobile.DTO
{
    public class ExercicioDto
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
    }
}
