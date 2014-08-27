using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EMascota
    {
        public int idMascota { get; set; }
        public string nombreMascota { get; set; }
        public int idEstado { get; set; }
        public int idEspecie { get; set; }
        public int idEdad { get; set; }
        public int idRaza { get; set; }
        public int idColor { get; set; }
        public string tratoAnimal { get; set; }
        public string tratoNiños { get; set; }
        public ECaracterMascota caracter { get; set; }
        public string observaciones { get; set; }
        public string alimetaionEspeial { get; set; }
        public DateTime fechaNcimiento { get; set; }
        public string sexo { get; set; }
        public int idDuenio { get; set; }
        public int idcaracter { get; set; }
    }
}
