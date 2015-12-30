using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccesoADatos
{
    public class LogicaBDHogar
    {
        public static void LiberarHogar(int id, DateTime fecha, ref SiGMAEntities mapa)
        {
            try
            {
                OcupacionesXHogaresProvisorios ocupacion = mapa.OcupacionesXHogaresProvisorios.Where(o => o.idMascota == id).First();
                ocupacion.fechaSalida = fecha;
            }
            catch (Exception)
            {

            }
        }
    }
}
