using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ECalle
    {
        public int? idCalle { get; set; }
        public string nombre { get; set; }
        public ELocalidad localidad { get; set; }
    }
}
