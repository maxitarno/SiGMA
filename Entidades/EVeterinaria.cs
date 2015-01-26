using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EVeterinaria
    {
        public string nombre { get; set; }
        public bool peluqueria { get; set; }
        public bool petshop { get; set; }
        public bool medicina { get; set; }
        public bool castraciones { get; set; }
        public string contacto { get; set; }
        public EDomicilio domicilio { get; set; }
        public string telefono { get; set; }
    }
}
