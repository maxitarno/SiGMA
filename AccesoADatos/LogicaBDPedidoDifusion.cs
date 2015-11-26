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
    }
}
