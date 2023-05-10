using ApiMobile.Models;
namespace ApiMobile.DTO
{
    public class UsuarioAutenticado
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Usuario Usuario { get; set; }
        public JwtAuthentication Auth { get; set; }
    }
}