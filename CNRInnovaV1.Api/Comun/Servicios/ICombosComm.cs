using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResultActions;

namespace CNRInnovaV1.Api.Comun.Servicios
{
    public interface ICombosComm
    {
        ReturnResult<List<dynamic>> ComboTipoIdentificacion();

        ReturnResult<List<dynamic>> ComboPerfiles();

        ReturnResult<List<dynamic>> ComboEstadoUsuario();
    }
}
