using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.Comun.Servicios
{
    public interface IToolDataComm
    {
        List<T> DataTableToList<T>(DataTable dt);

    }
}
