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
                    bdHallazgo.idMascota = hallazgo.mascota.idMascota;
                    bdHallazgo.idUsuario = hallazgo.usuario.user;
                    bdHallazgo.fechaHoraHallazgo = hallazgo.fechaHallazgo;
                    if (hallazgo.perdida != null)
                    {
                        LogicaBDPerdida.modificarEstado("Cerrada", hallazgo.perdida.idPerdida);
                        bdHallazgo.idPerdida = hallazgo.perdida.idPerdida;
                        LogicaBDMascota.modificarEstado("Hallada", hallazgo.mascota.idMascota, transaction);
                    }
                    bdHallazgo.observaciones = hallazgo.observaciones;
                    bdHallazgo.idEstado = mapa.Estados.Where(es => es.ambito == "Hallazgo" && es.nombreEstado == "Abierta").First().idEstado;
                    //bdHallazgo.ubicacionHallazgo = 
                    mapa.AddToHallazgos(bdHallazgo);
                    mapa.SaveChanges();
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    transaction.Dispose();
                    throw ex;
                }

            }
        }
    }
}
