using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
namespace AccesoADatos
{
    public class LogicaBDGraficos
    {
        public static void BuscarUsuarios(ref int hogar, ref int busqueda, ref int ambos){
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
        public static void HallazgosPorBarrio(ref List<EDatos> datos)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from HallazgosBD in mapa.Hallazgos
                           join BarriosBD in mapa.Barrios on HallazgosBD.idBarrioHallazgo equals BarriosBD.idBarrio
                           group BarriosBD by new { BarriosBD.nombre } into a
                           select new
                           {
                               nombre = a.Key.nombre,
                               cant = a.Count()
                           };
            foreach (var registro in consulta)
            {
                EDatos dato = new EDatos();
                dato.cantidad = registro.cant;
                dato.nombre = registro.nombre;
                datos.Add(dato);
            }
        }
        public static void AdopcionesPorBarrio(ref List<EDatos> datos)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from AdopcionesBD in mapa.Adopciones
                           join DuenioBD in mapa.Duenios on AdopcionesBD.idDuenio equals DuenioBD.idDuenio into group1
                           from G1 in group1.DefaultIfEmpty()
                           join PersonaBD in mapa.Personas on G1.idPersona equals PersonaBD.idPersona into group2
                           from G2 in group2.DefaultIfEmpty()
                           join BarriosBD in mapa.Barrios on G2.idBarrio equals BarriosBD.idBarrio into group3
                           from G3 in group3.DefaultIfEmpty()
                           group G3 by new { G3.nombre } into a
                           select new
                           {
                               nombre = a.Key.nombre,
                               cant = a.Count()
                           };
            foreach (var registro in consulta)
            {
                EDatos dato = new EDatos();
                dato.cantidad = registro.cant;
                dato.nombre = registro.nombre;
                datos.Add(dato);
            }
        }
        public static void PerdidasPorBarrio(ref List<EDatos> datos)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from PerdidasBD in mapa.Perdidas
                           join BarriosBD in mapa.Barrios on PerdidasBD.idBarrioPerdida equals BarriosBD.idBarrio
                           group BarriosBD by new { BarriosBD.nombre } into a
                           select new
                           {
                               nombre = a.Key.nombre,
                               cant = a.Count()
                           };
            foreach (var registro in consulta)
            {
                EDatos dato = new EDatos();
                dato.cantidad = registro.cant;
                dato.nombre = registro.nombre;
                datos.Add(dato);
            }
        }
    }
}
