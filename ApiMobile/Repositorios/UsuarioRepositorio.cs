using ApiMobile.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApiContext _context;

        public UsuarioRepositorio(ApiContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUserByUserEmailAsync(string emailUsuario)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == emailUsuario);
        }
    }
}