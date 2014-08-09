using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Transactions;

namespace AccesoADatos
{
    public class LogicaBDRol
    {
        public static bool guardarPermisoRol(List<EPermisoRol> ListadoPermisos)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                bool b = true;
                try
                {
                    SiGMAEntities mapaEntidades = Conexion.crearSegunServidor();
                    foreach (var item in ListadoPermisos)
                    {
                        PermisosRoles perRolesBD = new PermisosRoles();
                        perRolesBD.idPermiso = item.idPermiso;
                        perRolesBD.idRol = item.idRol;
                        perRolesBD.pantalla = item.pantalla;
                        mapaEntidades.AddToPermisosRoles(perRolesBD);
                        mapaEntidades.SaveChanges();
                    }
                    transaction.Complete();
                    b = true;
                }
                catch (Exception exc)
                {
                    transaction.Dispose();
                    b = false;
                    throw exc;
                }
                return b;
            }
        }
    }
}
