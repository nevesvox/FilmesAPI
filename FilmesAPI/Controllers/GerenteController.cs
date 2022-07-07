using AutoMapper;
using FilmesAPI.Database;
using FilmesAPI.Database.Dtos.Gerente;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto gerente = _gerenteService.AdicionaGerente(gerenteDto);

            return CreatedAtAction(nameof(GetGerente), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult GetGerente(int id)
        {
            ReadGerenteDto gerente = _gerenteService.GetGerente(id);
            if (gerente != null)
            {
                return Ok(gerente);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGerente(int id)
        {
            var res = _gerenteService.DeleteGerente(id);
            if (res.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}
