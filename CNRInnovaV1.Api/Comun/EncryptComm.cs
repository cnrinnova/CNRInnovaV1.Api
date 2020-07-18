using CNRInnovaV1.Api.Comun.Servicios;
using EncriptarRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.Comun
{
    public class EncryptComm : IEncryptComm
    {
        public string Encriptar256(string Cadena)
        {
            EncryptSHA _obj = new EncryptSHA();
            return _obj.Encry256(Cadena);
        }

        public string Encriptar512(string Cadena)
        {
            EncryptSHA _obj = new EncryptSHA();
            return _obj.Encry512(Cadena);
        }
    }
}
