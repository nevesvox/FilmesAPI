using AutoMapper;
using FilmesAPI.Database;
using FilmesAPI.Database.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AddFilme(EnderecoDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> GetFilmes(int? duracao)
        {
            List<Filme> filmes;
            if (duracao == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(f => f.Duracao <= duracao).ToList();
            }
            if (filmes != null)
            {
                List<ReadFilmeDto> filmesDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return filmesDto;
            }

            return null;
        }

        public ReadFilmeDto GetFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme != null)
            {
                ReadFilmeDto filmeReturn = _mapper.Map<ReadFilmeDto>(filme);
                filmeReturn.HoraConsulta = DateTime.Now;
                return filmeReturn;
            }

            return null;
        }

        public ReadFilmeDto UpdateFilme(UpdateFilmeDto filmeDto, int id)
        {
            Filme filmeToUpdate = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filmeToUpdate != null)
            {
                _mapper.Map(filmeDto, filmeToUpdate);
                _context.SaveChanges();

                return _mapper.Map<ReadFilmeDto>(filmeToUpdate);
            }

            return null;
        }

        public Result DeleteFilme(int id)
        {
            Filme filmeToDelete = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filmeToDelete != null)
            {
                _context.Remove(filmeToDelete);
                _context.SaveChanges();
                return Result.Ok();
            }

            return Result.Fail("Filme não encontrado");
        }
    }
}
