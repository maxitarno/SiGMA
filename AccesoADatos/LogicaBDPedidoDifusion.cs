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
                    if (pedido.campaña != null)
                    {
                        pedido.campaña.idCampaña = LogicaBDCampaña.obtenerProximoIdCampaña();
                        bdPedido.idCampaña = pedido.campaña.idCampaña;
                        LogicaBDCampaña.registrarCampaña(pedido.campaña, ref mapa);
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
    }
}
