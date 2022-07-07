using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosAPI.Database.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        private SignInManager<CustomIdentityUser> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(
                request.Username,
                request.Password,
                false,
                false
            );

            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users.FirstOrDefault(
                    u => u.NormalizedUserName == request.Username.ToUpper()
                );

                Token token = _tokenService.CreateToken(
                    identityUser,
                    _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault()
                );
                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Falha ao realizar o Login!");
        }

        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);
            IdentityResult resultado = _signInManager.UserManager
                .ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

            if (resultado.Succeeded)
            {
                return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
            }

            return Result.Fail("Erro ao redefinir senha!");
        }

        public Result SolicitaResetSenha(SolicitaResetSenha request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);
            if (identityUser != null)
            {
                string tokenRec = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(tokenRec);
            }

            return Result.Fail("Falha ao gerar token de redefinição!");
        }

        private CustomIdentityUser RecuperaUsuarioPorEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}