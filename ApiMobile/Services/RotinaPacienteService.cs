using ApiMobile.Models;
using ApiMobile.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Services
{
    public class RotinaPacienteService : IRotinaPacienteService
    {
        private readonly ApiContext _context;

        public RotinaPacienteService(ApiContext context)
        {
            _context = context;
        }

        public async Task<Rotina?> GetRotinaDoPaciente(int idPaciente, int idRotina)
        {
            var rotinaDoPaciente = await _context.Rotina
                .Where(r => r.IdPaciente == idPaciente && r.IdRotina == idRotina)
                .Include(r => r.Exercicios)
                .Include(r => r.DiasSemana)
                .Include(r => r.Notificacoes)
                .FirstOrDefaultAsync();

            return rotinaDoPaciente;
        }
    }
}
