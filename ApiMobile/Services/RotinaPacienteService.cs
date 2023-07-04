using ApiMobile.DTO;
using ApiMobile.Models;
using ApiMobile.Services.Interfaces;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Services
{
    public class RotinaPacienteService : IRotinaPacienteService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public RotinaPacienteService(ApiContext context)
        {
            _context = context;
        }

        public Task<RotinaDto?> GetRotinaDoPaciente(int idPaciente, int idRotina)
        {
            var rotinaDoPaciente = _context.Rotina
                .Where(r => r.IdPaciente == idPaciente && r.IdRotina == idRotina)
                .Include(r => r.Exercicios)
                .Include(r => r.RotinaDiaSemanas)
                .Include(r => r.Notificacoes)
                .ProjectTo<RotinaDto>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

            return Task.FromResult(rotinaDoPaciente);
        }
    }
}
