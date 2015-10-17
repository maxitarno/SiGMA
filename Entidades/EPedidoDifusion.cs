using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EPedidoDifusion
    {
        public int idPedidoDifusion { get; set; }
        public EEstado estado { get; set; }
        public string motivoRechazo { get; set; }
        public ECampaña campaña { get; set; }
        public EHallazgo hallazgo { get; set; }
        public EPerdida perdida { get; set; }
        public EMascota mascota { get; set; }
        public DateTime fecha { get; set; }
        public EUsuario user { get; set; }
    }
}
