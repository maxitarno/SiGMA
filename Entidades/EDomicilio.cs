using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EDomicilio
    {
        public ECalle calle { get; set; }
        public EBarrio barrio { get; set; }
        public int numeroCalle { get; set; }        
    }
}
