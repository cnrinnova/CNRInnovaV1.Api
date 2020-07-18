using CNRInnovaV1.Api.Comun.Servicios;
using CNRInnovaV1.Api.Dominio.Servicios;
using CNRInnovaV1.Api.DTO;
using CNRInnovaV1.Api.Properties;

using ResultActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.Aplicacion.Servicios
{
    public class AuthApp : IAuthApp
    {
        private readonly IAuthDom _authDom;
        private readonly IEncryptComm _encryptComm;
        private readonly ITokenJWTComm _tokenJWTComm;

        public AuthApp(IAuthDom authDom, IEncryptComm encryptComm, ITokenJWTComm tokenJWTComm)
        {
            _authDom = authDom;
            _encryptComm = encryptComm;
            _tokenJWTComm = tokenJWTComm;
        }

        public ReturnResult<AutenticaDTO>Login(LoginDTO uss)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(uss.Usser))
                    return ReturnResult<AutenticaDTO>.CrearNoExitosol(new string[] { Mensajes.InvalidUsser });

                if (string.IsNullOrWhiteSpace(uss.Pass))
                    return ReturnResult<AutenticaDTO>.CrearNoExitosol(new string[] { Mensajes.InvalidPass });


                var pass = _encryptComm.Encriptar512(uss.Pass);
                var usser = _authDom.Login(uss.Usser);
                if(!usser.IsExito)
                    return ReturnResult<AutenticaDTO>.CrearNoExitosol(new string[] { "" });

                var respUsser = usser.Respuesta;


                if (pass != respUsser.Pass)
                    return ReturnResult<AutenticaDTO>.CrearNoExitosol(new string[] { Mensajes.InvalidPassword });

                if (respUsser.EstadoPass != 1)
                    return ReturnResult<AutenticaDTO>.CrearNoExitosol(new string[] { Mensajes.DisabledPassword });

                var token = _tokenJWTComm.GenerarTokenJWT(new ObjTokenDTO
                {
                    Id = respUsser.Id,
                    PriNombre = respUsser.PriNombre,
                    SegNombre = respUsser.SegNombre,
                    PriApellido = respUsser.PriApellido,
                    SegApellido = respUsser.SegApellido
                });


                AutenticaDTO loginResp = new AutenticaDTO {IdUsuario= respUsser.Id, Token= token};                
                return ReturnResult<AutenticaDTO>.CrearExistoso(loginResp);
            }
            catch (Exception ex)
            {
                return ReturnResult<AutenticaDTO>.CrearError(ex.Message);
            }
            
        }
    }
}
