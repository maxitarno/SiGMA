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

        public static ECampaña buscarCampaña(int idCampaña)
        {
            SiGMAEntities mapa = Conexion.crearSegunServidor();
            ECampaña retorno = null;
            var consulta = from campañasBD in mapa.Campañas
                           join tipoCampañaBD in mapa.TipoCampañas
                           on campañasBD.idTipoCampaña equals tipoCampañaBD.idTipoCampaña
                           where campañasBD.idCampaña == idCampaña
                           select new
                           {
                               campañasBD,
                               tipoCampañaBD
                           };
            foreach (var item in consulta)
            {
                retorno = new ECampaña();
                retorno.idCampaña = item.campañasBD.idCampaña;
                retorno.tipoCampaña = new ETipoCampaña();
                retorno.tipoCampaña.idTipoCampaña = int.Parse(item.campañasBD.idTipoCampaña.ToString());
                retorno.tipoCampaña.descripcion = item.tipoCampañaBD.descripcion;
                retorno.fecha = item.campañasBD.fecha;
                retorno.lugar = item.campañasBD.lugar;
                retorno.imagen = item.campañasBD.imagen;
                retorno.hora = Convert.ToDateTime(item.campañasBD.hora.ToString());
            }
            return retorno;
        }
    }
}
