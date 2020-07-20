using CNRInnovaV1.Api.DTO;
using ResultActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.Dominio.Servicios
{
    public interface IUsuarioDom
    {
        ReturnResult<dynamic> ConsultarUsuarioByIdentificacion(int idTipoIdentificacion, string NumDoc);
        ReturnResult<bool> CrearUsuario(UsuarioDTO usu);
        ReturnResult<bool> ModificarUsuario(UsuarioDTO usu);
        ReturnResult<bool> CrearPassword(PasswordDTO pass);
        ReturnResult<bool> ModificarPassword(PasswordDTO pass);

    }
}
