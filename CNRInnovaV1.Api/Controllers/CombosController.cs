using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNRInnovaV1.Api.Aplicacion.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResultActions;

namespace CNRInnovaV1.Api.Controllers
{
    /// <summary>
    /// Controlador para cargar combos
    /// </summary>
    [Route("CNRInnova/[controller]")]
    [ApiController]
    [EnableCors("OrigenesPermitidos")]
    [Authorize]
    public class CombosController : ControllerBase
    {
        private readonly ICombosApp _CombosApp;

        public CombosController(ICombosApp CombosApp)
        {
            _CombosApp = CombosApp;
        }
        /*
        /// <summary>
        /// Carga Maestro de Tipos de Identificacion
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(CombosController.ComboTipoIdentificacion))]
        public ReturnResult<List<dynamic>> ComboTipoIdentificacion()
        {
            return _CombosApp.ComboTipoIdentificacion();
        }

        /// <summary>
        /// Carga Maestro de Perfiles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(CombosController.ComboPerfiles))]
        public ReturnResult<List<dynamic>> ComboPerfiles()
        {
            return _CombosApp.ComboPerfiles();
        }

        /// <summary>
        /// Carga Maestro Estado de usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(CombosController.ComboEstadoUsuario))]
        public ReturnResult<List<dynamic>> ComboEstadoUsuario()
        {
            return _CombosApp.ComboEstadoUsuario();
        }

        */
    }
}
