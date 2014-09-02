using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class EUsuario
    {
        public string user { get; set; }
        public string password { get; set; }
        public List<ERol> rolesUsuario { get; set; }      
        
    }
}
