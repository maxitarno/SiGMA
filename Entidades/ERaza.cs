using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ERaza
    {
        public int idRaza { get; set; }
        public int idEspecie { get; set; }
        public string nombreRaza { get; set; }
        public int idCategoriaRaza { get; set; }
        public int idcuidadoEspecial { get; set; }
        public string pesoRaza { get; set; }
    }
}
