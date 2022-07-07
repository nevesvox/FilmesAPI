using AutoMapper;
using FilmesAPI.Database.Dtos;
using FilmesAPI.Database.Dtos.Endereco;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>()
                .ForMember(
                    dto => dto.DataHoraConsulta,
                    opts => opts.MapFrom(dto => DateTime.Now)
                );
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}
