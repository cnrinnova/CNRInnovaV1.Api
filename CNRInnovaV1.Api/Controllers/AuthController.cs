using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CNRInnovaV1.Api.Comun.Servicios;
using CNRInnovaV1.Api.DTO;
using CNRInnovaV1.Api.Aplicacion.Servicios;
using ResultActions;

namespace CNRInnovaV1.Api.Controllers
{    
    [Route("CNRInnova/[controller]")]
    [ApiController]
    [EnableCors("OrigenesPermitidos")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
       
        private readonly IAuthApp _authApp;
        private readonly IUsuarioApp _usuarioApp;


        public AuthController(ITokenJWTComm comunSrv, IAuthApp authApp, IUsuarioApp usuarioApp)
        {
            _authApp = authApp;
            _usuarioApp = usuarioApp;
        }        

        /// <summary>
        /// Crea Usuario
        /// </summary>
        /// <param name="usu"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(AuthController.CrearUsuario))]
        public ReturnResult<string> CrearUsuario(UsuarioNewDTO usu)
        {
            return _usuarioApp.CrearUsuario(usu);
        }

        /// <summary>
        /// Metodo para autenticación
        /// </summary>
        [HttpPost]
        [Route(nameof(AuthController.Login))]
        [AllowAnonymous]
        public ReturnResult<AutenticaDTO> Login(LoginDTO uss)
        {
            return _authApp.Login(uss);
        }
    }
}
