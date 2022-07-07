using AutoMapper;
using FilmesAPI.Database;
using FilmesAPI.Database.Dtos.Endereco;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AddEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> GetEnderecos()
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
        }

        public ReadEnderecoDto GetEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(f => f.Id == id);

            if (endereco != null)
            {
                ReadEnderecoDto enderecoReturn = _mapper.Map<ReadEnderecoDto>(endereco);
                return enderecoReturn;
            }

            return null;
        }

        public ReadEnderecoDto UpdateEndereco(UpdateEnderecoDto endereoDto, int id)
        {
            Endereco enderecoToUpdate = _context.Enderecos.FirstOrDefault(f => f.Id == id);

            if (enderecoToUpdate != null)
            {
                _mapper.Map(endereoDto, enderecoToUpdate);
                _context.SaveChanges();

                return _mapper.Map<ReadEnderecoDto>(enderecoToUpdate);
            }

            return null;
        }

        public Result DeleteCinema(int id)
        {
            Endereco enderecoToDelete = _context.Enderecos.FirstOrDefault(f => f.Id == id);
            if (enderecoToDelete != null)
            {
                _context.Remove(enderecoToDelete);
                _context.SaveChanges();

                return Result.Ok();
            }
            return Result.Fail("Cinema não encontrado!");
        }
    }
}
