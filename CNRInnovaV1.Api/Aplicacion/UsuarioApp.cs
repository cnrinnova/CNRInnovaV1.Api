using CNRInnovaV1.Api.Aplicacion.Servicios;
using CNRInnovaV1.Api.Comun.Servicios;
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
        private readonly IAuthDom _authDom;
        private readonly IEncryptComm _encryptComm;
        private readonly IToolValidateComm _toolValidateComm;


        public UsuarioApp(IUsuarioDom usuarioDom, IAuthDom authDom, IEncryptComm encryptComm, IToolValidateComm toolValidateComm)
        {
            _usuarioDom = usuarioDom;
            _authDom = authDom;
            _encryptComm = encryptComm;
            _toolValidateComm = toolValidateComm;
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
        public ReturnResult<string> CrearUsuario(UsuarioNewDTO usu)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usu.Usser))
                    return ReturnResult<string>.CrearNoExitosol(new string[] { Mensajes.InvalidUsser });

                if (!_toolValidateComm.ValidarEmail(usu.Usser))
                    return ReturnResult<string>.CrearNoExitosol(new string[] { Mensajes.InvalidEmail });

                var usuExiste = _authDom.Login(usu.Usser);
                if(!usuExiste.IsExito)
                    return ReturnResult<string>.CrearNoExitosol(usuExiste.Mensajes);

                if (usuExiste.Respuesta != null)
                    return ReturnResult<string>.CrearNoExitosol(new string[] { Mensajes.InvalidNewUsser });

                string passEncryp = _encryptComm.Encriptar512(usu.Pass);

                usu.Pass = passEncryp;

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

        public ReturnResult<List<dynamic>> MenuUsuario(int usuarioId)
        {
            try
            {
                return _usuarioDom.MenuUsuario(usuarioId);
            }
            catch (Exception ex)
            {
                return ReturnResult<List<dynamic>>.CrearError(ex.Message); 
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
