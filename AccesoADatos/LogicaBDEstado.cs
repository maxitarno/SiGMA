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

        public static EEstado buscarEstado(EEstado estado)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.Estados.Single(e => e.nombreEstado == estado.nombreEstado && e.ambito == estado.ambito);
            return new EEstado { idEstado = consulta.idEstado, nombreEstado = consulta.nombreEstado, ambito = consulta.ambito };
        }
    }
}
