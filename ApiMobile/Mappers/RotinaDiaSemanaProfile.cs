using ApiMobile.DTO;
using ApiMobile.Models;
using AutoMapper;

namespace ApiMobile.Mappers
{
    public class RotinaDiaSemanaProfile : Profile
    {
        public RotinaDiaSemanaProfile()
        {
            CreateMap<RotinaDiaSemana, RotinaDiaSemanaDto>()
                .ForMember(dest => dest.IdDiaSemana, opt => opt
                    .MapFrom(src => src.IdDiaSemana))
                .ForMember(dest => dest.IdRotina, opt => opt
                    .MapFrom(src => src.IdRotina));
            CreateMap<RotinaDiaSemanaDto, RotinaDiaSemana>();
        }
    }
}