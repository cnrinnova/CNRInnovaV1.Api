using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNRInnovaV1.Api.Aplicacion.Servicios;
using CNRInnovaV1.Api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResultActions;

namespace CNRInnovaV1.Api.Controllers
{
    /// <summary>
    /// Controlador para manejo de Usuarios
    /// </summary>
    [Route("CNRInnova/[controller]")]
    [ApiController]
    [EnableCors("OrigenesPermitidos")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApp _usuarioApp;

        public UsuarioController(IUsuarioApp usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        /// <summary>
        /// Consulta usuario por tipo y numero de identificacion
        /// </summary>
        /// <param name="idTipoIdentificacion"></param>
        /// <param name="NumDoc"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(UsuarioController.ConsultarUsuarioByIdentificacion))]
        public ReturnResult<dynamic> ConsultarUsuarioByIdentificacion(int idTipoIdentificacion, string NumDoc)
        {
            return _usuarioApp.ConsultarUsuarioByIdentificacion(idTipoIdentificacion, NumDoc);
        }

        /// <summary>
        /// Crea Usuario
        /// </summary>
        /// <param name="usu"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(UsuarioController.CrearUsuario))]
        public ReturnResult<string> CrearUsuario(UsuarioDTO usu)
        {
            return _usuarioApp.CrearUsuario(usu);
        }

        /// <summary>
        /// Modificar Usuario
        /// </summary>
        /// <param name="usu"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(UsuarioController.ModificarUsuario))]
        public ReturnResult<string> ModificarUsuario(UsuarioDTO usu)
        {
            return _usuarioApp.ModificarUsuario(usu);
        }

        /// <summary>
        /// Crear Password
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(UsuarioController.CrearPassword))]
        public ReturnResult<string> CrearPassword(PasswordDTO pass)
        {
            return _usuarioApp.CrearPassword(pass);
        }

        /// <summary>
        /// Modificar Password
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(UsuarioController.ModificarPassword))]
        public ReturnResult<string> ModificarPassword(PasswordDTO pass)
        {
            return _usuarioApp.ModificarPassword(pass);
        }

    }
}
