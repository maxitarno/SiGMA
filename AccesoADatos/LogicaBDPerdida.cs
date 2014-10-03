using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;

namespace AccesoADatos
{
    public class LogicaBDPerdida
    {
        public static bool registrarPerdida(EPerdida perdida)
        {
            bool b = false;
            try
            {
                SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                Perdidas bdPerdida = new Perdidas();
                bdPerdida.idMascota = perdida.mascota.idMascota;
                bdPerdida.idBarrioPerdida = perdida.barrio.idBarrio;
                bdPerdida.idUsuario = perdida.usuario.user;
                bdPerdida.FechaHoraPerdida = perdida.fecha;
                bdPerdida.observaciones = perdida.comentarios;
                bdPerdida.mapaPerdida = perdida.mapaPerdida;
                mapaEntidades.AddToPerdidas(bdPerdida);
                mapaEntidades.SaveChanges();
                b = true;
            }
            catch (System.Data.EntityCommandCompilationException exc)
            {
                b = false;
                throw exc;
            }
            return b;
        }

        public static EPerdida buscarPerdidaPorIdMascota(EMascota mascota)
        {
            try
            {
                SiGMAEntities mapa = Conexion.crearSegunServidor();
                var bdPerdida = mapa.Perdidas.Where(p => p.idMascota == mascota.idMascota).OrderByDescending(p => p.idPerdida);
                EPerdida perdida = new EPerdida();
                foreach (var perd in bdPerdida)
                {                    
                    perdida.idPerdida = perd.idPerdida;
                    perdida.fecha = (DateTime)perd.FechaHoraPerdida;
                    perdida.mascota = mascota;
                    return perdida;
                    //Agregar domicilio!
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void modificarEstado(string estado, int idPerdidaParam)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapa = Conexion.crearSegunServidor();
                    Perdidas bdPerdida = mapa.Perdidas.Where(p => p.idPerdida == idPerdidaParam).First();
                    bdPerdida.idEstado = mapa.Estados.Where(es => es.ambito == "Perdida" && es.nombreEstado == estado).First().idEstado;
                    mapa.SaveChanges();
                    transaction.Complete();
                }
                catch (Exception)
                {
                    transaction.Dispose();
                    throw;
                }
            }
        }
    }
}
