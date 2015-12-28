using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
namespace AccesoADatos
{
    public class LogicaBDGraficos
    {
        public static void BuscarUsuarios(ref int hogar, ref int busqueda, ref int ambos, ref int no){
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
        public static void BuscarAdopciones(ref int cantM, ref int cantH)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from AdopcionesBD in mapa.Adopciones
                           join MascotasBD in mapa.Mascotas on AdopcionesBD.idMascota equals MascotasBD.idMascota into group1
                           from G1 in group1.DefaultIfEmpty()
                           select new
                           {
                               sexo = G1.sexo
                           };
            foreach (var registro in consulta)
            {
                if (registro.sexo == "Hembra")
                    cantH++;
                if (registro.sexo == "Macho")
                    cantM++;
            }
        }
    }
}
