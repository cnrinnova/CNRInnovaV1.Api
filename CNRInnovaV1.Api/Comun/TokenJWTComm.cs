using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CNRInnovaV1.Api.Comun.Servicios;
using CNRInnovaV1.Api.DTO;

namespace CNRInnovaV1.Api.Comun
{
    public class TokenJWTComm : ITokenJWTComm
    {
        private readonly IConfiguration _configuration;

        public TokenJWTComm(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerarTokenJWT(ObjTokenDTO ress)
        {

            string token = GenerateTokenJWT(ress);
            return token;
        }

        private string GenerateTokenJWT(ObjTokenDTO ress)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, ress.Id.ToString()),
                new Claim("PrimerNombre", ress.PriNombre),
                new Claim("SegundoNombre", ress.SegNombre),
                new Claim("PrimerApellido", ress.PriApellido),
                new Claim("SegundoApellido", ress.SegApellido)

                //new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
                //new Claim(ClaimTypes.Role, usuarioInfo.PerfilDesc)

            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddDays(1)
                );


            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(_Header, _Payload);

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
