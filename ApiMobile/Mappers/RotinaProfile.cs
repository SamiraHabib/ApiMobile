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
                .ForMember(dest => dest.RotinaExercicios, opt => opt
                    .MapFrom(src => src.RotinaExercicios))
                .ForMember(dest => dest.Ativa, opt => opt
                    .MapFrom(src => src.Ativa))
                .ForMember(dest => dest.Descricao, opt => opt
                    .MapFrom(src => src.Descricao))
                .ForMember(dest => dest.Notificacoes, opt => opt
                    .MapFrom(src => src.Notificacoes))
                .ForMember(dest => dest.HorarioFim, opt => opt
                    .MapFrom(src => src.HorarioFim))
                .ForMember(dest => dest.HorarioInicio, opt => opt
                    .MapFrom(src => src.HorarioInicio))
                .ForMember(dest => dest.Intervalo, opt => opt
                    .MapFrom(src => src.Intervalo))
                .ForMember(dest => dest.Titulo, opt => opt
                    .MapFrom(src => src.Titulo))
                .ForMember(dest => dest.IdPaciente, opt => opt
                    .MapFrom(src => src.IdPaciente))
                .ForMember(dest => dest.IdRotina, opt => opt
                    .MapFrom(src => src.IdRotina))
                .ForMember(dest => dest.RotinaDiaSemanas, opt => opt
                    .MapFrom(src => src.RotinaDiaSemanas));

            CreateMap<RotinaDto, Rotina>();
        }
    }
}