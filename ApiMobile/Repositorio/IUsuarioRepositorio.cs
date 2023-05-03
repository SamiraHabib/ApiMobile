using ApiMobile.Models;

namespace ApiMobile.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> GetUserByUserEmailAsync(string userEmail);
    }
}