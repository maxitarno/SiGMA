using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EPersona
    {
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int idTipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public string email { get; set; }
        public string domicilio { get; set; }
        public int idBarrio { get; set; }
        public string telefonoFijo { get; set; }
        public string telefonoCelular { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public EUsuario usuario { get; set; }
    }
}
