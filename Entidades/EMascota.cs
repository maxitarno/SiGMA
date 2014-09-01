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
        public EEstado estado { get; set; }
        public EEspecie especie { get; set; }
        public EEdad edad { get; set; }
        public ERaza raza { get; set; }
        public EColor color { get; set; }
        public string tratoAnimal { get; set; }
        public string tratoNiños { get; set; }
        public ECaracterMascota caracter { get; set; }
        public string observaciones { get; set; }
        public string alimentacionEspecial { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public EDuenio duenio { get; set; }
        public byte[] imagen { get; set; }
    }
}
