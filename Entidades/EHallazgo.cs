using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EHallazgo
    {
        public EMascota mascota { get; set; }
        public EDomicilio domicilio { get; set; }
        public string observaciones { get; set; }
        public EPerdida perdida { get; set; }
        public EUsuario usuario { get; set; }
        public DateTime fechaHallazgo { get; set; }
    }
}
