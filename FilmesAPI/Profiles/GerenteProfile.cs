using AutoMapper;
using FilmesAPI.Database.Dtos.Gerente;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(
                    g => g.Cinemas,
                    opts => opts.MapFrom(
                        g => g.Cinemas.Select(
                            c => new
                            {
                                c.Id,
                                c.Nome,
                                c.EnderecoId,
                                c.Endereco,
                                DataHoraConsulta = DateTime.Now
                            }
                        )
                    )
                )
                .ForMember(
                    g => g.DataHoraConsulta,
                    opts => opts.MapFrom(
                        g => DateTime.Now
                    )
                );
        }
    }
}
