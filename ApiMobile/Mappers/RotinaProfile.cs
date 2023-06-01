using ApiMobile.Models;
using AutoMapper;

namespace ApiMobile.Mappers
{
    public class RotinaProfile : Profile
    {
        public RotinaProfile()
        {
            CreateMap<Rotina, Rotina>()
                .ForMember(dest => dest.Exercicios, opt => opt
                    .MapFrom(src => src.Exercicios
                        .Select(e => new RotinaExercicio { IdExercicio = e.IdExercicio })))
                .ForMember(dest => dest.DiasSemana, opt => opt
                    .MapFrom(src => src.DiasSemana
                        .Select(d => new RotinaDiaSemana { IdDiaSemana = d.IdDiaSemana })));
        }
    }
}