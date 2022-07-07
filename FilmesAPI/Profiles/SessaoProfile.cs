using AutoMapper;
using FilmesAPI.Database.Dtos.Sessao;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(
                    dto => dto.HorarioFimSessao,
                    opts => opts.MapFrom(dto =>
                        dto.HorarioSessao.AddMinutes(dto.Filme.Duracao)
                    )
                );
        }
    }
}
