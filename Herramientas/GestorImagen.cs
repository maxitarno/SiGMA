using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Herramientas
{
    public class GestorImagen
    {
        public static bool verificarTamaño(int tamaño)
        {
            if (tamaño > 1024000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static byte[] obtenerArrayBytes(Stream flujoBytes, int tamaño)
        {
            byte[] imagen = null;
            using (var binaryReader = new BinaryReader(flujoBytes))
            {
                imagen = binaryReader.ReadBytes(tamaño);
            }
            return imagen;
        }
    }
}
