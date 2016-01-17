using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EVoluntario
    {
        public EPersona persona { get; set; }
        public int idVoluntario { get; set; }
        public int? idEstado { get; set; }
        public string tipoVoluntario { get; set; }
        public string disponibilidadHoraria { get; set; }
        public EEstado estado { get; set; }
    }
}
