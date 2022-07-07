using AutoMapper;
using FilmesAPI.Database;
using FilmesAPI.Database.Dtos;
using FilmesAPI.Database.Dtos.Endereco;
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
    // Utiliza o nome do controller como rota
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;
        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AddEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto endereco = _enderecoService.AddEndereco(enderecoDto);
            return CreatedAtAction(nameof(GetEndereco), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public List<ReadEnderecoDto> GetEnderecos()
        {
            return _enderecoService.GetEnderecos();
        }

        [HttpGet("{id}")]
        public IActionResult GetEndereco(int id)
        {
            ReadEnderecoDto endereco = _enderecoService.GetEndereco(id);
            if (endereco != null)
            {
                return Ok(endereco);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEndereco([FromBody] UpdateEnderecoDto endereoDto, int id)
        {
            ReadEnderecoDto endereco = _enderecoService.UpdateEndereco(endereoDto, id);
            if (endereco != null)
            {
                return Ok(endereco);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            var res = _enderecoService.DeleteCinema(id);
            if (res.IsSuccess)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
