using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository;
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
                            _log.Error("Senha invalida");
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
        public string GerarToken(UsuarioModel usuario)
        {
            #region GeraToken
            var claims = new[]
                    {
                         new Claim("id",usuario.id.ToString()),
                         new Claim("user", usuario.Email.ToString()),
                         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                     };
            var privateKy = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretkey"]));

            var crendentials = new SigningCredentials(privateKy, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: crendentials);
            #endregion
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
