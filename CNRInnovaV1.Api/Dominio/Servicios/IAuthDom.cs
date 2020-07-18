using CNRInnovaV1.Api.DTO;
using CNRInnovaV1.Api.Entidades;
using ResultActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.Dominio.Servicios
{
    public interface IAuthDom
    {
        ReturnResult<Usuario> Login(string usu);
    }
}
