using CNRInnovaV1.Api.DTO;
using ResultActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.Aplicacion.Servicios
{
    public interface IAuthApp 
    {
        ReturnResult<AutenticaDTO> Login(LoginDTO uss);
    }
}
