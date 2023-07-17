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
            var rotinaDoPaciente = await _context.Rotina
                .Where(r => r.IdPaciente == idPaciente)
                .Select(r => new RotinaDto()
                {
                    IdRotina = r.IdRotina,
                    Titulo = r.Titulo,
                    Descricao = r.Descricao,
                    HorarioInicio = r.HorarioInicio,
                    HorarioFim = r.HorarioFim,
                    Intervalo = r.Intervalo,
                    Ativa = r.Ativa,
                    RotinaDiaSemanas = (r.RotinaDiaSemanas ?? new List<RotinaDiaSemana>()).Select(d =>
                        new RotinaDiaSemanaDto
                        {
                            IdRotina = d.IdRotina,
                            IdDiaSemana = d.IdDiaSemana
                        }).ToList()
                })
                .ToListAsync();

            //Rotina Exercicio
            var rotinaIds = rotinaDoPaciente.Select(r => r.IdRotina).ToList();

            var rotinasComExercicios = await _context.Rotina
                .Include(r => r.RotinaExercicios)
                .ThenInclude(re => re.Exercicio)
                .Where(r => rotinaIds.Contains(r.IdRotina))
                .ToListAsync();

            foreach (var rotina in rotinaDoPaciente)
            {
                var rotinaComExercicios = rotinasComExercicios.FirstOrDefault(r => r.IdRotina == rotina.IdRotina);
                if (rotinaComExercicios != null)
                {
                    rotina.Exercicios = rotinaComExercicios.RotinaExercicios
                        .Where(re => re.Exercicio != null)
                        .Select(re => new ExercicioDto
                        {
                            IdExercicio = re.Exercicio.IdExercicio,
                            Nome = re.Exercicio.Nome,
                            Descricao = re.Exercicio.Descricao,
                            Instrucoes = re.Exercicio.Instrucoes,
                            IdMedico = re.Exercicio.IdMedico,
                            IdTipoLesao = re.Exercicio.IdTipoLesao,
                            EncodedGif = re.Exercicio.EncodedGif,
                            Precaucoes = re.Exercicio.Precaucoes,
                            Observacoes = re.Exercicio.Observacoes,
                            DataAtualizacao = re.Exercicio.DataAtualizacao,
                            DataCriacao = re.Exercicio.DataCriacao
                        })
                        .ToList();
                }
            }

            //Notificacao Rotina
            var notificacoes = await _context.Notificacao
                .Where(n => rotinaIds.Contains((int)n.IdRotina))
                .ToListAsync();

            foreach (var rotina in rotinaDoPaciente)
            {
                rotina.Notificacoes = notificacoes
                    .Where(n => n.IdRotina == rotina.IdRotina)
                    .Select(n => new NotificacaoDto
                    {
                        Titulo = n.Titulo,
                        Mensagem = n.Mensagem,
                        Hora = n.Hora,
                        Enviado = n.Enviado
                    })
                    .ToList();
            }

            return rotinaDoPaciente;
        }
    }
}
