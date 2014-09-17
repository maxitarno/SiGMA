using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ERaza
    {
        public int idRaza { get; set; }
        public EEspecie especie { get; set; }
        public string nombreRaza { get; set; }
        public ECategoriaRaza CategoriaRaza { get; set; }
        public ECuidado cuidadoEspecial { get; set; }
        public string pesoRaza { get; set; }
    }
}
