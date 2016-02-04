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
        public static void HallazgosPorFecha(ref List<EDatos> datos)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from HallazgosBD in mapa.Hallazgos
                           group HallazgosBD by new { HallazgosBD.fechaHoraHallazgo.Year } into a
                           select new
                           {
                               fecha = a.Key.Year,
                               cant = a.Count()
                           };
            foreach (var registro in consulta)
            {
                EDatos dato = new EDatos();
                dato.cantidad = registro.cant;
                dato.año = registro.fecha;
                datos.Add(dato);
            }
        }
        public static void AdopcionesPorFecha(ref List<EDatos> datos)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from AdopcionesBD in mapa.Adopciones
                           group AdopcionesBD by new { AdopcionesBD.fechaAdopcion.Year } into a
                           select new
                           {
                               fecha = a.Key.Year,
                               cant = a.Count()
                           };
            foreach (var registro in consulta)
            {
                EDatos dato = new EDatos();
                dato.cantidad = registro.cant;
                dato.año = registro.fecha;
                datos.Add(dato);
            }
        }
        public static void PerdidasPorFecha(ref List<EDatos> datos)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from PerdidasBD in mapa.Perdidas
                           group PerdidasBD by new { PerdidasBD.FechaHoraPerdida.Value.Year } into a
                           select new
                           {
                               fecha = a.Key.Year,
                               cant = a.Count()
                           };
            foreach (var registro in consulta)
            {
                EDatos dato = new EDatos();
                dato.cantidad = registro.cant;
                dato.año = int.Parse(registro.fecha.ToString());
                datos.Add(dato);
            }
        }
        public static void BuscarMascotasPorEspecie(ref int cantidadPerros, ref int cantidadGatos)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from MascotasBD in mapa.Mascotas
                           select MascotasBD;
            foreach (var registro in consulta)
            {
                if (registro.idEspecie == 1)
                    cantidadPerros++;
                if (registro.idEspecie == 2)
                    cantidadGatos++;
            }
        }
        public static void PerdidasPorEspecie(ref int cantidadGatos, ref int cantidadPerros)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from PerdidasBD in mapa.Perdidas
                           join MascotasBD in mapa.Mascotas on PerdidasBD.idMascota equals MascotasBD.idMascota
                           select MascotasBD;
            foreach (var registro in consulta)
            {
                if (registro.idEspecie == 1)
                {
                    cantidadPerros++;
                }
                else
                {
                    cantidadGatos++;
                }
            }
        }
        public static void AdopcionesPorEspecie(ref int cantidadGatos, ref int cantidadPerros)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from AdopcionesBD in mapa.Adopciones
                           join MascotasBD in mapa.Mascotas on AdopcionesBD.idMascota equals MascotasBD.idMascota
                           select MascotasBD;
            foreach (var registro in consulta)
            {
                if (registro.idEspecie == 1)
                {
                    cantidadPerros++;
                }
                else
                {
                    cantidadGatos++;
                }
            }
        }
        public static void HallazgosPorEspecie(ref int cantidadGatos, ref int cantidadPerros)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = from HallazgosBD in mapa.Hallazgos
                           join MascotasBD in mapa.Mascotas on HallazgosBD.idMascota equals MascotasBD.idMascota
                           select MascotasBD;
            foreach (var registro in consulta)
            {
                if (registro.idEspecie == 1)
                {
                    cantidadPerros++;
                }
                else
                {
                    cantidadGatos++;
                }
            }
        }
        public static void AdopcionesPorRaza(ref List<EDatos> datos)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var grupos = (from AdopcionesBD in mapa.Adopciones
                           join MascotasBD in mapa.Mascotas on AdopcionesBD.idMascota equals MascotasBD.idMascota into group1
                           from G1 in group1.DefaultIfEmpty()
                           join RazasBD in mapa.Razas on G1.idRaza equals RazasBD.idRaza into group2
                           from G2 in group2.DefaultIfEmpty()
                           select new { nombreRaza = G2.nombreRaza, id = AdopcionesBD.idAdopcion}).ToList();
            var consulta = grupos.GroupBy(raza => raza.nombreRaza).Select(grp => new { nombreRaza = grp.Key.ToString(), cantidad = grp.Count() }).ToList();
            foreach (var registro in consulta)
            {
                EDatos dato = new EDatos();
                dato.nombre = registro.nombreRaza;
                dato.cantidad = registro.cantidad;
                datos.Add(dato);
            }
        }
        public static void HallazgosPorRaza(ref List<EDatos> datos)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var grupos = (from HallazgosBD in mapa.Hallazgos
                          join MascotasBD in mapa.Mascotas on HallazgosBD.idMascota equals MascotasBD.idMascota into group1
                          from G1 in group1.DefaultIfEmpty()
                          join RazasBD in mapa.Razas on G1.idRaza equals RazasBD.idRaza into group2
                          from G2 in group2.DefaultIfEmpty()
                          select new { nombreRaza = G2.nombreRaza, id = HallazgosBD.idHallazgo }).ToList();
            var consulta = grupos.GroupBy(raza => raza.nombreRaza).Select(grp => new { nombreRaza = grp.Key.ToString(), cantidad = grp.Count() }).ToList();
            foreach (var registro in consulta)
            {
                EDatos dato = new EDatos();
                dato.nombre = registro.nombreRaza;
                dato.cantidad = registro.cantidad;
                datos.Add(dato);
            }
        }
        public static void PerdidasPorRaza(ref List<EDatos> datos)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var grupos = (from PerdidasBD in mapa.Perdidas
                          join MascotasBD in mapa.Mascotas on PerdidasBD.idMascota equals MascotasBD.idMascota into group1
                          from G1 in group1.DefaultIfEmpty()
                          join RazasBD in mapa.Razas on G1.idRaza equals RazasBD.idRaza into group2
                          from G2 in group2.DefaultIfEmpty()
                          select new { nombreRaza = G2.nombreRaza, id = PerdidasBD.idPerdida }).ToList();
            var consulta = grupos.GroupBy(raza => raza.nombreRaza).Select(grp => new { nombreRaza = grp.Key.ToString(), cantidad = grp.Count() }).ToList();
            foreach (var registro in consulta)
            {
                EDatos dato = new EDatos();
                dato.nombre = registro.nombreRaza;
                dato.cantidad = registro.cantidad;
                datos.Add(dato);
            }
        }
    }
}
