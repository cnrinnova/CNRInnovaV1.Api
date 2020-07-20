using CNRInnovaV1.Api.Aplicacion.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResultActions;
using CNRInnovaV1.Api.Comun.Servicios;

namespace CNRInnovaV1.Api.Aplicacion
{
    public class CombosApp : ICombosApp
    {
        private readonly ICombosComm _combosComm;
        public CombosApp(ICombosComm combosComm)
        {
            _combosComm = combosComm;
        }
              

        public ReturnResult<List<dynamic>> ComboTipoIdentificacion()
        {
            try
            {
                var respCmb = _combosComm.ComboTipoIdentificacion();

                if(!respCmb.IsExito)
                    return ReturnResult<List<dynamic>>.CrearNoExitosol( respCmb.Mensajes);

                return ReturnResult<List<dynamic>>.CrearExistoso(respCmb.Respuesta);

            }
            catch (Exception ex)
            {
                return ReturnResult<List<dynamic>>.CrearError(ex.Message);
            }
            
        }

        public ReturnResult<List<dynamic>> ComboPerfiles()
        {
            try
            {
                var respCmb = _combosComm.ComboPerfiles();

                if (!respCmb.IsExito)
                    return ReturnResult<List<dynamic>>.CrearNoExitosol(respCmb.Mensajes);

                return ReturnResult<List<dynamic>>.CrearExistoso(respCmb.Respuesta);

            }
            catch (Exception ex)
            {
                return ReturnResult<List<dynamic>>.CrearError(ex.Message);
            }
        }

        public ReturnResult<List<dynamic>> ComboEstadoUsuario()
        {
            try
            {
                var respCmb = _combosComm.ComboEstadoUsuario();

                if (!respCmb.IsExito)
                    return ReturnResult<List<dynamic>>.CrearNoExitosol(respCmb.Mensajes);

                return ReturnResult<List<dynamic>>.CrearExistoso(respCmb.Respuesta);

            }
            catch (Exception ex)
            {
                return ReturnResult<List<dynamic>>.CrearError(ex.Message);
            }
        }
    }
}
