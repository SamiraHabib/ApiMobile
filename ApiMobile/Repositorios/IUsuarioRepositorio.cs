using ApiMobile.Models;

namespace ApiMobile.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario?> GetUserByUserEmailAsync(string userEmail);
    }
}