using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Database.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            Result res = _loginService.LogaUsuario(request);
            if (res.IsFailed)
            {
                return Unauthorized(res.Errors);
            }

            return Ok(res.Successes);
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaResetSenha(SolicitaResetSenha request)
        {
            Result res = _loginService.SolicitaResetSenha(request);
            if (res.IsFailed)
            {
                return Unauthorized(res.Errors);
            }

            return Ok(res.Successes);
        }

        [HttpPost("/efetua-reset")]
        public IActionResult ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            Result res = _loginService.ResetaSenhaUsuario(request);
            if (res.IsFailed)
            {
                return Unauthorized(res.Errors);
            }

            return Ok(res.Successes);
        }
    }
}
