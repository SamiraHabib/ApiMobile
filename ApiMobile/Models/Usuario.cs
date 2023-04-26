namespace ApiMobile.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaEncriptada { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
