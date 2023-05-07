using ApiMobile.DTO;
using ApiMobile.Models;

namespace ApiMobile.Services.Interfaces
{
    public interface IAuthService
    {
        JwtAuthentication GenerateJwtToken(UsuarioAutenticado usuarioAtentificado);
        Task<Usuario> ValidateCredentials(string email, string password);
    }
}