using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.DTO
{
    /// <summary>
    /// Dto para recibir el login y password para autenticar
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// Corresponde al usuario. Debe ser un email válido 
        /// </summary>
        public string Usser { get; set; }
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Pass { get; set; }        
    }

    public class UsuarioNewDTO
    {
        /// <summary>
        /// Corresponde al usuario. Debe ser un email válido 
        /// </summary>
        public string Usser { get; set; }
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Pass { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string PriNombre { get; set; }
        /// <summary>
        /// Apellido
        /// </summary>
        public string PriApellido { get; set; }
    }


}
