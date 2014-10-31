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
        public static void registrarHallazgo(EHallazgo hallazgo)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
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
                    }
                    else
                    {
                        int proxIdMascota = LogicaBDMascota.obtenerProximoIdMascota();
                        bdHallazgo.idMascota = proxIdMascota;
                        hallazgo.mascota.idMascota = proxIdMascota;
                        LogicaBDMascota.registrarMascota(hallazgo.mascota, ref mapa);
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
                }
                catch (Exception ex)
                {
                    transaction.Dispose();
                    throw ex;
                }

            }
        }

        //Metodo para buscar los hallazgos, en estado Abierta, Publicada o Modificada, desde una lista de ids de mascota
        public static List<EHallazgo> buscarHallazgos(List<int> listaIdMascotas)
        {
            List<EHallazgo> listaHallazgos = new List<EHallazgo>();
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var hallazgos = from hallazgosBD in mapa.Hallazgos
                            join estadosBD in mapa.Estados on hallazgosBD.idEstado equals estadosBD.idEstado
                            join barriosBD in mapa.Barrios on hallazgosBD.idBarrioHallazgo equals barriosBD.idBarrio
                            where (estadosBD.nombreEstado == "Abierta" || estadosBD.nombreEstado == "Publicada" || estadosBD.nombreEstado == "Modificada")
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
                    modificarEstado("Modificada", hallazgo, ref mapa);
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

        public static void modificarEstado(string estado, EHallazgo hallazgo,ref SiGMAEntities mapa)
        {
            try
            {
                Hallazgos bdHallazgo = mapa.Hallazgos.Where(h => h.idHallazgo == hallazgo.idHallazgo).First();
                bdHallazgo.idEstado = mapa.Estados.Where(e => e.ambito == "Hallazgo" && e.nombreEstado == estado).First().idEstado;
            }
            catch (Exception)
            {
                throw;
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
    }
}
