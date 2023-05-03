using ApiMobile.Models;

namespace ApiMobile.Services
{
    public interface IAuthService
    {
        JwtAuthentication GenerateJwtToken(UsuarioAutentificado usuarioAtentificado);
        Task<Usuario> ValidateCredentials(string email, string password);
    }
}