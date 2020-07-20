using ResultActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.Aplicacion.Servicios
{
    public interface ICombosApp
    {
        ReturnResult<List<dynamic>> ComboTipoIdentificacion();

        ReturnResult<List<dynamic>> ComboPerfiles();
        ReturnResult<List<dynamic>> ComboEstadoUsuario();
    }
}


