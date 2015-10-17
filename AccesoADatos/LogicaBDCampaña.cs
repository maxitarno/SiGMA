using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Entidades;

namespace AccesoADatos
{
    public class LogicaBDCampaña
    {
        public static void registrarCampaña(ECampaña campaña)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    SiGMAEntities mapa = Conexion.crearSegunServidor();
                    Campañas bdCampaña = new Campañas();
                    bdCampaña.idTipoCampaña = campaña.tipoCampaña.idTipoCampaña;
                    bdCampaña.fecha = campaña.fecha.Date;
                    bdCampaña.lugar = campaña.lugar;
                    bdCampaña.hora = campaña.hora.TimeOfDay;
                    bdCampaña.imagen = campaña.imagen;
                    mapa.AddToCampañas(bdCampaña);
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

        public static void registrarCampaña(ECampaña campaña, ref SiGMAEntities mapa)
        {
            try
            {
                Campañas bdCampaña = new Campañas();
                bdCampaña.idTipoCampaña = campaña.tipoCampaña.idTipoCampaña;
                bdCampaña.fecha = campaña.fecha.Date;
                bdCampaña.lugar = campaña.lugar;
                bdCampaña.hora = campaña.hora.TimeOfDay;
                bdCampaña.imagen = campaña.imagen;
                mapa.AddToCampañas(bdCampaña);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int obtenerProximoIdCampaña()
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            var consulta = mapa.ExecuteStoreQuery<Decimal>("SELECT IDENT_CURRENT('Campañas') + IDENT_INCR('Campañas')");
            return int.Parse(consulta.FirstOrDefault().ToString());
        }
    }
}
