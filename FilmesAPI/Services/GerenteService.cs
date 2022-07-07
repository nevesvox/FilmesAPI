﻿using AutoMapper;
using FilmesAPI.Database;
using FilmesAPI.Database.Dtos.Gerente;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public GerenteService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto GetGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);

            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return gerenteDto;
            }

            return null;
        }

        public Result DeleteGerente(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);
            if (gerente != null)
            {
                _context.Gerentes.Remove(gerente);
                _context.SaveChanges();
                return Result.Ok();
            }

            return Result.Fail("Gerente não encontrado!");
        }
    }
}
