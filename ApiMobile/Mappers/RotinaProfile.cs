using ApiMobile.DTO;
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
                    .MapFrom(src => src.Exercicios))
                .ForMember(dest => dest.DiaSemanas, opt => opt
                    .MapFrom(src => src.RotinaDiaSemanas.Select(rds => rds.Rotina)));

            CreateMap<Rotina, Rotina>();
        }
    }
}