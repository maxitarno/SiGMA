using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EPerdida
    {
        public EUsuario usuario { get; set; }
        public EBarrio barrio { get; set; }
        public EMascota mascota { get; set; }
        public int idPerdida { get; set; }
        public DateTime fecha { get; set; }
        public string comentarios { get; set; }
        public string ubicacion { get; set; }
        public string mapaPerdida { get; set; }
        public EEstado estado { get; set; }
    }
}
