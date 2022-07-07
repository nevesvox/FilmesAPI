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
    public class CinemaService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto AddCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> GetCinemas(string nomeFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(nomeFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(s => s.Filme.Titulo == nomeFilme)
                                            select cinema;

                cinemas = query.ToList();
            }

            List<ReadCinemaDto> cinemasDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);

            return cinemasDto;
        }

        public ReadCinemaDto GetCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(f => f.Id == id);

            if (cinema != null)
            {
                ReadCinemaDto cinemaReturn = _mapper.Map<ReadCinemaDto>(cinema);
                cinemaReturn.DataHoraConsulta = DateTime.Now;
                return cinemaReturn;
            }

            return null;
        }

        public ReadCinemaDto UpdateCinema(UpdateCinemaDto cinameDto, int id)
        {
            Cinema cinemaToUpdate = _context.Cinemas.FirstOrDefault(f => f.Id == id);

            if (cinemaToUpdate != null)
            {
                _mapper.Map(cinameDto, cinemaToUpdate);
                _context.SaveChanges();

                return _mapper.Map<ReadCinemaDto>(cinemaToUpdate);
            }

            return null;
        }

        public Result DeleteCinema(int id)
        {
            Cinema cinemaToDelete = _context.Cinemas.FirstOrDefault(f => f.Id == id);
            if (cinemaToDelete != null)
            {
                _context.Remove(cinemaToDelete);
                _context.SaveChanges();

                return Result.Ok();
            }
            return Result.Fail("Cinema não encontrado");
        }
    }
}
