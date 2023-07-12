using System.Collections;
using ApiMobile.DTO;
using ApiMobile.Models;
using ApiMobile.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Services
{
    public class RotinaPacienteService : IRotinaPacienteService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public RotinaPacienteService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<RotinaDto?> GetRotinaDoPaciente(int idPaciente, int idRotina)
        {
            var rotinaDoPaciente = _context.Rotina
                .Where(r => r.IdPaciente == idPaciente && r.IdRotina == idRotina)
                .Include(r => r.RotinaExercicios)
                .Include(r => r.RotinaDiaSemanas)
                .Include(r => r.Notificacoes)
                .ProjectTo<RotinaDto>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

            return Task.FromResult(rotinaDoPaciente);
        }

        public async Task<List<RotinaDto>> GetAllRotinasDoPaciente(int idPaciente)
        {
            var rotinaDoPaciente = _context.Rotina
                .Where(r => r.IdPaciente == idPaciente)
                .ToListAsync();

            var rotinasDto = new List<RotinaDto>();

            foreach (var rotina in await rotinaDoPaciente)
            {
                var rotinaDto = new RotinaDto
                {
                    IdRotina = rotina.IdRotina,
                    Titulo = rotina.Titulo,
                    Descricao = rotina.Descricao,
                    HorarioInicio = rotina.HorarioInicio,
                    HorarioFim = rotina.HorarioFim,
                    Intervalo = rotina.Intervalo,
                    Ativa = rotina.Ativa,
                    RotinaExercicios = rotina.RotinaExercicios != null
                        ? rotina.RotinaExercicios.Select(re => new RotinaExercicioDto
                        {
                            IdExercicio = re.IdExercicio,
                            IdRotina = re.IdRotina
                        }).ToList()
                        : new List<RotinaExercicioDto>(),
                    RotinaDiaSemanas = rotina.RotinaDiaSemanas != null
                    ? rotina.RotinaDiaSemanas.Select(rds => new RotinaDiaSemanaDto
                    {
                        IdRotina = rds.IdRotina,
                        IdDiaSemana = rds.IdDiaSemana
                    }).ToList()
                    : new List<RotinaDiaSemanaDto>(),
                    Notificacoes = rotina.Notificacoes != null
                    ? rotina.Notificacoes.Select(n => new NotificacaoDto
                    {
                        Titulo = n.Titulo,
                        Mensagem = n.Mensagem,
                        Hora = n.Hora,
                        Enviado = n.Enviado
                    }).ToList()
                    : new List<NotificacaoDto>()
                };

                rotinasDto.Add(rotinaDto);
            }

            return rotinasDto;
        }
    }
}
