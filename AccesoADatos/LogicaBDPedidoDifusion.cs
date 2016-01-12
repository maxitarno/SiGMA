using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Entidades;

namespace AccesoADatos
{
    public class LogicaBDPedidoDifusion
    {
        public static void registrarPedidoDifusion(EPedidoDifusion pedido)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapa = Conexion.crearSegunServidor();
                    PedidosDifusion bdPedido = new PedidosDifusion();
                    bdPedido.idEstado = pedido.estado.idEstado;
                    bdPedido.fecha = pedido.fecha;
                    bdPedido.user = pedido.user.user;
                    bdPedido.tipo = pedido.tipo;
                    if (pedido.tipo.Equals("Campaña"))
                    {
                        pedido.campaña.idCampaña = LogicaBDCampaña.obtenerProximoIdCampaña();                        
                        bdPedido.idCampaña = pedido.campaña.idCampaña;
                        LogicaBDCampaña.registrarCampaña(pedido.campaña, ref mapa);
                    }
                    else if (pedido.tipo.Equals("Adopción"))
                    {
                        bdPedido.idMascota = pedido.mascota.idMascota;
                    }
                    else if (pedido.tipo.Equals("Perdida"))
                    {
                        pedido.perdida.idPerdida = LogicaBDPerdida.obtenerProximoIdPerdida();
                        bdPedido.idPerdida = pedido.perdida.idPerdida;
                    }
                    mapa.AddToPedidosDifusion(bdPedido);
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

        public static List<EPedidoDifusion> buscarPedidosDifusion(EEstado estado)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            List<EPedidoDifusion> lstPedidos = new List<EPedidoDifusion>();
            var pedBD = from pedidosBD in mapa.PedidosDifusion
                        join estadosBD in mapa.Estados on pedidosBD.idEstado equals estadosBD.idEstado
                        where estadosBD.nombreEstado == estado.nombreEstado && estadosBD.ambito == estado.ambito
                        select pedidosBD;
            foreach (var item in pedBD)
            {
                EPedidoDifusion pedidoEntidad = new EPedidoDifusion();
                pedidoEntidad.idPedidoDifusion = item.idPedidoDifusion;
                pedidoEntidad.tipo = item.tipo;
                pedidoEntidad.motivoRechazo = item.motivoRechazo;
                pedidoEntidad.estado = estado;
                pedidoEntidad.fecha = Convert.ToDateTime(item.fecha);
                pedidoEntidad.user = new EUsuario();
                pedidoEntidad.user.user = item.user;
                if (item.idCampaña != null)
                {
                    pedidoEntidad.campaña = new ECampaña { idCampaña = Int32.Parse(item.idCampaña.ToString()) };
                }
                else if (item.idHallazgo != null)
                {
                    pedidoEntidad.hallazgo = new EHallazgo { idHallazgo = Int32.Parse(item.idHallazgo.ToString()) };
                }
                else if (item.idPerdida != null)
                {
                    pedidoEntidad.perdida = new EPerdida { idPerdida = Int32.Parse(item.idPerdida.ToString()) };
                }
                else if (item.idMascota != null)
                {
                    pedidoEntidad.mascota = new EMascota { idMascota = Int32.Parse(item.idMascota.ToString()) };
                }
                lstPedidos.Add(pedidoEntidad);
            }
            return lstPedidos;
        }

        public static List<EPedidoDifusion> buscarPedidosDifusion(EUsuario usuario)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            List<EPedidoDifusion> lstPedidos = new List<EPedidoDifusion>();
            var pedBD = from pedidosBD in mapa.PedidosDifusion
                        join estadosBD in mapa.Estados on pedidosBD.idEstado equals estadosBD.idEstado
                        where pedidosBD.user == usuario.user
                        select new
                        {
                            pedidosBD,
                            estadosBD
                        };
            foreach (var item in pedBD)
            {
                EPedidoDifusion pedidoEntidad = new EPedidoDifusion();
                pedidoEntidad.idPedidoDifusion = item.pedidosBD.idPedidoDifusion;
                pedidoEntidad.tipo = item.pedidosBD.tipo;
                pedidoEntidad.motivoRechazo = item.pedidosBD.motivoRechazo;
                pedidoEntidad.estado = new EEstado();
                pedidoEntidad.estado.idEstado = item.estadosBD.idEstado;
                pedidoEntidad.estado.nombreEstado = item.estadosBD.nombreEstado;
                pedidoEntidad.fecha = Convert.ToDateTime(item.pedidosBD.fecha);
                pedidoEntidad.user = new EUsuario();
                pedidoEntidad.user.user = item.pedidosBD.user;
                if (item.pedidosBD.idCampaña != null)
                {
                    pedidoEntidad.campaña = new ECampaña { idCampaña = Int32.Parse(item.pedidosBD.idCampaña.ToString()) };
                }
                else if (item.pedidosBD.idHallazgo != null)
                {
                    pedidoEntidad.hallazgo = new EHallazgo { idHallazgo = Int32.Parse(item.pedidosBD.idHallazgo.ToString()) };
                }
                else if (item.pedidosBD.idPerdida != null)
                {
                    pedidoEntidad.perdida = new EPerdida { idPerdida = Int32.Parse(item.pedidosBD.idPerdida.ToString()) };
                }
                else if (item.pedidosBD.idMascota != null)
                {
                    pedidoEntidad.mascota = new EMascota { idMascota = Int32.Parse(item.pedidosBD.idMascota.ToString()) };
                }
                lstPedidos.Add(pedidoEntidad);
            }
            return lstPedidos;
        }

        public static void modificarPedidoDifusion(EPedidoDifusion pedido)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapa = Conexion.crearSegunServidor();
                    PedidosDifusion pedidoBD = mapa.PedidosDifusion.Where(p => p.idPedidoDifusion == pedido.idPedidoDifusion).First();
                    pedidoBD.idEstado = pedido.estado.idEstado;
                    pedidoBD.motivoRechazo = pedido.motivoRechazo;
                    mapa.SaveChanges();
                    trans.Complete();
                }
                catch (Exception)
                {
                    trans.Dispose();
                    throw;
                }
            }
        }
        //AL VICIO HICE EL METODO, PORQUE NO PASA A ESTADO "EN ADOPCION" HASTA QUE NO SE PUBLICA EL PEDIDO
        public static void CancerlarPedidosDifusionDeAdopcion(int idMascota)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            List<EPedidoDifusion> lstPedidos = new List<EPedidoDifusion>();
            var consulta = from pedidosBD in mapa.PedidosDifusion
                      join estadosBD in mapa.Estados on pedidosBD.idEstado equals estadosBD.idEstado
                      where (estadosBD.nombreEstado == "Pendiente de Aceptacion" && estadosBD.ambito == "Difusion" && pedidosBD.Mascotas.idMascota == idMascota)
                    select new
                    {
                        pedidosBD,
                        estadosBD
                    };
            foreach (var item in consulta)
            {
                if (item.pedidosBD.idMascota != null)
                {
                    PedidosDifusion pedBD = new PedidosDifusion();
                    {
                        pedBD = (from pedidosBD in mapa.PedidosDifusion
                                 join estadosBD in mapa.Estados on pedidosBD.idEstado equals estadosBD.idEstado
                                 where (estadosBD.nombreEstado == "Pendiente de Aceptacion" && estadosBD.ambito == "Difusion" && pedidosBD.Mascotas.idMascota == idMascota)
                                 select pedidosBD).First();
                        mapa.DeleteObject(pedBD);
                        mapa.SaveChanges(System.Data.Objects.SaveOptions.DetectChangesBeforeSave);
                    }
                }
            }
        }
    }
}
