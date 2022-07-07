using AutoMapper;
using FilmesAPI.Database;
using FilmesAPI.Database.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    // Utiliza o nome do controller como rota
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        // Rota post
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddFilme([FromBody] EnderecoDto filmeDto)
        {
            ReadFilmeDto filme = _filmeService.AddFilme(filmeDto);
            return CreatedAtAction(nameof(GetFilme), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        public IActionResult GetFilmes([FromQuery] int? duracao = null)
        {
            List<ReadFilmeDto> filmes = _filmeService.GetFilmes(duracao);
            if (filmes != null)
            {
                return Ok(filmes);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetFilme(int id)
        {
            ReadFilmeDto filme = _filmeService.GetFilme(id);
            if (filme != null)
            {
                return Ok(filme);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilme([FromBody] UpdateFilmeDto filmeDto, int id)
        {
            ReadFilmeDto filme = _filmeService.UpdateFilme(filmeDto, id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            var res = _filmeService.DeleteFilme(id);

            if (res.IsSuccess)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
