using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.Entidades
{
    public class Usuario
    {

        public int Id { get; set; }
        public string UsuEmail { get; set; }
        public int TipoIdentificacionId { get; set; }
        public string NumDocumento { get; set; }
        public string PriNombre { get; set; }
        public string SegNombre { get; set; }
        public string PriApellido { get; set; }
        public string SegApellido { get; set; }
        public DateTime FchNacimiento { get; set; }
        public string Celular { get; set; }
        public int PerfilId { get; set; }
        public int Estado { get; set; }
        public string Pass { get; set; }
        public int EstadoPass { get; set; }
    }
}
