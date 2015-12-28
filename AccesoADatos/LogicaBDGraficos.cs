using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
namespace AccesoADatos
{
    public class LogicaBDGraficos
    {
        public static void BuscarUsuarios(int hogar, int busqueda, int ambos, int no){
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from voluntariosBD in mapa.Voluntarios
                           select voluntariosBD;
            foreach (var registro in consulta)
            {
                if (registro.tipoVoluntario == "Hogar")
                    hogar++;
                if (registro.tipoVoluntario == "Busqueda")
                    busqueda++;
                if (registro.tipoVoluntario == "Ambos")
                    ambos++;
                if (registro.tipoVoluntario == null)
                    no++;
            }
        }
    }
}
