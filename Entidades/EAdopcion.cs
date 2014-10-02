using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EAdopcion
    {
        public int idAdopcion { get; set; }
        public EMascota mascota { get; set; }
        public EDuenio duenio { get; set; }
        public int idVoluntario { get; set; }
        public DateTime fecha { get; set; }
        public string observaciones { get; set; }
        public EEstado estado { get; set; }
    }
}
