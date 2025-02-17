using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FitzRepresentacoes.Services
{
    public class LoginService
    {
        private readonly LogRepository _log;
        private readonly IConfiguration _configuration;
        public LoginService(LogRepository log, IConfiguration configuration)
        {
            _log = log;
            _configuration = configuration;
        }
        public async Task<bool> ValidaSenha(UsuarioModel usuario, string password)
        {
            try
            {
                using (var hmac = new HMACSHA512(usuario.Salt))
                {
                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                    for (var i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != usuario.Hash[i])
                        {
                            _log.Error("Senha invalida",false);
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return false;
            }
        }
        public Dictionary<string, byte[]> CriptografiaSenha(string password)
        {
            Dictionary<string, byte[]> ret = new Dictionary<string, byte[]>();
            try
            {
                using (var hmac = new HMACSHA512())
                {
                    ret.Add("hash", hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
                    ret.Add("salt", hmac.Key);
                }
                return ret;

            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return ret;
            }
        }
        public async Task<bool> GerarCookie(HttpContext htpp, UsuarioModel usuario)
        {
            #region GeraToken
            try
            {

                var claims = new List<Claim>
                    {
                         new Claim(ClaimTypes.Name, usuario.Nome),
                         new Claim(ClaimTypes.Role, usuario.Email),
                     };
                var claimsIdentity =
                    new ClaimsPrincipal(
                    new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                    ));
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(30),
                    IssuedUtc = DateTime.Now
                };
                await htpp.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);
                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return false;
            }
            #endregion

        }
    }
}
