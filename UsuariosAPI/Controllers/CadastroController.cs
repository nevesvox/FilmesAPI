using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Database.Dtos;
using UsuariosAPI.Database.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario ([FromBody] CreateUsuarioDto createDto)
        {
            Result result = _cadastroService.CadastraUsuario(createDto);
            if (result.IsFailed)
            {
                return StatusCode(500);
            }
            return Ok(result.Successes);
        }

        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
        {
            Result result = _cadastroService.AtivaContaUsuario(request);
            if (result.IsSuccess)
            {
                return Ok(result.Successes);
            }

            return StatusCode(500);
        }
    }
}
