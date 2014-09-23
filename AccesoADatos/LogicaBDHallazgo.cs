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
                        bdHallazgo.idPerdida = hallazgo.perdida.idPerdida;
                        Mascotas bdMascota = mapa.Mascotas.Where(m => m.idMascota == hallazgo.mascota.idMascota).First();
                        bdMascota.idEstado = mapa.Estados.Where(es => es.nombreEstado == "Hallada").First().idEstado;
                    }
                    bdHallazgo.observaciones = hallazgo.observaciones;
                    //bdHallazgo.ubicacionHallazgo = 
                    mapa.AddToHallazgos(bdHallazgo);
                    mapa.SaveChanges();
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    transaction.Dispose();
                }

            }
        }
    }
}
