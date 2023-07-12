using ApiMobile.DTO;
using ApiMobile.Models;
using AutoMapper;

namespace ApiMobile.Mappers
{
    public class RotinaExercicioProfile : Profile
    {
        public RotinaExercicioProfile()
        {
            CreateMap<RotinaExercicio, RotinaExercicioDto>()
                .ForMember(dest => dest.IdExercicio, opt => opt
                    .MapFrom(src => src.IdExercicio))
                .ForMember(dest => dest.IdRotina, opt => opt
                    .MapFrom(src => src.IdRotina));
            CreateMap<RotinaExercicioDto, RotinaExercicio>();
        }
    }
}