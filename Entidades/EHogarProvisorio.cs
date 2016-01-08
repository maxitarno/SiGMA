using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EHogarProvisorio
    {
        public int idHogar { get; set; }
        public string tieneNiños { get; set; }
        public int cantMascotas { get; set; }
        public EEstado estado { get; set; }
        public EVoluntario voluntario { get; set; }
        public int AceptaEspecie { get; set; }
        public int tipoHogar { get; set; }
        public int disponibilidad { get; set; }
    }
}
