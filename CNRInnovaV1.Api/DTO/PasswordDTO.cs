using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.DTO
{
    public class PasswordDTO
    {
        public int UsuarioId { get; set; }
        public string Pass { get; set; }
        public int Estado  { get; set; }
    }
}
