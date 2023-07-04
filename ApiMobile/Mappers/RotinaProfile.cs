using ApiMobile.DTO;
using ApiMobile.Models;
using AutoMapper;

namespace ApiMobile.Mappers
{
    public class RotinaProfile : Profile
    {
        public RotinaProfile()
        {
            CreateMap<Rotina, RotinaDto>()
                .ForMember(dest => dest.Exercicios, opt => opt
                    .MapFrom(src => src.Exercicios))
                .ForMember(dest => dest.DiasSemana, opt => opt
                    .MapFrom(src => src.RotinaDiaSemanas));

            CreateMap<RotinaDto, Rotina>();
        }
    }
}