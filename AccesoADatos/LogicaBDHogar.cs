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
                var ocupacion = mapa.OcupacionesXHogaresProvisorios.Where
                    (o => o.idMascota == id && o.fechaSalida == null);
                if (ocupacion.Count() != 0)
                {
                    ocupacion.First().fechaSalida = fecha;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
