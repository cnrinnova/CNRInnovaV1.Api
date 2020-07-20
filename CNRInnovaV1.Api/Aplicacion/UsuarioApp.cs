using CNRInnovaV1.Api.Aplicacion.Servicios;
using CNRInnovaV1.Api.Dominio.Servicios;
using CNRInnovaV1.Api.DTO;
using CNRInnovaV1.Api.Properties;
using ResultActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.Aplicacion
{
    public class UsuarioApp: IUsuarioApp
    {
        private readonly IUsuarioDom _usuarioDom;
        public UsuarioApp(IUsuarioDom usuarioDom)
        {
            _usuarioDom = usuarioDom;
        }

        /// <summary>
        /// Consulta usuario por tipo y numero de identificacion
        /// </summary>
        /// <param name="idTipoIdentificacion"></param>
        /// <param name="NumDoc"></param>
        /// <returns></returns>
        public ReturnResult<dynamic> ConsultarUsuarioByIdentificacion(int idTipoIdentificacion, string NumDoc)
        {
            try
            {
                var respUsu = _usuarioDom.ConsultarUsuarioByIdentificacion(idTipoIdentificacion, NumDoc);
                if (!respUsu.IsExito)
                    return ReturnResult<dynamic>.CrearNoExitosol(respUsu.Mensajes);

                return ReturnResult<dynamic>.CrearExistoso(respUsu.Respuesta);
            }
            catch (Exception ex)
            {

                return ReturnResult<dynamic>.CrearError(ex.Message); 
            }
        }

        /// <summary>
        /// Crea Usuario
        /// </summary>
        /// <param name="usu"></param>
        public ReturnResult<string> CrearUsuario(UsuarioDTO usu)
        {
            try
            {
                var respUsu = _usuarioDom.CrearUsuario(usu);
                if (!respUsu.IsExito)
                    return ReturnResult<string>.CrearNoExitosol(respUsu.Mensajes);

                return ReturnResult<string>.CrearExistoso(Mensajes.ProcessCompleted);
            }
            catch (Exception ex)
            {

                return ReturnResult<string>.CrearError(ex.Message); 
            }
        }

        /// <summary>
        /// Modificar Usuario
        /// </summary>
        /// <param name="usu"></param>
        public ReturnResult<string> ModificarUsuario(UsuarioDTO usu)
        {
            try
            {
                var respUsu = _usuarioDom.ModificarUsuario(usu);
                if (!respUsu.IsExito)
                    return ReturnResult<string>.CrearNoExitosol(respUsu.Mensajes);

                return ReturnResult<string>.CrearExistoso(Mensajes.ProcessCompleted);
            }
            catch (Exception ex)
            {
                return ReturnResult<string>.CrearError(ex.Message);
            }
        }

        // <summary>
        /// Crear Password
        /// </summary>
        /// <param name="pass"></param>
        public ReturnResult<string> CrearPassword(PasswordDTO pass)
        {
            try
            {
                var respUsu = _usuarioDom.CrearPassword(pass);
                if (!respUsu.IsExito)
                    return ReturnResult<string>.CrearNoExitosol(respUsu.Mensajes);

                return ReturnResult<string>.CrearExistoso(Mensajes.ProcessCompleted);
            }
            catch (Exception ex)
            {
                return ReturnResult<string>.CrearError(ex.Message);
            }
        }

        /// <summary>
        /// Modificar Password
        /// </summary>
        /// <param name="pass"></param>
        public ReturnResult<string> ModificarPassword(PasswordDTO pass)
        {
            try
            {
                var respUsu = _usuarioDom.ModificarPassword(pass);
                if (!respUsu.IsExito)
                    return ReturnResult<string>.CrearNoExitosol(respUsu.Mensajes);

                return ReturnResult<string>.CrearExistoso(Mensajes.ProcessCompleted);
            }
            catch (Exception ex)
            {
                return ReturnResult<string>.CrearError(ex.Message);
            }
        }

    }
}
