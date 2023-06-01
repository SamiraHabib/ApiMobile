using ApiMobile.Models;
using AutoMapper;

namespace ApiMobile.Mappers
{
    public class RotinaExercicioProfile : Profile
    {
        public RotinaExercicioProfile()
        {
            CreateMap<RotinaExercicio, RotinaExercicio>();
        }
    }
}