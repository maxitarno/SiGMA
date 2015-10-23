using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace AccesoADatos
{
    public class LogicaBDEstado
    {
        public static EEstado buscarEstadoPorNombre(string estado)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.Estados.Single(e => e.nombreEstado == estado);
            return new EEstado { idEstado = consulta.idEstado, nombreEstado = consulta.nombreEstado, ambito = consulta.ambito};            
        }
    }
}
