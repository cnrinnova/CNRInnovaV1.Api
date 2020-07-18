using CNRInnovaV1.Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.Comun.Servicios
{
    public interface ITokenJWTComm
    {
        string GenerarTokenJWT(ObjTokenDTO ress);
    }
}
