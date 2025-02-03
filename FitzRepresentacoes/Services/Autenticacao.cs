using FitzRepresentacoes.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitzRepresentacoes.Services
{
    public class Autenticacao
    {
        private readonly IConfiguration _configuration;
        public Autenticacao(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       // private async Task<UsuarioDTO> ResgataUsuario(UsuarioDTO usuario)
       // {
       //     string query = $"select idUsuario,Usuario_nme,Usuario_senha from Usuarios where Usuario_email = '{usuario.Email}'";
       //     UsuarioDTO retornoUsuario = new UsuarioDTO() ;
       //     try
       //     {
       //         //MySqlConnection conn = new MySqlConnection();
       //         //using (conn = _db.OpenConnection(conn))
       //         //{
       //         //    using (MySqlCommand cmd = new MySqlCommand(query, conn))
       //         //    {
       //         //        var result = await cmd.ExecuteReaderAsync();
                        
       //         //        while (result.Read())
       //         //        {
       //         //            retornoUsuario.idUsuario = Convert.ToInt32(result["idUsuario"]);
       //         //            retornoUsuario.senha = result["Usuario_senha"].ToString();
       //         //            retornoUsuario.login = result["Usuario_nme"].ToString();
       //         //        }
       //         //    }
                    
       //         //}

       //     }
       //     catch (Exception ex) { }
       //     return retornoUsuario;
       // }

    }
}
