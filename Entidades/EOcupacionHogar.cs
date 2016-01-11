using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EOcupacionHogar
    {
        public int idOcupacion { get; set; }
        public EHogarProvisorio hogar { get; set; }
        public EMascota mascota { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaEgreso { get; set; }
        public Boolean solicitudDevolucion { get; set; }
    }
}
