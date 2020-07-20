using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNRInnovaV1.Api.DTO;
using ResultActions;

namespace CNRInnovaV1.Api.Aplicacion.Servicios
{
    public interface IUsuarioApp
    {
        /// <summary>
        /// Consulta usuario por tipo y numero de identificacion
        /// </summary>
        /// <param name="idTipoIdentificacion"></param>
        /// <param name="NumDoc"></param>
        /// <returns></returns>
        ReturnResult<dynamic> ConsultarUsuarioByIdentificacion(int idTipoIdentificacion, string NumDoc);

        /// <summary>
        /// Crea Usuario
        /// </summary>
        /// <param name="usu"></param>
        /// <returns></returns>
        ReturnResult<string> CrearUsuario(UsuarioDTO usu);

        /// <summary>
        /// Modificar Usuario
        /// </summary>
        /// <param name="usu"></param>
        ReturnResult<string> ModificarUsuario(UsuarioDTO usu);

        // <summary>
        /// Crear Password
        /// </summary>
        /// <param name="pass"></param>
        ReturnResult<string> CrearPassword(PasswordDTO pass);

        /// <summary>
        /// Modificar Password
        /// </summary>
        /// <param name="pass"></param>
        ReturnResult<string> ModificarPassword(PasswordDTO pass);
    }
}
