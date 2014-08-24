using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herramientas
{
    public class Validaciones
    {
        public static bool verificarSoloNumeros(string texto)
        {
            if (!texto.Equals(""))
            {
                foreach (char c in texto)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool verificarDecimal(string texto)
        {
            foreach (char c in texto)
            {
                if (!(char.IsDigit(c) || (c == ',')))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool Fecha(string fecha, out DateTime fechaRetorno)
        {
            if (DateTime.TryParse(fecha, out fechaRetorno))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
