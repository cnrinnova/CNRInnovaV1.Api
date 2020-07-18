using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.Comun.Servicios
{
    public interface IEncryptComm
    {
        /// <summary>
        /// encriptar Sha256
        /// </summary>
        /// <param name="Cadena"></param>
        /// <returns></returns>
        public string Encriptar256(string Cadena);

        /// <summary>
        /// encriptar Sha512
        /// </summary>
        /// <param name="Cadena"></param>
        /// <returns></returns>
        public string Encriptar512(string Cadena);
    }
}
