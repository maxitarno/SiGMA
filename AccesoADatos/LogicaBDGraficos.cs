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
            }
        }
        public static void BuscarAdopciones(ref int cantM, ref int cantH)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from MascotasBD in mapa.Mascotas
                           where (MascotasBD.idEstado == 5)
                           select new
                           {
                               sexo = MascotasBD.sexo
                           };
            foreach (var registro in consulta)
            {
                if (registro.sexo == "Hembra")
                    cantH++;
                if (registro.sexo == "Macho")
                    cantM++;
            }
        }
        public static void BuscarPerdidas(ref int cantM, ref int cantH)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from MascotasBD in mapa.Mascotas
                           where (MascotasBD.idEstado == 3)
                           select new
                           {
                               sexo = MascotasBD.sexo
                           };
            foreach (var registro in consulta)
            {
                if (registro.sexo == "Hembra")
                    cantH++;
                if (registro.sexo == "Macho")
                    cantM++;
            }
        }
        public static void BuscarHallazgos(ref int cantM, ref int cantH)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from  MascotasBD in mapa.Mascotas
                           where ( MascotasBD.idEstado == 2)
                           select new
                           {
                               sexo = MascotasBD.sexo
                           };
            foreach (var registro in consulta)
            {
                if (registro.sexo == "Hembra")
                    cantH++;
                if (registro.sexo == "Macho")
                    cantM++;
            }
        }
        public static void BuscarMascotas(ref int cachorro, ref int adulto, ref int senior, ref int cantH, ref int cantM)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from MascotasBD in mapa.Mascotas
                           select MascotasBD;
            foreach (var registro in consulta)
            {
                if (registro.idEdad == 1)
                    cachorro++;
                if (registro.idEdad == 2)
                    adulto++;
                if (registro.sexo == "Macho")
                    cantM++;
                if (registro.sexo == "Hembra")
                    cantH++;
                if (registro.idEdad == 3)
                    senior++;
            }
        }
    }
}
