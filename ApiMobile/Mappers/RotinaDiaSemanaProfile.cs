using ApiMobile.Models;
using AutoMapper;

namespace ApiMobile.Mappers
{
    public class RotinaDiaSemanaProfile : Profile
    {
        public RotinaDiaSemanaProfile()
        {
            CreateMap<RotinaDiaSemana, RotinaDiaSemana>();
        }
    }
}