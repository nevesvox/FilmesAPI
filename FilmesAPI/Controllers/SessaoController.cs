using AutoMapper;
using FilmesAPI.Database;
using FilmesAPI.Database.Dtos.Sessao;
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
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto sessao = _sessaoService.AdicionaSessao(sessaoDto);
            return CreatedAtAction(nameof(GetSessao), new { Id = sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult GetSessao(int id)
        {
            ReadSessaoDto sessao = _sessaoService.GetSessao(id);
            if (sessao != null)
            {
                return Ok(sessao);
            }

            return NotFound();
        }
    }
}
