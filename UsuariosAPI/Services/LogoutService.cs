using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> _signinManager;

        public LogoutService(SignInManager<CustomIdentityUser> signinManager)
        {
            _signinManager = signinManager;
        }

        public Result DeslogaUsuario()
        {
            var resultIdentity = _signinManager.SignOutAsync();
            if(resultIdentity.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }

            return Result.Fail("Erro ao realizar logout");
        }
    }
}
