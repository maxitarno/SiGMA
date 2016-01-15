using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;

namespace AccesoADatos
{
    public class LogicaBDHallazgo
    {
        public static int registrarHallazgo(EHallazgo hallazgo)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    int retornoIdMascota;
                    SiGMAEntities mapa = Conexion.crearSegunServidor();
                    Hallazgos bdHallazgo = new Hallazgos();
                    bdHallazgo.idBarrioHallazgo = hallazgo.domicilio.barrio.idBarrio;  
                    bdHallazgo.idUsuario = hallazgo.usuario.user;
                    bdHallazgo.fechaHoraHallazgo = hallazgo.fechaHallazgo;
                    if (hallazgo.perdida != null)
                    {
                        LogicaBDPerdida.modificarEstado("Cerrada", hallazgo.perdida.idPerdida, ref mapa);
                        bdHallazgo.idPerdida = hallazgo.perdida.idPerdida;
                        LogicaBDMascota.modificarEstado("Hallada", hallazgo.mascota.idMascota, ref mapa);
                        bdHallazgo.idMascota = hallazgo.mascota.idMascota;
                        retornoIdMascota = hallazgo.mascota.idMascota;
                    }
                    else
                    {
                        int proxIdMascota = LogicaBDMascota.obtenerProximoIdMascota();
                        bdHallazgo.idMascota = proxIdMascota;
                        hallazgo.mascota.idMascota = proxIdMascota;
                        LogicaBDMascota.registrarMascota(hallazgo.mascota, ref mapa);
                        retornoIdMascota = proxIdMascota;
                    }
                    bdHallazgo.observaciones = hallazgo.observaciones;
                    bdHallazgo.idEstado = mapa.Estados.Where(es => es.ambito == "Hallazgo" && es.nombreEstado == "Abierta").First().idEstado;
                    bdHallazgo.nroCalle = hallazgo.domicilio.numeroCalle;
                    bdHallazgo.idCalle = hallazgo.domicilio.calle.idCalle;
                    bdHallazgo.idUsuario = hallazgo.usuario.user;
                    mapa.AddToHallazgos(bdHallazgo);
                    mapa.SaveChanges();
                    transaction.Complete();
                    if (hallazgo.perdida == null)
                    {
                        LogicaBDImagen.guardarImagen(hallazgo.mascota.imagen, hallazgo.mascota);
                    }
                    return retornoIdMascota;
                }
                catch (Exception ex)
                {
                    transaction.Dispose();
                    throw ex;
                }

            }
        }
        

        //Metodo para buscar los hallazgos, en estado Abierta, Publicada, Modificada o Cerrada, desde una lista de ids de mascota
        public static List<EHallazgo> buscarHallazgos(List<int> listaIdMascotas)
        {
            List<EHallazgo> listaHallazgos = new List<EHallazgo>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var hallazgos = from hallazgosBD in mapa.Hallazgos
                            join estadosBD in mapa.Estados on hallazgosBD.idEstado equals estadosBD.idEstado
                            join barriosBD in mapa.Barrios on hallazgosBD.idBarrioHallazgo equals barriosBD.idBarrio
                            where (estadosBD.nombreEstado == "Abierta" || estadosBD.nombreEstado == "Publicada" || estadosBD.nombreEstado == "Modificada"
                            || estadosBD.nombreEstado == "Cerrada")
                            && listaIdMascotas.Contains(hallazgosBD.idMascota)
                            select new
                            {
                                barrio = hallazgosBD.idBarrioHallazgo,
                                localidad = barriosBD.idLocalidad,
                                obser = hallazgosBD.observaciones,
                                idHallazgo = hallazgosBD.idHallazgo,
                                fecha = hallazgosBD.fechaHoraHallazgo,
                                idCalle = hallazgosBD.idCalle,
                                nroCalle = hallazgosBD.nroCalle, 
                                idMascota = hallazgosBD.idMascota,
                            };
            foreach (var item in hallazgos)
            {
                EHallazgo eHallaz = new EHallazgo();
                eHallaz.domicilio = new EDomicilio();
                eHallaz.domicilio.calle = new ECalle();
                eHallaz.domicilio.barrio = new EBarrio();
                eHallaz.domicilio.numeroCalle = (int)item.nroCalle;
                eHallaz.domicilio.calle.idCalle = item.idCalle;
                eHallaz.domicilio.barrio.idBarrio = item.barrio;
                eHallaz.domicilio.barrio.localidad = new ELocalidad();
                eHallaz.domicilio.barrio.localidad.idLocalidad = item.localidad;
                eHallaz.observaciones = item.obser;
                eHallaz.idHallazgo = item.idHallazgo;
                eHallaz.fechaHallazgo = item.fecha;
                eHallaz.mascota = new EMascota();
                eHallaz.mascota.idMascota = item.idMascota;
                listaHallazgos.Add(eHallaz);
            }
            if (listaHallazgos.Count != 0)
            {
                return listaHallazgos;
            }
            else
            {
                return null;
            }
        }

        public static void modificarHallazgo(EHallazgo hallazgo)
        {
            using(TransactionScope trans = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapa = Conexion.crearSegunServidor();
                    Hallazgos bdHallazgo = mapa.Hallazgos.Where(h => h.idHallazgo == hallazgo.idHallazgo).First();
                    bdHallazgo.fechaHoraHallazgo = hallazgo.fechaHallazgo;
                    bdHallazgo.idBarrioHallazgo = hallazgo.domicilio.barrio.idBarrio;
                    bdHallazgo.observaciones = hallazgo.observaciones;
                    bdHallazgo.idCalle = hallazgo.domicilio.calle.idCalle;
                    bdHallazgo.nroCalle = hallazgo.domicilio.numeroCalle;
                    bdHallazgo.idUsuario = hallazgo.usuario.user;
                    bdHallazgo.idEstado = mapa.Estados.Where(e => e.ambito == "Hallazgo" && e.nombreEstado == "Modificada").First().idEstado;                    
                    mapa.SaveChanges();
                    trans.Complete();
                }
                catch(Exception)
                {
                    trans.Dispose();
                    throw;
                }
            }
        }

        public static void modificarEstado(string estado, EHallazgo hallazgo)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapa = Conexion.crearSegunServidor();
                    Hallazgos bdHallazgo = mapa.Hallazgos.Where(h => h.idHallazgo == hallazgo.idHallazgo).First();
                    bdHallazgo.idEstado = mapa.Estados.Where(e => e.ambito == "Hallazgo" && e.nombreEstado == estado).First().idEstado;
                    trans.Complete();
                }
                catch (Exception)
                {
                    trans.Dispose();
                    throw;
                }
            }
        }
        public static List<EHallazgo> buscarHallazgos()
        {
            List<EHallazgo> listaHallazgos = new List<EHallazgo>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var hallazgos = from hallazgosBD in mapa.Hallazgos
                            join estadosBD in mapa.Estados on hallazgosBD.idEstado equals estadosBD.idEstado
                            join barriosBD in mapa.Barrios on hallazgosBD.idBarrioHallazgo equals barriosBD.idBarrio
                            select new
                            {
                                barrio = hallazgosBD.idBarrioHallazgo,
                                localidad = barriosBD.idLocalidad,
                                obser = hallazgosBD.observaciones,
                                idHallazgo = hallazgosBD.idHallazgo,
                                fecha = hallazgosBD.fechaHoraHallazgo,
                                idCalle = hallazgosBD.idCalle,
                                nroCalle = hallazgosBD.nroCalle,
                                idMascota = hallazgosBD.idMascota,
                            };
            foreach (var item in hallazgos)
            {
                EHallazgo eHallaz = new EHallazgo();
                eHallaz.domicilio = new EDomicilio();
                eHallaz.domicilio.calle = new ECalle();
                eHallaz.domicilio.barrio = new EBarrio();
                eHallaz.domicilio.numeroCalle = (int)item.nroCalle;
                eHallaz.domicilio.calle.idCalle = item.idCalle;
                eHallaz.domicilio.barrio.idBarrio = item.barrio;
                eHallaz.domicilio.barrio.localidad = new ELocalidad();
                eHallaz.domicilio.barrio.localidad.idLocalidad = item.localidad;
                eHallaz.observaciones = item.obser;
                eHallaz.idHallazgo = item.idHallazgo;
                eHallaz.fechaHallazgo = item.fecha;
                eHallaz.mascota = new EMascota();
                eHallaz.mascota.idMascota = item.idMascota;
                listaHallazgos.Add(eHallaz);
            }
            if (listaHallazgos.Count != 0)
            {
                return listaHallazgos;
            }
            else
            {
                return null;
            }
        }
        public static List<EHallazgo> buscarHallazgos1()
        {
                List<EHallazgo> listaHallazgos = new List<EHallazgo>();
                SiGMAEntities mapa = Conexion.crearSegunServidor();
                var consulta = from HallazgoBD in mapa.Hallazgos
                               join PerdidaBD in mapa.Perdidas on HallazgoBD.idPerdida equals PerdidaBD.idPerdida into group1
                               from G1 in group1.DefaultIfEmpty()
                               join BarrioBD in mapa.Barrios on HallazgoBD.idBarrioHallazgo equals BarrioBD.idBarrio into group2
                               from G2 in group2.DefaultIfEmpty()
                               join CalleBD in mapa.Calles on HallazgoBD.idCalle equals CalleBD.idCalle into group4
                               from G4 in group4.DefaultIfEmpty()
                               join MascotasBD in mapa.Mascotas on HallazgoBD.idMascota equals MascotasBD.idMascota into group5
                               from G5 in group5.DefaultIfEmpty()
                               join UsuarioBD in mapa.Usuarios on HallazgoBD.idUsuario equals UsuarioBD.user into group6
                               from G6 in group6.DefaultIfEmpty()
                               join EstadoBD in mapa.Estados on HallazgoBD.idEstado equals EstadoBD.idEstado into group7
                               from G7 in group7.DefaultIfEmpty()
                               select new
                               {
                                   Hallazgo = HallazgoBD,
                                   mascota = G5,
                                   barrio = G2,
                                   calle = G4,
                                   perdida = G1,
                                   usuario = G6,
                                   estado = G7,
                               };
                foreach (var registro in consulta)
                {
                    EHallazgo hallazgo = new EHallazgo();
                    hallazgo.idHallazgo = registro.Hallazgo.idHallazgo;
                    hallazgo.mascota = new EMascota();
                    hallazgo.mascota.idMascota = registro.mascota.idMascota;
                    hallazgo.mascota.nombreMascota = registro.mascota.nombreMascota;
                    hallazgo.domicilio = new EDomicilio();
                    hallazgo.domicilio.barrio = new EBarrio();
                    hallazgo.domicilio.barrio.localidad = new ELocalidad();
                    hallazgo.domicilio.barrio.localidad.nombre = "CBA";
                    hallazgo.domicilio.barrio.nombre = registro.barrio.nombre;
                    hallazgo.domicilio.barrio.idBarrio = registro.barrio.idBarrio;
                    hallazgo.domicilio.calle = new ECalle();
                    hallazgo.domicilio.calle.nombre = registro.calle.nombre;
                    hallazgo.domicilio.calle.idCalle = registro.calle.idCalle;
                    hallazgo.domicilio.numeroCalle = (registro.Hallazgo.nroCalle == null) ? 0 : registro.Hallazgo.nroCalle.Value;
                    hallazgo.observaciones = registro.Hallazgo.observaciones;
                    hallazgo.perdida = new EPerdida();
                    hallazgo.perdida.idPerdida = (registro.Hallazgo.idPerdida == null) ? 0 : registro.Hallazgo.idPerdida.Value;
                    hallazgo.usuario = new EUsuario();
                    hallazgo.usuario.user = registro.usuario.user;
                    hallazgo.fechaHallazgo = registro.Hallazgo.fechaHoraHallazgo;
                    hallazgo.estado = new EEstado();
                    hallazgo.estado.idEstado = registro.Hallazgo.idEstado;
                    hallazgo.estado.nombreEstado = registro.estado.nombreEstado;
                    listaHallazgos.Add(hallazgo);
                }
                return listaHallazgos; 
        }
        public static List<EHallazgo> BuscarHallazgosPorOpciones(EHallazgo hallazgo)
        {
            List<EHallazgo> hallazgos = LogicaBDHallazgo.buscarHallazgos1();
            if (hallazgo.fechaHallazgo.ToShortDateString() != "01/01/2013")
            {
                if (hallazgo.estado != null)
                {
                    if (hallazgo.domicilio.barrio != null)
                    {
                        hallazgos = hallazgos.Where(h => (h.fechaHallazgo >= hallazgo.fechaHallazgo) && h.estado.idEstado.Equals(hallazgo.estado.idEstado) && h.domicilio.barrio.idBarrio.Equals(hallazgo.domicilio.barrio.idBarrio)).ToList();
                    }
                    else
                    {
                        hallazgos = hallazgos.Where(h => (h.fechaHallazgo >= hallazgo.fechaHallazgo) && h.estado.idEstado.Equals(hallazgo.estado.idEstado)).ToList();
                    }
                }
                else
                {
                    if(hallazgo.domicilio.barrio != null){
                        hallazgos = hallazgos.Where(h => (h.fechaHallazgo >= hallazgo.fechaHallazgo) && h.domicilio.barrio.idBarrio.Equals(hallazgo.domicilio.barrio.idBarrio)).ToList();
                    }
                    else{
                        hallazgos = hallazgos.Where(h => (h.fechaHallazgo >= hallazgo.fechaHallazgo)).ToList();
                    }
                }
            }
            else
            {
                if (hallazgo.estado != null)
                {
                    if (hallazgo.domicilio.barrio != null)
                    {
                        hallazgos = hallazgos.Where(h => h.estado.idEstado.Equals(hallazgo.estado.idEstado) && h.domicilio.barrio.idBarrio.Equals(hallazgo.domicilio.barrio.idBarrio)).ToList();
                    }
                    else
                        {
                            hallazgos = hallazgos.Where(h => h.estado.idEstado.Equals(hallazgo.estado.idEstado)).ToList();
                    }
                }
                else
                {
                    hallazgos = hallazgos.Where(h => h.domicilio.barrio.idBarrio.Equals(hallazgo.domicilio.barrio.idBarrio)).ToList();
                }
            }
            return hallazgos;
        }

        //Metodo que devuelve el hallazgo "Abierto" de cada una de las mascotas pasadas por parametro
        public static List<EHallazgo> buscarHallazgosPorIdMascotas(List<EMascota> mascotas)
        {
            try
            {
                List<EHallazgo> lstHallazgos = new List<EHallazgo>();
                SiGMAEntities mapa = Conexion.crearSegunServidor();
                var hallazgos = from hallazgosBD in mapa.Hallazgos
                                join estadosBD in mapa.Estados on hallazgosBD.idEstado equals estadosBD.idEstado
                                join barriosBD in mapa.Barrios on hallazgosBD.idBarrioHallazgo equals barriosBD.idBarrio
                                join callesBD in mapa.Calles on hallazgosBD.idCalle equals callesBD.idCalle
                                join localidadesBD in mapa.Localidades on barriosBD.idLocalidad equals localidadesBD.idLocalidad
                                where estadosBD.nombreEstado == "Abierta" 
                                select new
                                {
                                    barrio = hallazgosBD.idBarrioHallazgo,
                                    nomBarrio = barriosBD.nombre,
                                    localidad = barriosBD.idLocalidad,
                                    nomLocalidad = localidadesBD.nombre,
                                    obser = hallazgosBD.observaciones,
                                    idHallazgo = hallazgosBD.idHallazgo,
                                    fecha = hallazgosBD.fechaHoraHallazgo,
                                    idCalle = hallazgosBD.idCalle,
                                    nomCalle = callesBD.nombre,
                                    nroCalle = hallazgosBD.nroCalle,
                                    idMascota = hallazgosBD.idMascota,
                                };
                foreach (var item in hallazgos)
                {
                    EHallazgo eHallaz = new EHallazgo();
                    eHallaz.mascota = mascotas.FirstOrDefault(m => m.idMascota == item.idMascota);
                    if (eHallaz.mascota != null)
                    {
                        eHallaz.domicilio = new EDomicilio();
                        eHallaz.domicilio.calle = new ECalle();
                        eHallaz.domicilio.barrio = new EBarrio();
                        eHallaz.domicilio.numeroCalle = (int)item.nroCalle;
                        eHallaz.domicilio.calle.idCalle = item.idCalle;
                        eHallaz.domicilio.calle.nombre = item.nomCalle;
                        eHallaz.domicilio.barrio.idBarrio = item.barrio;
                        eHallaz.domicilio.barrio.nombre = item.nomBarrio;
                        eHallaz.domicilio.barrio.localidad = new ELocalidad();
                        eHallaz.domicilio.barrio.localidad.idLocalidad = item.localidad;
                        eHallaz.domicilio.barrio.localidad.nombre = item.nomLocalidad;
                        eHallaz.observaciones = item.obser;
                        eHallaz.idHallazgo = item.idHallazgo;
                        eHallaz.fechaHallazgo = item.fecha;
                        lstHallazgos.Add(eHallaz);
                    }
                }
                return lstHallazgos;
            }
            catch (Exception)
            {                
                throw;
            }

        }
    }
}
